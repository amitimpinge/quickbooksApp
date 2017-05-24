using Quickbooks.Core.Services;
using Quickbooks.Windows.Customer;
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
    public partial class Customers : Form
    {
        ServiceFactory _service = null;
        string qbfilePath = string.Empty;
        public Customers(string fileName)
        {
            _service = new ServiceFactory();
            qbfilePath = fileName;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                var response = _service.Customer.GetCustomers(qbfilePath);
                List<object> dataList = new List<object>();
                response.ForEach(x =>
                {
                    dataList.Add(new
                    {
                        CustomerName = x.Name,
                        IsActive = x.IsActive,
                        FullName = x.FullName,
                        Phone = x.Phone,
                        Email = x.Email,
                        TotalBalance = x.TotalBalance,
                        ListId = x.ListID
                    });
                });

                dataGridView1.DataSource = dataList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Customers_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string customerId = (string)row.Cells["ListId"].Value;
                CustomerDetails details = new CustomerDetails(customerId, qbfilePath);
                details.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.Show();
        }
    }
}
