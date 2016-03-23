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
                StringBuilder s = new StringBuilder();
                foreach (var item in args)
                {
                    s.Append(item);
                }
                string path = s.ToString();
                
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
            Console.ReadKey();
        }
    }
}
