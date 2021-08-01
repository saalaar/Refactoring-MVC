using Assignment.Models;
using Assignment.View;
using NUnit.Framework;


namespace Asignment.Test
{
    public class Tests
    {
        private PlayData plays = new PlayData()
        {
            hamlet = new Play { Name = "Hamlet", Type = "tragedy" },
            aslike = new Play { Name = "As You Like It", Type = "comedy" },
            othello = new Play { Name = "Othello", Type = "tragedy" }
        };
        Invoice[] invoices = new Invoice[1];


        [SetUp]
        public void Setup()
        {

            var x = new Performance { PlayId = "hamlet", Audience = 55 };
            var y = new Performance { PlayId = "aslike", Audience = 35 };
            var z = new Performance { PlayId = "othello", Audience = 40 };

            invoices[0] = new Invoice
            {
                Customer = "BigCo",
                Performances = new Performance[3]
            };
            invoices[0].Performances[0] = x;
            invoices[0].Performances[1] = y;
            invoices[0].Performances[2] = z;
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }


        [Test]
        public void ShouldReturnValidBillPlainText()
        {
            Setup();
            var expected = "PlainTextStatement for BigCo\n  Hamlet: $650.00 (55 seats)\n  As You Like It: $580.00 (35 seats)\n  Othello: $500.00 (40 seats)\nAmount owed is $1,730.00\nYou earned 47 credits";

            var actual = StatementPrinter.PrinterTextStatement(invoices[0], plays);

            Assert.Equals(expected, actual);
        }
    }
}