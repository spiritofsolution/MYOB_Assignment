using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.AnimalMaker.Core.Lib
{
    /// <summary>
    /// Provide basic implementation for the common attributes of the animals
    /// </summary>
    public abstract class AnimalBase:IAnimal
    {
        public virtual string SpeciesName
        {
            get;
            set;
        }
        public virtual int? NumberOfLegs
        {
            get;
            set;
        }
        public virtual decimal DailyFeedCost
        {
            get;
            set;
        }
    }
}
