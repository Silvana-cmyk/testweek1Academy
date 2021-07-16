using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1AcademyTest.Entities
{
    public class Alloggio : Spesa
    {
        public int Data { get; set; }
        public string Categoria { get; set; } = "Alloggio";
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
            Alloggio alloggio = new Alloggio();
            try
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(";");

                        alloggio.Data = Convert.ToInt32(values[0]);
                        alloggio.Categoria = values[1];
                        alloggio.Descrizione = values[2];
                        alloggio.Importo = Convert.ToDouble(values[3]);
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