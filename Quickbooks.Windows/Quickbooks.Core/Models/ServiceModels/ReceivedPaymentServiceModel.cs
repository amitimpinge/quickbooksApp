using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickbooks.Core.Models.ServiceModels
{
    public class ReceivedPaymentServiceModel
    {
        public string TxnID { get; set; }
        public string TimeCreated { get; set; }
        public string TimeModified { get; set; }
        public string EditSequence { get; set; }
        public string TxnNumber { get; set; }
        public string TxnDate { get; set; }
        public string RefNumber { get; set; }
        public string TotalAmount { get; set; }
        public string UnusedPayment { get; set; }
        public string UnusedCredits { get; set; }
        public string Memo { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ARAccountId { get; set; }
        public string ARAccountName { get; set; }
        public string PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }
        public string DepositToAccountId { get; set; }
        public string DepositToAccountName { get; set; }
    }
}