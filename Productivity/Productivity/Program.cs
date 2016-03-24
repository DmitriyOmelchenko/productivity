using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Productivity
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            if (args.Length!=0)
            { 
                //file path 
                string filePath = args[0];

                if (File.Exists(filePath))
                {
                    Dictionary<string, int> resultDictionary = new Dictionary<string, int>();
                    //get data from file
                    foreach (var line in File.ReadAllLines(filePath))
                    {
                        var lineSplitted = line.Split(new[] { ' ', '\n', '\t' },StringSplitOptions.RemoveEmptyEntries);
                        
                        if (lineSplitted.Length<2)
                        {
                            continue;
                        }
                        var lineDay = lineSplitted.First();
                        //prodactivity per day
                        
                        var lineSum = lineSplitted.Skip(1).Select(int.Parse).Sum();
                        resultDictionary.Add(lineDay, lineSum);
                    }

                    var maxProductiveDays =  resultDictionary.Where(d => d.Value == resultDictionary.Values.Max()).ToDictionary(d => d.Key, d => d.Value);

                    var leastProductiveDays = resultDictionary.Where(d=>d.Value==resultDictionary.Values.Min()).ToDictionary(d=>d.Key,d=>d.Value);

                    var averageProductivity = resultDictionary.Values.Average();

                    Console.WriteLine("Max productive day:" + " ({0}) {1}", maxProductiveDays.Values.First(), string.Join(",", maxProductiveDays.Select(d => d.Key)));
                    Console.WriteLine("Least productive day: " + " ({0}) {1}", leastProductiveDays.Values.First(), string.Join(",", leastProductiveDays.Select(d => d.Key)));
                    Console.WriteLine("Averag productivity: {0:0.000}", averageProductivity);
                }
                else
                {
                    Console.WriteLine("File do not exsists");
                }
               
            }
            else
            {
                Console.WriteLine("Faild pass");
            }
            ConsoleKeyInfo cki;
            Console.WriteLine("Press Enter for exit");
            do
            {
                cki = Console.ReadKey(true);
            } while (cki.Key != ConsoleKey.Enter);
            
           
        }
    }
}
