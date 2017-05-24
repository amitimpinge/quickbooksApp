using Quickbooks.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quickbooks.Windows
{
    public partial class CustomerDetails : Form
    {
        ServiceFactory _service = null;
        string customerId = string.Empty, qbfilePath = string.Empty;
        public CustomerDetails(string customerId, string fileName)
        {
            InitializeComponent();
            _service = new ServiceFactory();
            qbfilePath = fileName;
        }

        protected override void OnLoad(EventArgs e)
        {
            var customerDetails = _service.Customer.GetCustomerDetails(qbfilePath, customerId);
            label1.Text = customerDetails.FullName;
            label7.Text = customerDetails.Name;
            label8.Text = customerDetails.IsActive.ToString();
            label9.Text = customerDetails.Phone;
            label10.Text = customerDetails.Email;
            label11.Text = customerDetails.TotalBalance;

            BAddress1.Text = customerDetails.BillAddress.Addr1;
            BAddress2.Text = customerDetails.BillAddress.Addr2;
            BAddress3.Text = customerDetails.BillAddress.Addr3;
            BAddress4.Text = customerDetails.BillAddress.Addr4;
            BCity.Text = customerDetails.BillAddress.City;
            BState.Text = customerDetails.BillAddress.State;

            SAddress1.Text = customerDetails.ShipAddress.Addr1;
            SAddress2.Text = customerDetails.ShipAddress.Addr2;
            SAddress3.Text = customerDetails.ShipAddress.Addr3;
            SAddress4.Text = customerDetails.ShipAddress.Addr4;
            SCity.Text = customerDetails.ShipAddress.City;
            SState.Text = customerDetails.ShipAddress.State;
            SCountry.Text = customerDetails.ShipAddress.Country;
            SPostalCode.Text = customerDetails.ShipAddress.PostalCode;
        }
    }
}