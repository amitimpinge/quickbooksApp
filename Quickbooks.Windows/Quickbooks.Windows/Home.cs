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
    public partial class Home : Form
    {
        ServiceFactory _service = null;
        public Home()
        {
            _service = new ServiceFactory();
           // _service.Customer.TestPost();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please select the Quickbook file first to sync Customers.");
                return;
            }
            Customers customer = new Customers(textBox1.Text);
            customer.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReceivedPayments payment = new ReceivedPayments(textBox1.Text);
            payment.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBox1.Text = openFileDialog1.FileName;
        }

        private void test(ref string name)
        {
            name = "testing";
        }
    }
}
