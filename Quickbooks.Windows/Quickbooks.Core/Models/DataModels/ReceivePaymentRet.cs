using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quickbooks.Core.Models.DataModels
{
    [XmlRoot(ElementName = "ReceivePaymentRet")]
    public class ReceivePaymentRet
    {
        [XmlElement(ElementName = "TxnID")]
        public string TxnID { get; set; }
        [XmlElement(ElementName = "TimeCreated")]
        public string TimeCreated { get; set; }
        [XmlElement(ElementName = "TimeModified")]
        public string TimeModified { get; set; }
        [XmlElement(ElementName = "EditSequence")]
        public string EditSequence { get; set; }
        [XmlElement(ElementName = "TxnNumber")]
        public string TxnNumber { get; set; }
        [XmlElement(ElementName = "CustomerRef")]
        public CustomerRef CustomerRef { get; set; }
        [XmlElement(ElementName = "ARAccountRef")]
        public ARAccountRef ARAccountRef { get; set; }
        [XmlElement(ElementName = "TxnDate")]
        public string TxnDate { get; set; }
        [XmlElement(ElementName = "RefNumber")]
        public string RefNumber { get; set; }
        [XmlElement(ElementName = "TotalAmount")]
        public string TotalAmount { get; set; }
        [XmlElement(ElementName = "PaymentMethodRef")]
        public PaymentMethodRef PaymentMethodRef { get; set; }
        [XmlElement(ElementName = "DepositToAccountRef")]
        public DepositToAccountRef DepositToAccountRef { get; set; }
        [XmlElement(ElementName = "UnusedPayment")]
        public string UnusedPayment { get; set; }
        [XmlElement(ElementName = "UnusedCredits")]
        public string UnusedCredits { get; set; }
        [XmlElement(ElementName = "Memo")]
        public string Memo { get; set; }
    }
}
