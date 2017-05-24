using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quickbooks.Core.Models
{
    [XmlRoot(ElementName = "CustomerQueryRs")]
    public class CustomerDetailsResponse1
    {
        [XmlElement(ElementName = "CustomerRet")]
        public CustomerRet CustomerRet { get; set; }
        [XmlAttribute(AttributeName = "statusCode")]
        public string StatusCode { get; set; }
        [XmlAttribute(AttributeName = "statusSeverity")]
        public string StatusSeverity { get; set; }
        [XmlAttribute(AttributeName = "statusMessage")]
        public string StatusMessage { get; set; }
    }

    [XmlRoot(ElementName = "QBXMLMsgsRs")]
    public class CustomerDetailsResponse
    {
        [XmlElement(ElementName = "CustomerQueryRs")]
        public CustomerDetailsResponse1 CustomerQueryRs { get; set; }
    }

    [XmlRoot(ElementName = "QBXML")]
    public class CustomerDetailsModel
    {
        [XmlElement(ElementName = "QBXMLMsgsRs")]
        public CustomerDetailsResponse QBXMLMsgsRs { get; set; }
    }
}
