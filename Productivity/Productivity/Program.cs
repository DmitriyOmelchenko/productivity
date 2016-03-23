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
                //dostup k failu
                
                string path = args[0];

                if (File.Exists(path))
                {
                    Dictionary<DateTime, int> Data = new Dictionary<DateTime, int>();
                    StreamReader sr = new StreamReader(path);
                    string line; 
                    //formiruem danue dlya sravn
                    while ((line=sr.ReadLine())!=null)
                    {
                        char[] separator = { ' ', '\n' };
                        string[] danuestroki = line.Split(separator);
                        int summ = 0;
                        DateTime currdate;
                        //summa pokazatelei
                        for (int i = 1; i < danuestroki.Length; i++)
                        {
                            int curr;
                            //  Console.Write("s[{0}]={1}", i, danuestroki[i]);
                            if (int.TryParse(danuestroki[i],out curr ))
                            {
                                summ+= curr;
                            }   
                          

                        }
                        //dobavl
                        if (DateTime.TryParse(danuestroki[0],out currdate))
                        {
                            Data.Add(currdate,summ);
                        }
                      
                    }

                    StringBuilder Most = new StringBuilder("Most productive day: ");
                    StringBuilder Least = new StringBuilder("Least productive day: ");
                    StringBuilder Average = new StringBuilder("Average packages per day:");
                    int Max = Data.First(x => x.Value == Data.Values.Max()).Value;
                    int Min = Data.First(x => x.Value == Data.Values.Min()).Value;
                    var Aver = Data.Average(x => x.Value);
                    Average.Append(Aver);
                    int maxcount = 0, mincount = 0;
                    foreach (var item in Data)
                    {//макс знач
                       // Console.WriteLine("day {0} value {1}",item.Key,item.Value);
                        if (item.Value==Max)
                        {
                            maxcount++;
                            Most.Append(item.Key.ToString("dd.MM.yyyy "));
                            Most.Append(item.Value);
                            if (maxcount>1)
                            {
                                Most.Append(",");
                            }
                        }
                        if (item.Value == Min)
                        {
                            mincount++;
                            Least.Append(item.Key.ToString("dd.MM.yyyy "));
                            Least.Append(item.Value);
                            if (maxcount > 1)
                            {
                                Least.Append(",");
                            }
                        }

                    }
                    Console.WriteLine(Most);
                    Console.WriteLine(Least);
                    Console.WriteLine(Average);

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
