using Quickbooks.Core.Models;
using Quickbooks.Core.Models.DataModels;
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
    public class PaymentsService : ServiceBase
    {
        /// <summary>
        /// Get received payments from quickbooks.
        /// </summary>
        /// <param name="qbFilePath"></param>
        /// <returns></returns>
        public List<ReceivedPaymentServiceModel> GetReceivedPayments(string qbFilePath)
        {
            var response = AppUtils.ProcessQuickBookRequest(AppConstants.ReceivedPaymentsList, qbFilePath);

            if (!response.Succeeded)
            {
                throw new Exception(response.Message);
            }
            else
            {
                ReceivePaymentModel data = AppUtils.ParseXML<ReceivePaymentModel>(response.ResponseString);

                List<ReceivedPaymentServiceModel> listPayments = new List<ReceivedPaymentServiceModel>();
                data.QBXMLMsgsRs.ReceivePaymentQueryRs.ReceivePaymentRet.ForEach(x =>
                {
                    listPayments.Add(MapPaymentModelWithDataModel(x));
                });

                return listPayments;
            }
        }

        /// <summary>
        /// Get payment details
        /// </summary>
        /// <param name="qbFilePath"></param>
        /// <param name="paymentId"></param>
        /// <returns></returns>
        public ReceivedPaymentServiceModel GetPaymentDetails(string qbFilePath, string paymentId)
        {
            string inputXML = AppConstants.ReceivedPaymentDetails.Replace("#PAYMENTID#", paymentId);
            var response = AppUtils.ProcessQuickBookRequest(inputXML, qbFilePath);

            if (!response.Succeeded)
            {
                throw new Exception(response.Message);
            }
            else
            {

                ReceivePaymentDetailsModel data = AppUtils.ParseXML<ReceivePaymentDetailsModel>(response.ResponseString);
                return MapPaymentModelWithDataModel(data.QBXMLMsgsRs.ReceivePaymentQueryRs.ReceivePaymentRet);
            }
        }

        private ReceivedPaymentServiceModel MapPaymentModelWithDataModel(ReceivePaymentRet sourceModel)
        {
            return new ReceivedPaymentServiceModel
            {
                TxnID = sourceModel.TxnID,
                TimeCreated = sourceModel.TimeCreated,
                TimeModified = sourceModel.TimeModified,
                EditSequence = sourceModel.EditSequence,
                TxnNumber = sourceModel.TxnNumber,
                TxnDate = sourceModel.TxnDate,
                RefNumber = sourceModel.RefNumber,
                TotalAmount = sourceModel.TotalAmount,
                UnusedPayment = sourceModel.UnusedPayment,
                UnusedCredits = sourceModel.UnusedCredits,
                Memo = sourceModel.Memo,
                CustomerId = sourceModel.CustomerRef.ListID,
                CustomerName = sourceModel.CustomerRef.FullName,
                ARAccountId = sourceModel.ARAccountRef.ListID,
                ARAccountName = sourceModel.ARAccountRef.FullName,
                PaymentMethodId = sourceModel.PaymentMethodRef.ListID,
                PaymentMethodName = sourceModel.PaymentMethodRef.FullName,
                DepositToAccountId = sourceModel.DepositToAccountRef.ListID,
                DepositToAccountName = sourceModel.DepositToAccountRef.FullName
            };
        }
    }
}


