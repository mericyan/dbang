namespace Alipay.Entities
{
    public class Order
    {
        /// <summary>
        /// 网站订单系统中的唯一订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 订单名称
        /// 显示在支付宝收银台里的“商品名称”里，显示在支付宝的交易管理的“商品名称”的列表里
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 订单描述、订单详细、订单备注
        /// 显示在支付宝收银台里的“商品描述”里
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 订单总金额
        /// 显示在支付宝收银台里的“应付总额”里
        /// </summary>
        public string TotalFee { get; set; }

        /// <summary>
        /// 默认支付方式
        /// 四个值可选：bankPay(网银); cartoon(卡通); directPay(余额); CASH(网点支付)
        /// </summary>
        public string PayMethod { get; set; }

        /// <summary>
        /// 默认网银代号
        /// 代号列表见club.alipay.com/read.php?tid=8681379
        /// </summary>
        public string DefaultBank { get; set; }

        /// <summary>
        /// 防钓鱼时间戳
        /// </summary>
        public string AntiPhishingKey { get; set; }

        /// <summary>
        /// 买家本地电脑的IP地址
        /// </summary>
        public string ExterInvokeIp { get; set; }

        /// <summary>
        /// 自定义参数
        /// 可存放任何内容（除等特殊字符外），不会显示在页面上
        /// </summary>
        public string ExtraCommonParam { get; set; }

        /// <summary>
        /// 默认买家支付宝账号
        /// </summary>
        public string BuyerEmail { get; set; }

        /// <summary>
        /// 提成类型
        /// 该值为固定值：10，不需要修改
        /// </summary>
        public string RoyaltyType { get; set; }

        /// <summary>
        /// 提成信息集
        /// 与需要结合商户网站自身情况动态获取每笔交易的各分润收款账号、各分润金额、各分润说明。最多只能设置10条
        /// </summary>
        public string RoyaltyParameters { get; set; }
    }
}