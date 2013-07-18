using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.AnimalMaker.Core.Lib;

namespace Zoo.AnimalMaker.Test
{
    /// <summary>
    /// Test Cat animal type
    /// </summary>
    [TestFixture]
    public class CatTest
    {
        #region Test Instantiation
        [TestCase()]
        public void Maker_MakeACatIsNotNull_Success()
        {
            var cat = AnimalMaker.Core.AnimalFactory.Make<Cat>();
            Assert.IsNotNull(cat);
        }

        [TestCase()]
        public void Maker_MakeACat_Success()
        {
            var cat = AnimalMaker.Core.AnimalFactory.Make<Cat>();
            Assert.IsInstanceOf<Cat>(cat);
        }
        #endregion

        #region Test property getter and setter
        [TestCase()]
        public void Cat_SpeciesName_Success()
        {
            var cat = AnimalMaker.Core.AnimalFactory.Make<Dog>();
            cat.SpeciesName = "Birman";
            Assert.AreEqual("Birman", cat.SpeciesName);
        }

        [TestCase()]
        public void Cat_NumOfLegsNotNull_Success()
        {
            var cat = AnimalMaker.Core.AnimalFactory.Make<Dog>();
            cat.NumberOfLegs = 4;
            Assert.IsNotNull(cat.NumberOfLegs);
        }

        [TestCase()]
        public void Cat_NumOfLegs_Success()
        {
            var cat = AnimalMaker.Core.AnimalFactory.Make<Dog>();
            cat.NumberOfLegs = 4;
            Assert.AreEqual(4, cat.NumberOfLegs.Value);
        }

        [TestCase()]
        public void Cat_DailyFeedCost_Success()
        {
            var cat = AnimalMaker.Core.AnimalFactory.Make<Dog>();
            cat.DailyFeedCost = 10.55M;
            Assert.AreEqual(10.55M, cat.DailyFeedCost);
        }
        #endregion 
    }
}
