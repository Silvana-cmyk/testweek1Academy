using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1AcademyTest
{
    public static class GestoreEvento
    {
        public static void HandleNewTextFile(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Un nuovo file è stato appena creato {0}", e.Name);

            try
            {
                //Lettura da file
                using (StreamReader reader = File.OpenText(e.FullPath))
                {
                    Console.WriteLine($"Contenuto del file {e.Name}");
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = reader.ReadLine();
                    }

                    Console.WriteLine("\t Fine del file");
                    Console.WriteLine("\n");
                }

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Scrittura su file
            string path = @"C:\Users\silvana.ombris\Desktop";

            try
            {
                using (StreamWriter writer = File.CreateText(e.FullPath + @"\scritturaFile.txt"))
                {
                    writer.WriteLine($"Lettura {e.Name} scrittura da file completata");
                    writer.WriteLine($"{e.ChangeType.ToString()}");
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}

