using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quickbooks.Core.Models
{
    [XmlRoot(ElementName = "BillAddress")]
    public class BillAddress
    {
        [XmlElement(ElementName = "Addr1")]
        public string Addr1 { get; set; }
        [XmlElement(ElementName = "Addr2")]
        public string Addr2 { get; set; }
        [XmlElement(ElementName = "Addr3")]
        public string Addr3 { get; set; }
        [XmlElement(ElementName = "Addr4")]
        public string Addr4 { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
        [XmlElement(ElementName = "State")]
        public string State { get; set; }
    }

    [XmlRoot(ElementName = "ShipAddress")]
    public class ShipAddress
    {
        [XmlElement(ElementName = "Addr1")]
        public string Addr1 { get; set; }
        [XmlElement(ElementName = "Addr2")]
        public string Addr2 { get; set; }
        [XmlElement(ElementName = "Addr3")]
        public string Addr3 { get; set; }
        [XmlElement(ElementName = "Addr4")]
        public string Addr4 { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
        [XmlElement(ElementName = "State")]
        public string State { get; set; }
        [XmlElement(ElementName = "PostalCode")]
        public string PostalCode { get; set; }
        [XmlElement(ElementName = "Country")]
        public string Country { get; set; }
    }

    [XmlRoot(ElementName = "CustomerRet")]
    public class CustomerRet
    {
        [XmlElement(ElementName = "ListID")]
        public string ListID { get; set; }
        [XmlElement(ElementName = "TimeCreated")]
        public string TimeCreated { get; set; }
        [XmlElement(ElementName = "TimeModified")]
        public string TimeModified { get; set; }
        [XmlElement(ElementName = "EditSequence")]
        public string EditSequence { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "FullName")]
        public string FullName { get; set; }
        [XmlElement(ElementName = "IsActive")]
        public bool IsActive { get; set; }
        [XmlElement(ElementName = "Sublevel")]
        public string Sublevel { get; set; }
        [XmlElement(ElementName = "CompanyName")]
        public string CompanyName { get; set; }
        [XmlElement(ElementName = "Salutation")]
        public string Salutation { get; set; }
        [XmlElement(ElementName = "FirstName")]
        public string FirstName { get; set; }
        [XmlElement(ElementName = "MiddleName")]
        public string MiddleName { get; set; }
        [XmlElement(ElementName = "LastName")]
        public string LastName { get; set; }
        [XmlElement(ElementName = "BillAddress")]
        public BillAddress BillAddress { get; set; }
        [XmlElement(ElementName = "ShipAddress")]
        public ShipAddress ShipAddress { get; set; }
        [XmlElement(ElementName = "Phone")]
        public string Phone { get; set; }
        [XmlElement(ElementName = "AltPhone")]
        public string AltPhone { get; set; }
        [XmlElement(ElementName = "Fax")]
        public string Fax { get; set; }
        [XmlElement(ElementName = "Email")]
        public string Email { get; set; }
        [XmlElement(ElementName = "Contact")]
        public string Contact { get; set; }
        [XmlElement(ElementName = "AltContact")]
        public string AltContact { get; set; }
        [XmlElement(ElementName = "Balance")]
        public string Balance { get; set; }
        [XmlElement(ElementName = "TotalBalance")]
        public string TotalBalance { get; set; }
        [XmlElement(ElementName = "ResaleNumber")]
        public string ResaleNumber { get; set; }
        [XmlElement(ElementName = "AccountNumber")]
        public string AccountNumber { get; set; }
        [XmlElement(ElementName = "CreditLimit")]
        public string CreditLimit { get; set; }
        [XmlElement(ElementName = "JobStatus")]
        public string JobStatus { get; set; }
        [XmlElement(ElementName = "JobStartDate")]
        public string JobStartDate { get; set; }
        [XmlElement(ElementName = "JobProjectedEndDate")]
        public string JobProjectedEndDate { get; set; }
        [XmlElement(ElementName = "JobEndDate")]
        public string JobEndDate { get; set; }
        [XmlElement(ElementName = "JobDesc")]
        public string JobDesc { get; set; }
    }

    [XmlRoot(ElementName = "CustomerQueryRs")]
    public class CustomerQueryRs
    {
        [XmlElement(ElementName = "CustomerRet")]
        public List<CustomerRet> CustomerRet { get; set; }
        [XmlAttribute(AttributeName = "statusCode")]
        public string StatusCode { get; set; }
        [XmlAttribute(AttributeName = "statusSeverity")]
        public string StatusSeverity { get; set; }
        [XmlAttribute(AttributeName = "statusMessage")]
        public string StatusMessage { get; set; }
    }

    [XmlRoot(ElementName = "QBXMLMsgsRs")]
    public class CustomersModel1
    {
        [XmlElement(ElementName = "CustomerQueryRs")]
        public CustomerQueryRs CustomerQueryRs { get; set; }
    }

    [XmlRoot(ElementName = "QBXML")]
    public class CustomersModel
    {
        [XmlElement(ElementName = "QBXMLMsgsRs")]
        public CustomersModel1 QBXMLMsgsRs { get; set; }
    }

}
