using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1AcademyTest.Handler
{
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;
        public virtual string Handle(Spesa spesa)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(spesa);
            }
            else
            {
                return null;
            }
        }

        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }
    }
}
