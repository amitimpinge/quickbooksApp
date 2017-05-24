using Quickbooks.Core.Models;
using Quickbooks.Core.Models.ServiceModels;
using Quickbooks.Core.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quickbooks.Core.Services
{
    public class CustomerService : ServiceBase
    {
        /// <summary>
        /// Get customers from quickbooks
        /// </summary>
        /// <param name="qbFilePath"></param>
        /// <returns></returns>
        public List<CustomerServiceModel> GetCustomers(string qbFilePath)
        {
            var response = AppUtils.ProcessQuickBookRequest(AppConstants.CustomersList, qbFilePath);

            if (!response.Succeeded)
            {
                throw new Exception(response.Message);
            }
            else
            {
                var data = AppUtils.ParseXML<CustomersModel>(response.ResponseString);
                List<CustomerServiceModel> model = new List<CustomerServiceModel>();
                data.QBXMLMsgsRs.CustomerQueryRs.CustomerRet.ForEach(x =>
                {
                    model.Add(MapCustomerModelWithDataModel(x));
                });

                return model;
            }
        }

        /// <summary>
        /// Get customers from quickbooks
        /// </summary>
        /// <param name="qbFilePath"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public CustomerServiceModel GetCustomerDetails(string qbFilePath, string customerId)
        {
            string inputXML = AppConstants.CustomersDetails.Replace("#CUSTOMERID#", customerId);
            var response = AppUtils.ProcessQuickBookRequest(inputXML, qbFilePath);

            if (!response.Succeeded)
            {
                throw new Exception(response.Message);
            }
            else
            {
                var data = AppUtils.ParseXML<CustomerDetailsModel>(response.ResponseString);

                return MapCustomerModelWithDataModel(data.QBXMLMsgsRs.CustomerQueryRs.CustomerRet);
            }
        }

        private CustomerServiceModel MapCustomerModelWithDataModel(CustomerRet sourceModel)
        {
            return new CustomerServiceModel
            {
                ListID = sourceModel.ListID,
                TimeCreated = sourceModel.TimeCreated,
                TimeModified = sourceModel.TimeModified,
                EditSequence = sourceModel.EditSequence,
                Name = sourceModel.Name,
                FullName = sourceModel.FullName,
                IsActive = sourceModel.IsActive,
                Sublevel = sourceModel.Sublevel,
                CompanyName = sourceModel.CompanyName,
                Salutation = sourceModel.Salutation,
                FirstName = sourceModel.FirstName,
                MiddleName = sourceModel.MiddleName,
                LastName = sourceModel.LastName,
                BillAddress = sourceModel.BillAddress != null ? new BillAddressSVModel
                {
                    Addr1 = sourceModel.BillAddress.Addr1,
                    Addr2 = sourceModel.BillAddress.Addr2,
                    Addr3 = sourceModel.BillAddress.Addr3,
                    Addr4 = sourceModel.BillAddress.Addr4,
                    City = sourceModel.BillAddress.City,
                    State = sourceModel.BillAddress.State
                } : null,
                ShipAddress = sourceModel.ShipAddress != null ? new ShipAddressSVModel
                {
                    Addr1 = sourceModel.ShipAddress.Addr1,
                    Addr2 = sourceModel.ShipAddress.Addr2,
                    Addr3 = sourceModel.ShipAddress.Addr3,
                    Addr4 = sourceModel.ShipAddress.Addr4,
                    City = sourceModel.ShipAddress.City,
                    State = sourceModel.ShipAddress.State,
                    PostalCode = sourceModel.ShipAddress.PostalCode,
                    Country = sourceModel.ShipAddress.Country
                } : null,
                Phone = sourceModel.Phone,
                AltPhone = sourceModel.AltPhone,
                Fax = sourceModel.Fax,
                Email = sourceModel.Email,
                Contact = sourceModel.Contact,
                AltContact = sourceModel.AltContact,
                Balance = sourceModel.Balance,
                TotalBalance = sourceModel.TotalBalance,
                ResaleNumber = sourceModel.ResaleNumber,
                AccountNumber = sourceModel.AccountNumber,
                CreditLimit = sourceModel.CreditLimit,
                JobStatus = sourceModel.JobStatus,
                JobStartDate = sourceModel.JobStartDate,
                JobProjectedEndDate = sourceModel.JobProjectedEndDate,
                JobEndDate = sourceModel.JobEndDate,
                JobDesc = sourceModel.JobDesc
            };
        }

        /// <summary>
        /// Add new customer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResponseModel AddCustomer(CustomerServiceModel model)
        {
            string inputxml = AppConstants.CustomerAdd.Replace("#NAME#", model.Name)
                .Replace("#ISACTIVE#", model.IsActive.ToString())
                .Replace("#COMPANY#", model.CompanyName)
                .Replace("#Salutation#", model.Salutation)
                .Replace("#FirstName#", model.FirstName)
                .Replace("#MiddleName#", model.MiddleName)
                .Replace("#LastName#", model.LastName)
                .Replace("#BAddr1#", model.BillAddress.Addr1)
                .Replace("#BAddr2#", model.BillAddress.Addr2)
                .Replace("#BAddr3#", model.BillAddress.Addr3)
                .Replace("#BAddr4#", model.BillAddress.Addr4)
                .Replace("#BCity#", model.BillAddress.City)
                .Replace("#BState#", model.BillAddress.State)
                .Replace("#BPostalCode#", model.BillAddress.PostalCode)
                .Replace("#BCountry#", model.BillAddress.Country)
                .Replace("#SAddr1#", model.ShipAddress.Addr1)
                .Replace("#SAddr2#", model.ShipAddress.Addr2)
                .Replace("#SAddr3#", model.ShipAddress.Addr3)
                .Replace("#SAddr4#", model.ShipAddress.Addr4)
                .Replace("#SCity#", model.ShipAddress.City)
                .Replace("#SState#", model.ShipAddress.State)
                .Replace("#SPostalCode#", model.ShipAddress.PostalCode)
                .Replace("#SCountry#", model.ShipAddress.Country)
                .Replace("#Phone#", model.Phone)
                .Replace("#AltPhone#", model.AltPhone)
                .Replace("#Fax#", model.Fax)
                .Replace("#Email#", model.Email)
                .Replace("#Contact#", model.Contact)
                .Replace("#AltContact#", model.AltContact)
                .Replace("#OpenBalance#", model.TotalBalance)
                .Replace("#OpenBalanceDate#", "")
                .Replace("#ResaleNumber#", model.ResaleNumber)
                .Replace("#AccountNumber#", model.AccountNumber)
                .Replace("#CreditLimit#", model.CreditLimit)
                .Replace("#JobStatus#", model.JobStatus)
                .Replace("#JobStartDate#", model.JobStartDate)
                .Replace("#JobProjectedEndDate#", model.JobProjectedEndDate)
                .Replace("#JobEndDate#", model.JobEndDate)
                .Replace("#JobDesc#", model.JobDesc);

            return new ResponseModel { Succeeded = true };
        }

        //public void TestPost()
        //{
        //    string jsonData = @"{'authenticateTestRequest': {'merchantAuthentication': {'name': '6qq8A4GrV','transactionKey': '8zks996GQ7525YUB'}}}";
        //    string data = AppUtils.MakeWebRequest("http://localhost:55007/api/test/InsertTest", EnumUtils.RequestMethod.POST, "{Name:'Sanjay Yadav'}");
        //    string data1 = AppUtils.MakeWebRequest("http://localhost:55007/api/test/GetTestData", EnumUtils.RequestMethod.GET);
        //}
    }
}
