using System;
using System.Collections.Generic;
using System.IO;
using Week1AcademyTest.Entities;
using Week1AcademyTest.Handler;

namespace Week1AcademyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("___ Watcher Files ___");
            FileSystemWatcher fsw = new FileSystemWatcher();

            //percorso da tenere monitorato
            fsw.Path = @"C:\Users\silvana.ombris\Desktop";

            //definisco il filtro di controllo sui file .txt
            fsw.Filter = "*.txt";

            fsw.NotifyFilter = NotifyFilters.LastWrite |
                NotifyFilters.LastAccess | NotifyFilters.FileName
                | NotifyFilters.DirectoryName;

            //Abilito le notifiche 
            fsw.EnableRaisingEvents = true;

            //Iscrizione all'evento
            fsw.Created += GestoreEvento.HandleNewTextFile;

            //Console.WriteLine("Premi q per uscire");
            //while (Console.Read() != 'q')
            //{
            //};

            List<Spesa> spese = new List<Spesa>();


            Spesa spesa = new Altro()
            {
                Data = 4,
                //Categoria = "aa",
                Descrizione = "sdf",
                Importo = 45.0

            };
            Spesa spesa2 = new Altro()
            {
                Data = 4,
                //Categoria = "aa",
                Descrizione = "sdf",
                Importo = 1000

            };

            spese.Add(spesa);
            spese.Add(spesa2);

            int i = Menu();
            while (i != 0)
            {
                AnalizzaScelta(i, spese);
                i = Menu();
            }
        }

        private static int Menu()
        {
            Console.WriteLine("1. Salva");
            Console.WriteLine("2. Approva");
            Console.WriteLine("3. Importo Rimborsato");
            Console.WriteLine("4. Salva Elaborato");
            Console.WriteLine("0. Esci");

            int scelta;
            bool succ = Int32.TryParse(Console.ReadLine(), out scelta);

            if (succ != true || (scelta < 0 || scelta > 10))
            {
                Console.WriteLine();
                Console.WriteLine("Inserisci un valore corretto.");
                Console.WriteLine();
                scelta = 99;
                // break;
            }
            return scelta;
        }

        private static void AnalizzaScelta(int scelta, List<Spesa> s)
        {
            switch (scelta)
            {
                case 1:
                    SalvaELeggi(s);
                    break;
                case 2:
                    Approva(s);
                    break;
                case 3:
                    ImportoRimborsato(s);
                    break;
                case 4:
                    SalvaElaborato(s);
                    break;
                default:
                    scelta = 0;
                    break;
            }
        }

        private static void SalvaElaborato(List<Spesa> s)
        {
            string path = Path.Combine(Environment
                .GetFolderPath(Environment.SpecialFolder.Desktop),
                "spese.txt");
            try
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    foreach (Spesa item in s)
                    {
                        if(item.ImportoRimborsato!=null)
                        {
                            writer.WriteLine(item.Data + ";" + item.Categoria + ";" + item.Descrizione + ";APPROVATA;" + item.ImportoRimborsato);
                        }
                        else
                        {
                            writer.WriteLine(item.Data + ";" + item.Categoria + ";" + item.Descrizione + ";RESPINTA");
                        }
                        
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ImportoRimborsato(List<Spesa> s)
        {
            Console.WriteLine("inseridci categoria");
            string cat = Console.ReadLine();
            Console.WriteLine("inseridci importo");
            double imp = Convert.ToDouble(Console.ReadLine());
            SpesaFactory sf = new SpesaFactory();
            Spesa nuovaSpesa = sf.GetImportoRimborsato(cat, imp);
            s.Add(nuovaSpesa);
        }

        private static void Approva(List<Spesa> s)
        {
            IHandler managerHandler = new ManagerHandler();
            IHandler opManagerHandler = new OperationManagerHandler();
            IHandler ceoHandler = new CEOHandler();

            managerHandler.SetNext(opManagerHandler).SetNext(ceoHandler);

            foreach (var item in s)
            {
                if (item != null)
                {
                    Console.WriteLine(managerHandler.Handle(item));
                }
            }
        }

        private static void SalvaELeggi(List<Spesa> s)
        {
            string path = Path.Combine(Environment
                            .GetFolderPath(Environment.SpecialFolder.Desktop),
                            "spese.txt");
            try
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    foreach (Spesa item in s)
                    {

                    writer.WriteLine(item.Data + ";" +item.Categoria + ";"+ item.Descrizione + ";" +item.Importo);
                       
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
