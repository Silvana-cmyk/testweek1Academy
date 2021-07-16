using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1AcademyTest.Handler
{
    class CEOHandler : AbstractHandler
    {
        public override string Handle(Spesa spesa)
        {
            if (spesa.Importo > 1000 && spesa.Importo <= 2500)
            {

                return "CEO";
            }
            else
                return base.Handle(spesa);
        }
    }
}
