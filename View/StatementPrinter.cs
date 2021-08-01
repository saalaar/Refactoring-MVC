using Assignment.Business;
using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;


namespace Assignment.View
{
    public class StatementPrinter
    {

        private static string Usd(double aNumber)
        {
            return (aNumber / 100).ToString("c", new CultureInfo("en-US"));
        } 
        private static WageCalculator PerformanceCalculatorBuilder(Performance aPerformance, Play aPlay)
        {
            switch (aPlay.Type)
            {
                case "tragedy": return new Tragedy_WageCalculator(aPerformance, aPlay);
                case "comedy": return new Comedy_WageCalculator(aPerformance, aPlay);             
                default:  throw new Exception($"Unknown type of paly: {aPlay.Type}");

            }
        }

        private static Dictionary<string, object> StatementDataBuilder(Invoice invoice, PlayData playlist)
        {
            Play PlayFor(Performance aPerformance) 
            {
               return  (Play)playlist.GetType().GetProperty(aPerformance.PlayId)?.GetValue(playlist, null);
            }
               

            Performance EnrichPerformance(Performance aPerformance)
            {
                var calculator = PerformanceCalculatorBuilder(aPerformance, PlayFor(aPerformance));
                var result = new Performance
                {
                    Audience = aPerformance.Audience,
                    PlayId = aPerformance.PlayId,
                    Play = calculator.Play,
                    Amount = calculator.Amount(),
                    LoyaltyCredits = calculator.LoyaltyCredits()
                };
                return result;
            }

            double TotalAmount(Dictionary<string, object> data) =>
                ((Performance[])data["Performances"]).Aggregate<Performance, double>(0,
                    (current, perf) => current + perf.Amount);

            double TotalLoyaltyCredits(Dictionary<string, object> data) =>
                ((Performance[])data["Performances"]).Sum(perf => perf.LoyaltyCredits);
            {
                var result = new Dictionary<string, object>();
                result.Add("Customer", invoice.Customer);
                result.Add("Performances", invoice.Performances.Select(EnrichPerformance).ToArray());
                result.Add("TotalAmount", TotalAmount(result));
                result.Add("TotalLoyaltyCredits", TotalLoyaltyCredits(result));
                return result;
            }
        }

        private static string RenderPrinterText(Dictionary<string, object> data)
        {
            var result = $"PlainTextStatement for {data["Customer"]}\n";
            result = ((Performance[])data["Performances"])
                .Aggregate(result, (current, perf) =>
                    current + $"  {perf.Play.Name}: {Usd(perf.Amount)} ({perf.Audience} seats)\n");
            result += $"Amount owed is {Usd((double)data["TotalAmount"])}\n";
            result += $"You earned {(double)data["TotalLoyaltyCredits"]} credits";
            return result;
        }

        public static string PrinterTextStatement(Invoice invoice, PlayData playlist)
        {
            return RenderPrinterText(StatementDataBuilder(invoice, playlist));
        }
        
    }
}
