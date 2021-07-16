using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1AcademyTest.Entities
{
    public class Altro : Spesa
    {
        public int Data { get; set; }
        public string Categoria { get; set; } = "Altro";
        public string Descrizione { get; set; }
        public double Importo { get; set; }
        public double ImportoRimborsato { get; set; }
        public bool Approvato { get; set; } = false;
        public void LoadToFile(string fileName)
        {
            string path = null;
            try
            {
                string aux = fileName + ".txt";
                path = Path.Combine(@"C:\Users\silvana.ombris\Desktop", aux);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            string line;
            Altro altro = new Altro();
            try
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(";");

                        altro.Data = Convert.ToInt32(values[0]);
                        altro.Categoria = values[1];
                        altro.Descrizione = values[2];
                        altro.Importo = Convert.ToDouble(values[3]);
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SaveToFile(string fileName)
        {
            string filePath = null;
            try
            {
                string aux = fileName + ".txt";
                filePath = Path.Combine(@"C:\Users\silvana.ombris\Desktop", aux);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            StreamWriter file = null;
            try
            {
                using (file = File.CreateText(filePath))
                {
                    file.WriteLine($"{this.Data};{this.Categoria};{this.Descrizione};{this.Importo}");
                }
                Console.WriteLine("Stampa eseguita con successo");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                file.Close();
            }
        }
    }
}
