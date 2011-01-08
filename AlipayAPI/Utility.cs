using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using Alipay.Entities;

namespace Alipay
{
    /// <summary>
    /// 功能：支付宝接口公用函数类
    /// 详细：该类是请求、通知返回两个文件所调用的公用函数核心处理文件，不需要修改
    /// 版本：3.1
    /// 修改日期：2010-10-29
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考。
    /// </summary>
    public static class Utility
    {
        private static readonly MD5 _cryptor = new MD5CryptoServiceProvider();

        /// <summary>
        /// 签名字符串
        /// </summary>
        /// <param name="target">需要签名的字符串</param>
        /// <returns>签名结果</returns>
        public static string Sign(string target)
        {
            var signedResult = new StringBuilder(32);
            byte[] bytes = _cryptor.ComputeHash(Encoding.UTF8.GetBytes(target));

            for (int i = 0; i < bytes.Length; i++)
                signedResult.Append(bytes[i].ToString("x").PadLeft(2, '0'));

            return signedResult.ToString();
        }

        /// <summary>
        /// 用于防钓鱼，调用接口query_timestamp来获取时间戳的处理函数
        /// 注意：远程解析XML出错，与IIS服务器配置有关
        /// </summary>
        /// <param name="partner">合作身份者ID</param>
        /// <returns>时间戳字符串</returns>
        public static string QueryTimestamp(string partner)
        {
            string url = "https://mapi.alipay.com/gateway.do?service=query_timestamp&partner=" + partner;
            var reader = new XmlTextReader(url);
            var xmlDoc = new XmlDocument();

            xmlDoc.Load(reader);
            return xmlDoc.SelectSingleNode("/alipay/response/timestamp/encrypt_key").InnerText;
        }

        public static SortedDictionary<string, string> GetSortedParams(NameValueCollection paramCollection)
        {
            var sortedParams = new SortedDictionary<string, string>();

            foreach (KeyValuePair<string, string> param in paramCollection)
                sortedParams.Add(param.Key, param.Value);

            return sortedParams;
        }

        public static SortedDictionary<string, string> GetSortedParams(Config config, Order order)
        {
            var sortedParams = new SortedDictionary<string, string>();

            sortedParams.Add("service", "create_direct_pay_by_user");
            sortedParams.Add("payment_type", "1");
            sortedParams.Add("partner", config.Partner);
            sortedParams.Add("seller_email", config.SellerEmail);
            sortedParams.Add("return_url", config.ReturnUrl);
            sortedParams.Add("notify_url", config.NotifyUrl);
            sortedParams.Add("_input_charset", "utf-8");
            sortedParams.Add("show_url", config.ShowUrl);
            sortedParams.Add("out_trade_no", order.OutTradeNo);
            sortedParams.Add("subject", order.Subject);
            sortedParams.Add("body", order.Body);
            sortedParams.Add("total_fee", order.TotalFee);
            sortedParams.Add("paymethod", order.PayMethod);
            sortedParams.Add("defaultbank", order.DefaultBank);
            sortedParams.Add("anti_phishing_key", order.AntiPhishingKey);
            sortedParams.Add("exter_invoke_ip", order.ExterInvokeIp);
            sortedParams.Add("extra_common_param", order.ExtraCommonParam);
            sortedParams.Add("buyer_email", order.BuyerEmail);
            sortedParams.Add("royalty_type", order.RoyaltyType);
            sortedParams.Add("royalty_parameters", order.RoyaltyParameters);

            return sortedParams;
        }

        public static SortedDictionary<string, string> GetSortedParams(Config config, BatchPayment batchPayment)
        {
            var sortedParams = new SortedDictionary<string, string>();

            sortedParams.Add("_input_charset", "utf-8");
            sortedParams.Add("account_name", config.MainName);
            sortedParams.Add("batch_fee", batchPayment.BatchFee);
            sortedParams.Add("batch_no", batchPayment.BatchNo);
            sortedParams.Add("batch_num", batchPayment.BatchNum);
            sortedParams.Add("detail_data", batchPayment.DetailData);
            sortedParams.Add("email", config.SellerEmail);
            sortedParams.Add("notify_url", config.NotifyUrl);
            sortedParams.Add("partner", config.Partner);
            sortedParams.Add("pay_date", batchPayment.PayDate);
            sortedParams.Add("service", "batch_trans_notify");

            return sortedParams;
        }

        /// <summary>
        /// 获取远程服务器ATN结果
        /// </summary>
        /// <param name="url">指定URL路径地址</param>
        /// <param name="timeout">超时时间设置</param>
        /// <returns>服务器ATN结果</returns>
        public static string GetHttpResponse(string url, int timeout)
        {
            string result;

            try
            {
                var request = (HttpWebRequest) WebRequest.Create(url);
                request.Timeout = timeout;
                var response = (HttpWebResponse) request.GetResponse();

                Stream stream = response.GetResponseStream();
                var reader = new StreamReader(stream, Encoding.UTF8);
                result = reader.ReadToEnd();

                stream.Close();
                response.Close();
            }
            catch (Exception exp)
            {
                result = "错误：" + exp.Message;
            }

            return result;
        }
    }
}