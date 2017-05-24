using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quickbooks.Core.Models.DataModels
{
    [XmlRoot(ElementName = "CustomerRef")]
    public class CustomerRef
    {
        [XmlElement(ElementName = "ListID")]
        public string ListID { get; set; }
        [XmlElement(ElementName = "FullName")]
        public string FullName { get; set; }
    }
}
