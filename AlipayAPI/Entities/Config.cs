namespace Alipay.Entities
{
    /// <summary>
    /// 功能：设置帐户有关信息及返回路径（基础配置页面）
    /// 版本：3.1
    /// 日期：2010-10-29
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考。
    /// 如何获取安全校验码和合作身份者ID
    /// 1.访问支付宝商户服务中心(b.alipay.com)，然后用您的签约支付宝账号登陆.
    /// 2.访问“技术服务”→“下载技术集成文档”（https://b.alipay.com/support/helperApply.htm?action=selfIntegration）
    /// 3.在“自助集成帮助”中，点击“合作者身份(Partner ID)查询”、“安全校验码(Key)查询”
    /// 安全校验码查看时，输入支付密码后，页面呈灰色的现象，怎么办？
    /// 解决方法：
    /// 1、检查浏览器配置，不让浏览器做弹框屏蔽设置
    /// 2、更换浏览器或电脑，重新登录查询。
    /// </summary>
    public class Config
    {
        private string _key;

        /// <summary>
        /// 获取或设置合作者身份ID
        /// 合作身份者ID，以2088开头由16位纯数字组成的字符串
        /// </summary>
        public string Partner { get; set; }

        /// <summary>
        /// 获取或设置交易安全检验码
        /// 交易安全检验码，由数字和字母组成的32位字符串
        /// </summary>
        public string Key
        {
            get { return _key.Trim(); }
            set { _key = value; }
        }

        /// <summary>
        /// 获取或设置签约支付宝账号或卖家支付宝帐户
        /// 签约支付宝账号或卖家支付宝帐户
        /// </summary>
        public string SellerEmail { get; set; }

        /// <summary>
        /// 获取或设置付完款后跳转的页面路径
        /// 付完款后跳转的页面 要用 http://格式的完整路径，不允许加?id=123这类自定义参数
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// 获取或设置服务器异步通知页面路径
        /// 交易过程中服务器通知的页面 要用 http://格式的完整路径，不允许加?id=123这类自定义参数
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 获取或设置网站商品的展示地址
        /// 网站商品的展示地址，不允许加?id=123这类自定义参数
        /// </summary>
        public string ShowUrl { get; set; }

        /// <summary>
        /// 获取或设置收款方名称
        /// 收款方名称，如：公司名称、网站名称、收款人姓名等
        /// </summary>
        public string MainName { get; set; }
    }
}