using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickbooks.Core.Models
{
    public class ResponseModel
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string ResponseString { get; set; }
    }
}
