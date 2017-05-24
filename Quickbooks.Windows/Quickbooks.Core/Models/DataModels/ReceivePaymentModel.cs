using Quickbooks.Core.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quickbooks.Core.Models
{
    [XmlRoot(ElementName = "QBXML")]
    public class ReceivePaymentModel
    {
        [XmlElement(ElementName = "QBXMLMsgsRs")]
        public ReceivePaymentModel1 QBXMLMsgsRs { get; set; }
    }

    [XmlRoot(ElementName = "QBXMLMsgsRs")]
    public class ReceivePaymentModel1
    {
        [XmlElement(ElementName = "ReceivePaymentQueryRs")]
        public ReceivePaymentQueryRs ReceivePaymentQueryRs { get; set; }
    }

    [XmlRoot(ElementName = "ReceivePaymentQueryRs")]
    public class ReceivePaymentQueryRs
    {
        [XmlElement(ElementName = "ReceivePaymentRet")]
        public List<ReceivePaymentRet> ReceivePaymentRet { get; set; }
        [XmlAttribute(AttributeName = "statusCode")]
        public string StatusCode { get; set; }
        [XmlAttribute(AttributeName = "statusSeverity")]
        public string StatusSeverity { get; set; }
        [XmlAttribute(AttributeName = "statusMessage")]
        public string StatusMessage { get; set; }
    }
}
