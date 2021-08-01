using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Assignment.Models
{
    public class Invoice
    {
        public string Customer { get; set; }
        public Performance[] Performances { get; set; }
    }
}
