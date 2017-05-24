using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickbooks.Core.Utilities
{
    public class AppConstants
    {
        public const string CustomersList = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<?qbxml version=""2.0""?>
<QBXML>
   <QBXMLMsgsRq onError=""stopOnError"">
      <CustomerQueryRq>
      </CustomerQueryRq>
   </QBXMLMsgsRq>
</QBXML>";

        public const string ReceivedPaymentsList = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<?qbxml version=""2.0""?>
<QBXML>
   <QBXMLMsgsRq onError=""stopOnError"">
      <ReceivePaymentQueryRq>
      </ReceivePaymentQueryRq>
   </QBXMLMsgsRq>
</QBXML>";

        public const string CustomersDetails = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<?qbxml version=""2.0""?>
<QBXML>
   <QBXMLMsgsRq onError=""stopOnError"">
      <CustomerQueryRq>
         <ListID>#CUSTOMERID#</ListID>
      </CustomerQueryRq>
   </QBXMLMsgsRq>
</QBXML>";

        public const string ReceivedPaymentDetails = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<?qbxml version=""2.0""?>
<QBXML>
   <QBXMLMsgsRq onError=""stopOnError"">
      <ReceivePaymentQueryRq>
          <TxnID>#PAYMENTID#</TxnID>
      </ReceivePaymentQueryRq>
   </QBXMLMsgsRq>
</QBXML>";

        public const string CustomerAdd = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<?qbxml version=""2.0""?>
<QBXML>
   <QBXMLMsgsRq onError=""stopOnError"">
      <CustomerAddRq>
         <CustomerAdd>
            <Name>#NAME#</Name>
            <IsActive>#ISACTIVE#</IsActive>
            <CompanyName>#COMPANY#</CompanyName>
            <Salutation>#Salutation#</Salutation>
            <FirstName>#FirstName#</FirstName>
            <MiddleName>#MiddleName#</MiddleName>
            <LastName>#LastName#</LastName>
            <BillAddress>
               <Addr1>#BAddr1#</Addr1>
               <Addr2>#BAddr2#</Addr2>
               <Addr3>#BAddr3#</Addr3>
               <Addr4>#BAddr4#</Addr4>
               <City>#BCity#</City>
               <State>#BState#</State>
               <PostalCode>#BPostalCode#</PostalCode>
               <Country>#BCountry#</Country>
            </BillAddress>
            <ShipAddress>
               <Addr1>#SAddr1#</Addr1>
               <Addr2>#SAddr2#</Addr2>
               <Addr3>#SAddr3#</Addr3>
               <Addr4>#SAddr4#</Addr4>
               <City>#SCity#</City>
               <State>#SState#</State>
               <PostalCode>#SPostalCode#</PostalCode>
               <Country>#SCountry#</Country>
            </ShipAddress>
            <Phone>#Phone#</Phone>
            <AltPhone>#AltPhone#</AltPhone>
            <Fax>#Fax#</Fax>
            <Email>#Email#</Email>
            <Contact>#Contact#</Contact>
            <AltContact>#AltContact#</AltContact>
            <OpenBalance>#OpenBalance#</OpenBalance>
            <OpenBalanceDate>#OpenBalanceDate#</OpenBalanceDate>
            <ResaleNumber>#ResaleNumber#</ResaleNumber>
            <AccountNumber>#AccountNumber#</AccountNumber>
            <CreditLimit>#CreditLimit#</CreditLimit>
            <JobStatus>#JobStatus#</JobStatus>
            <JobStartDate>#JobStartDate#</JobStartDate>
            <JobProjectedEndDate>#JobProjectedEndDate#</JobProjectedEndDate>
            <JobEndDate>#JobEndDate#</JobEndDate>
            <JobDesc>#JobDesc#</JobDesc>
         </CustomerAdd>
      </CustomerAddRq>
   </QBXMLMsgsRq>
</QBXML>";
    }
}







