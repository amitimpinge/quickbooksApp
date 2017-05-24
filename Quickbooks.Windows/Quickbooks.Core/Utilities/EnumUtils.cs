using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickbooks.Core.Utilities
{
    public class EnumUtils
    {
        public enum QuickBooksRequests
        {
            CustomerList = 1,
            CustomerDetails = 2
        }

        public enum RequestMethod
        {
            GET = 1,
            POST = 2
        }
    }
}
