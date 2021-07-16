using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1AcademyTest.Handler
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        string Handle(Spesa spesa);
    }
}
