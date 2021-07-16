using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1AcademyTest
{
    public interface Spesa
    {
        public int Data { get; set; }
        public string Descrizione { get; set; }
        public string Categoria { get; set; }
        public double Importo { get; set; }
        public double ImportoRimborsato { get; set; }
        public void LoadToFile(string fileName);
        public void SaveToFile(string fileName);
    }
}
