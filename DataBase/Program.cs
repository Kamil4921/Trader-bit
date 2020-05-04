using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Models;

namespace DataBase
{
    class Program
    {
        static void Main()
        {
            using var context = new TraderContext();
            var indexes = new List<long> { };

            string data_directory = @"D:\studia\NETiJava\Fintech\DATA\BitBay";
            var paths = Directory.EnumerateFiles(data_directory, "BTCPLN*.json");

            foreach (string path in paths.Take(3))
            {
                Console.WriteLine(path);
                string jsonString = File.ReadAllText(path);
                var trades = JsonConvert.DeserializeObject<Trade[]>(jsonString);
                foreach (var trade in trades)
                {
                    if (!context.Trades.Any(t => t.Tid == trade.Tid)
                        && !indexes.Contains(trade.Tid))
                    {
                        indexes.Add(trade.Tid);
                        context.Trades.Add(trade);
                    }
                }
                context.SaveChanges();
                indexes.Clear();
            }
        }
    }
}
