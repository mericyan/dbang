using System;
using System.Linq;

namespace Alipay.Entities
{
    public class Payment
    {
        public long SerialNumber { get; set; }
        public string PayeeAccount { get; set; }
        public string PayeeName { get; set; }
        public decimal Fee { get; set; }
        public string Remark { get; set; }
    }

    public class BatchPayment
    {
        private readonly Payment[] _payments;
        private string _batchNo;

        public BatchPayment(params Payment[] payments)
        {
            _payments = payments;

            BatchNum = payments.Length.ToString();

            BatchFee = payments.Sum(p => p.Fee).ToString();
        }

        public string BatchFee { get; private set; }

        public string BatchNo
        {
            get { return PayDate + _batchNo; }
            set { _batchNo = value; }
        }

        public string BatchNum { get; private set; }

        public string DetailData
        {
            get
            {
                string detailData = "";

                foreach (Payment payment in _payments)
                    detailData += "|" + payment.SerialNumber + "^" + payment.PayeeAccount + "^" + payment.PayeeName + "^" + payment.Fee + "^" + payment.Remark;

                return detailData.Substring(1);
            }
        }

        public string PayDate
        {
            get { return DateTime.Now.ToString("yyyyMMdd"); }
        }
    }
}