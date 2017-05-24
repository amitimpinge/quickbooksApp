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
    public partial class ReceivedPaymentDetails : Form
    {
        ServiceFactory _service = null;
        string _paymentId = string.Empty, qbfilePath = string.Empty;
        public ReceivedPaymentDetails(string paymentId, string fileName)
        {
            InitializeComponent();
            _service = new ServiceFactory();
            qbfilePath = fileName;
            _paymentId = paymentId;
        }

        protected override void OnLoad(EventArgs e)
        {
            var paymentDetails = _service.Payment.GetPaymentDetails(qbfilePath, _paymentId);
            txtTimeCreated.Text = paymentDetails.TimeCreated;
            txtTimeModified.Text = paymentDetails.TimeModified;
            txtEditSequence.Text = paymentDetails.EditSequence;
            txtTxnNumber.Text = paymentDetails.TxnNumber;
            txtTxnDate.Text = paymentDetails.TxnDate;
            txtRefNumber.Text = paymentDetails.RefNumber;
            txtTotalAmount.Text = paymentDetails.TotalAmount;
            txtCustomerName.Text = paymentDetails.CustomerName;
            txtARAccountName.Text = paymentDetails.ARAccountName;
            txtPaymentMethodName.Text = paymentDetails.PaymentMethodName;
            txtDepositToAccountName.Text = paymentDetails.DepositToAccountName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
