using System.Collections.Generic;
using System.Text;
using Alipay.Entities;

namespace Alipay
{
    public class PayForm
    {
        private readonly Config _config;
        private readonly string _html;

        public PayForm(Config config)
        {
            _config = config;

            var sbHtml = new StringBuilder();
            sbHtml.Append("<form id=\"alipaysubmit\" name=\"alipaysubmit\" action=\"https://www.alipay.com/cooperate/gateway.do?_input_charset=utf-8\" method=\"post\">");
            sbHtml.Append("{0}");
            sbHtml.Append("<input type=\"hidden\" name=\"sign\" value=\"{1}\"/>");
            sbHtml.Append("<input type=\"hidden\" name=\"sign_type\" value=\"MD5\"/>");
            sbHtml.Append("<input type=\"submit\" value=\"支付宝确认付款\"></form>");
            sbHtml.Append("<script>document.forms['alipaysubmit'].submit();</script>");

            _html = sbHtml.ToString();
        }

        public string Generate(Order order)
        {
            return Generate(Utility.GetSortedParams(_config, order));
        }

        public string Generate(BatchPayment batchPayment)
        {
            return Generate(Utility.GetSortedParams(_config, batchPayment));
        }

        private string Generate(SortedDictionary<string, string> sortedParams)
        {
            string linkString = string.Empty;
            string paramsHtml = string.Empty;

            foreach (var param in sortedParams)
            {
                linkString += param.Key + "=" + param.Value + "&";
                paramsHtml += "<input type=\"hidden\" name=\"" + param.Key + "\" value=\"" + param.Value + "\"/>";
            }

            string sign = Utility.Sign(linkString.TrimEnd('&') + _config.Key);

            return string.Format(_html, paramsHtml, sign);
        }
    }
}