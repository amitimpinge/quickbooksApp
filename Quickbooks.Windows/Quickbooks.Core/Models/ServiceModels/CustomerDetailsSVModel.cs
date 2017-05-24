using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickbooks.Core.Models.ServiceModels
{
    public class CustomerServiceModel
    {
        public string ListID { get; set; }
        public string TimeCreated { get; set; }
        public string TimeModified { get; set; }
        public string EditSequence { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public string Sublevel { get; set; }
        public string CompanyName { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public BillAddressSVModel BillAddress { get; set; }
        public ShipAddressSVModel ShipAddress { get; set; }
        public string Phone { get; set; }
        public string AltPhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string AltContact { get; set; }
        public string Balance { get; set; }
        public string TotalBalance { get; set; }
        public string ResaleNumber { get; set; }
        public string AccountNumber { get; set; }
        public string CreditLimit { get; set; }
        public string JobStatus { get; set; }
        public string JobStartDate { get; set; }
        public string JobProjectedEndDate { get; set; }
        public string JobEndDate { get; set; }
        public string JobDesc { get; set; }
    }

    public class BillAddressSVModel
    {
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Addr3 { get; set; }
        public string Addr4 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }

    public class ShipAddressSVModel
    {
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Addr3 { get; set; }
        public string Addr4 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}







