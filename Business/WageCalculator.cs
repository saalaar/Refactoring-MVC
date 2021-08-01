using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Assignment.Business
{
    public class WageCalculator
    {
        public Play Play { get; set; }
        public Performance Performance { get; set; }
        public WageCalculator(Performance aPerformance, Play aPlay)
        {
            Performance = aPerformance;
            Play = aPlay;
        }

        public virtual int Amount() 
        {
            return 1;
        }
        public virtual int LoyaltyCredits()
        {
            try
            {
                var result = 0;
                result += Math.Max(Performance.Audience - 30, 0);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!something wrong loyaltycredit!!!" + ex.Message.ToString()); 
                return 0;
            }
            
        }
    }
}
