using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace DBang.Messages
{
    public class SmsSender : ISender
    {
        private const string UriFormat = @"http://bms.hichina.com/sms_gateway/sms_api?user_id={0}&password={1}&mobile_phone={2}&msg={3}&sendtime={4}&subcode={5}";
        private readonly string _password;
        private readonly string _subcode;
        private readonly string _userId;

        public SmsSender(string userId, string password, string subcode)
        {
            _userId = userId;
            _subcode = subcode;
            _password = password;
        }

        #region ISender Members

        public bool Send(string senderMobileNumber, string receiverMobileNumber, string message)
        {
            return Send(senderMobileNumber, receiverMobileNumber, message, null);
        }

        #endregion

        public bool Send(string senderMobileNumber, string receiverMobileNumber, string message, DateTime? sendTime)
        {
            string sendingUri = CreateSmsSendingUri(receiverMobileNumber, message, sendTime);
            var request = (HttpWebRequest) WebRequest.Create(sendingUri);
            var response = (HttpWebResponse) request.GetResponse();

            Stream stream = response.GetResponseStream();
            var reader = new StreamReader(stream, Encoding.GetEncoding("gb2312"));
            string result = reader.ReadToEnd();

            stream.Close();
            response.Close();

            return result == "0";
        }

        private string CreateSmsSendingUri(string mobileNumber, string message, DateTime? sendTime)
        {
            string formattedSendTime = "";
            message = HttpUtility.UrlEncode(message, Encoding.Default);

            if (sendTime.HasValue)
                formattedSendTime = sendTime.Value.ToString("yyMMddhhmmss");

            return string.Format(UriFormat, _userId, _password, mobileNumber, message, formattedSendTime, _subcode);
        }
    }
}