using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models.ValueObject
{
    public class Email
    {
        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; set; }
    }
}
