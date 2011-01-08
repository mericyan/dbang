using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using Alipay.Entities;

namespace Alipay
{
    public class Notification
    {
        private readonly Config _config;

        public Notification(Config config)
        {
            _config = config;
        }

        public bool Verify()
        {
            NameValueCollection form = HttpContext.Current.Request.Form;
            NameValueCollection queryString = HttpContext.Current.Request.QueryString;

            NameValueCollection paramCollection = queryString.AllKeys.Contains("notify_id") ? queryString : form;

            return VerifySign(paramCollection) && VerifyNotification(paramCollection);
        }

        private bool VerifySign(NameValueCollection paramCollection)
        {
            string linkString = "";
            SortedDictionary<string, string> sortedParams = Utility.GetSortedParams(paramCollection);

            foreach (var param in sortedParams)
                linkString += param.Key + "=" + param.Value + "&";

            string currentSign = paramCollection["sign"];
            string localSign = Utility.Sign(linkString.TrimEnd('&') + _config.Key);

            return localSign == currentSign;
        }

        private bool VerifyNotification(NameValueCollection paramCollection)
        {
            string notifyId = paramCollection["notify_id"];

            const string gateway = "http://notify.alipay.com/trade/notify_query.do?";
            string verifyUrl = gateway + "partner=" + _config.Partner + "&notify_id=" + notifyId;

            return Utility.GetHttpResponse(verifyUrl, 120000).ToLower() == "true";
        }
    }
}