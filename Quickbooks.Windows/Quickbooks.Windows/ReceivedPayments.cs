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
    public partial class ReceivedPayments : Form
    {
        ServiceFactory _service = null;
        string qbfilePath = string.Empty;
        public ReceivedPayments(string fileName)
        {
            _service = new ServiceFactory();
            qbfilePath = fileName;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                var response = _service.Payment.GetReceivedPayments(qbfilePath);
                List<object> dataList = new List<object>();
                response.ForEach(x =>
                {
                    dataList.Add(new
                    {
                        TxnID = x.TxnID,
                        TotalAmount = x.TotalAmount,
                        CustomerName = x.CustomerName,
                        TxnDate = x.TxnDate,
                        TimeCreated = x.TimeCreated
                    });
                });

                dataGridView1.DataSource = dataList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string paymentId = (string)row.Cells["TxnID"].Value;
                ReceivedPaymentDetails paymentDetails = new ReceivedPaymentDetails(paymentId, qbfilePath);
                paymentDetails.Show();
            }
        }
    }
}
