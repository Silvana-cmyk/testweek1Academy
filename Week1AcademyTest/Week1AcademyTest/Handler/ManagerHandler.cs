using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1AcademyTest.Handler
{
    public class ManagerHandler : AbstractHandler
    {
        public override string Handle(Spesa spesa)
        {
            if (spesa.Importo <= 400)
            {

                return "Manager";
            }
            else
                return base.Handle(spesa);
        }

    }
}

