using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1AcademyTest.Entities;

namespace Week1AcademyTest
{
    public class SpesaFactory
    {
        public Spesa GetImportoRimborsato(string categoria, double importo)
        {
            Spesa spesa = null;

            switch (categoria)
            {
                case "Viaggio":
                    spesa = new Viaggio();
                    spesa.Importo = importo;
                    spesa.ImportoRimborsato = importo + 50;
                    break;
                case "Alloggio":
                    spesa = new Alloggio();
                    spesa.Importo = importo;
                    spesa.ImportoRimborsato = importo;
                    break;
                case "Vitto":
                    spesa = new Vitto();
                    spesa.Importo = importo;
                    spesa.ImportoRimborsato = (importo/100) * 70;
                    break;
                case "Altro":
                    spesa = new Altro();
                    spesa.Importo = importo;
                    spesa.ImportoRimborsato = (importo / 100) * 10;
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }

            return spesa;
        }
    }
}
