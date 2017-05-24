using Quickbooks.Core.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quickbooks.Windows.Customer
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBillAddress.Checked)
            {
                pnlBillAddress.Show();
            }
            else
            {
                pnlBillAddress.Hide();
            }
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkShipAddress.Checked)
            {
                pnlShipAddress.Show();
            }
            else
            {
                pnlShipAddress.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerServiceModel model = new CustomerServiceModel
            {
                TimeCreated = DateTime.Now.ToString(),
                TimeModified = DateTime.Now.ToString(),
                Name = txtName.Text,
                FullName = txtName.Text,
                IsActive = chkActive.Checked,
                CompanyName = txtCompanyName.Text,
                Salutation = txtSalutation.Text,
                FirstName = txtFirstName.Text,
                MiddleName = txtMiddleName.Text,
                LastName = txtLastName.Text,
                BillAddress = new BillAddressSVModel
                {
                    Addr1 = txtBAddr1.Text,
                    Addr2 = txtBAddr2.Text,
                    Addr3 = txtBAddr3.Text,
                    Addr4 = txtBAddr4.Text,
                    City = txtBCity.Text,
                    Country = txtBCountry.Text,
                    PostalCode = txtBPostalCode.Text,
                    State = txtBState.Text
                },
                ShipAddress = new ShipAddressSVModel
                {
                    Addr2 = txtSAddr2.Text,
                    Addr3 = txtSAddr3.Text,
                    Addr4 = txtSAddr4.Text,
                    City = txtSCity.Text,
                    PostalCode = txtSPostalCode.Text,
                    State = txtSState.Text
                }
                /*Phone 
                AltPhone 
                Fax 
                Email 
                Contact 
                AltContact 
                Balance 
                TotalBalance 
                ResaleNumber 
                AccountNumber 
                CreditLimit 
                JobStatus 
                JobStartDate 
                JobProjectedEndDate 
                JobEndDate 
                JobDesc */
            };
        }
    }
}
