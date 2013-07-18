using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.AnimalMaker.Core
{
    /// <summary>
    /// Present all the exceptions happening in the <c>AnimalMaker.Core</c> library
    /// </summary>
    public class AnimalMakerException : Exception
    {
        public AnimalMakerException(string message):base(message)
        {}
    }
}
