using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Assignment.Business
{
    public class Comedy_WageCalculator:WageCalculator
    {
        public Comedy_WageCalculator(Performance aPerformance, Play aPlay) : base(aPerformance, aPlay) { }
        public override int Amount()
        {
            try
            {
                var result = 30000;
                if (Performance.Audience > 20)
                {
                    result += 10000 + 500 * (Performance.Audience - 20);
                }
                result += 300 * Performance.Audience;
                return result;
            }
            catch (Exception ex)
            {

                Console.WriteLine("!!Comedy calaculation something wrong!!!" + ex.Message.ToString());
                return 0;
            }
          
        }

        public override int LoyaltyCredits()
        {
            return base.LoyaltyCredits() + (int)Math.Floor(Performance.Audience / (double)5);
        }
        
    }
}
