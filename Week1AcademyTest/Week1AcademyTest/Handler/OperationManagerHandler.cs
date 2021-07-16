using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1AcademyTest.Handler
{
    public class OperationManagerHandler : AbstractHandler
    {
        public override string Handle(Spesa spesa)
        {
            if (spesa.Importo > 400 && spesa.Importo <= 1000)
            {

                return "Operation Manager";
            }
            else
                return base.Handle(spesa);
        }

    }
}
