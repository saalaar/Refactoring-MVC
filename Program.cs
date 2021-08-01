using Assignment.Models;
using Assignment.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class Program
{


    public static void Main()
    {
        try
        {
            var tempPlayList = JsonConvert.DeserializeObject<PlayData>(File.ReadAllText(@"C:\Users\Salar\Desktop\Interview_\Assignment\TestFiles\Playlist1.json"));
            var invoices = JsonConvert.DeserializeObject<Invoice[]>(File.ReadAllText(@"C:\Users\Salar\Desktop\Interview_\Assignment\TestFiles\Invoice1.json"));
            Console.Write(StatementPrinter.PrinterTextStatement(invoices[0], tempPlayList));
            Console.WriteLine();
            Console.Read();
        }
        catch (Exception ex)
        {

            Console.WriteLine("!!something wrong!!!" + ex.Message.ToString()); 
        }
       
    }


}
