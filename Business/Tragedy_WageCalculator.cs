using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Business
{
    public class Tragedy_WageCalculator :WageCalculator
    {
        public Tragedy_WageCalculator(Performance aPerformance, Play aPlay) : base(aPerformance, aPlay) { }

        public override int Amount()
        {
            try
            {
                var result = 40000;
                if (Performance.Audience > 30)
                {
                    result += 1000 * (Performance.Audience - 30);
                }

                return result;
            }
            catch (Exception ex )
            {
                Console.WriteLine("!! in Tragedy calaculation something wrong!!!" + ex.Message.ToString()); 
                return 0;
            }
           
        }
    }
}
