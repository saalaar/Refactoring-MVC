using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Assignment.Models
{
    public class Performance
    {
        public string PlayId { get; set; }
        public int Audience { get; set; }
        public Play Play { get; set; }
        public double Amount { get; set; }
        public int LoyaltyCredits { get; set; }
    }
}
