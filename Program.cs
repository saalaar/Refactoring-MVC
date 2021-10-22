using Assignment.Models;
using Assignment.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

public class Program
{
    public static void Main()
    {
            try
            {
                ///get Address of json relative path in bin folder
                string currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string invoicesfileLocation = Path.Combine(currentDirectory, "Invoice1.json");
                string playlistfileLocation = Path.Combine(currentDirectory, "Playlist1.json");



                var tempPlayList = JsonConvert.DeserializeObject<PlayData>(File.ReadAllText(playlistfileLocation));
                var invoices = JsonConvert.DeserializeObject<Invoice[]>(File.ReadAllText(invoicesfileLocation));
                //if you want to set the file path static in TestFiles of project , uncomment this lines in your sytem path
                //var tempPlayList = JsonConvert.DeserializeObject<PlayData>(File.ReadAllText(@"C:\Users\TestFiles\Playlist1.json"));
                //var invoices = JsonConvert.DeserializeObject<Invoice[]>(File.ReadAllText(@"C:\Users\TestFiles\Invoice1.json"));
                Console.Write(StatementPrinter.PrinterTextStatement(invoices[0], tempPlayList));
                Console.WriteLine();
                Console.Read();
            }

            catch (Exception ex)
            {
                Console.WriteLine("!!something wrong in main!!!" + ex.Message.ToString());
            }

        }
    }

