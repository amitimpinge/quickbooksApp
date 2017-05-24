using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quickbooks.Core.Models.DataModels
{
    [XmlRoot(ElementName = "ReceivePaymentQueryRs")]
    public class ReceivePaymentDetailsQueryRs
    {
        [XmlElement(ElementName = "ReceivePaymentRet")]
        public ReceivePaymentRet ReceivePaymentRet { get; set; }
        [XmlAttribute(AttributeName = "statusCode")]
        public string StatusCode { get; set; }
        [XmlAttribute(AttributeName = "statusSeverity")]
        public string StatusSeverity { get; set; }
        [XmlAttribute(AttributeName = "statusMessage")]
        public string StatusMessage { get; set; }
    }

    [XmlRoot(ElementName = "QBXMLMsgsRs")]
    public class ReceivePaymentDetailsModel1
    {
        [XmlElement(ElementName = "ReceivePaymentQueryRs")]
        public ReceivePaymentDetailsQueryRs ReceivePaymentQueryRs { get; set; }
    }

    [XmlRoot(ElementName = "QBXML")]
    public class ReceivePaymentDetailsModel
    {
        [XmlElement(ElementName = "QBXMLMsgsRs")]
        public ReceivePaymentDetailsModel1 QBXMLMsgsRs { get; set; }
    }
}
