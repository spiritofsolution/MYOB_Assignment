using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.AnimalMaker.Core.Lib
{
    /// <summary>
    /// Provide interface definition for an animal.
    /// </summary>
    public interface IAnimal
    {
        string SpeciesName { get; set; }
        int? NumberOfLegs { get; set; }
        decimal DailyFeedCost { get; set; }
    }
}
