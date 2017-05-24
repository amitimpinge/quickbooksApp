using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quickbooks.Core.Models
{
    [XmlRoot(ElementName = "requests")]
    public class QBRequestModel
    {
        [XmlElement(ElementName = "request")]
        public List<RequestNode> RequestNode { get; set; }
    }

    [XmlRoot(ElementName = "request")]
    public class RequestNode
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "requestData")]
        public string RequestData { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
    }
}
