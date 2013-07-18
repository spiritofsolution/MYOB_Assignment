using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.AnimalMaker.Core.Lib;

namespace Zoo.AnimalMaker.Test
{
    
    [TestFixture]
    public class DogTest
    {
        #region Test Instantiation
        [TestCase()]
        public void Maker_MakeADogIsNotNull_Success()
        {
            var dog = AnimalMaker.Core.AnimalFactory.Make<Dog>();
            Assert.IsNotNull(dog);
        }

        [TestCase()]
        public void Maker_MakeADog_Success()
        {
            var dog = AnimalMaker.Core.AnimalFactory.Make<Dog>();
            Assert.IsInstanceOf<Dog>(dog);
        }
        #endregion

        #region Test property getter and setter

        [TestCase()]
        public void Dog_SpeciesName_Success()
        {
            var dog = AnimalMaker.Core.AnimalFactory.Make<Dog>();
            dog.SpeciesName = "Alaskan Klee Kai";
            Assert.AreEqual("Alaskan Klee Kai", dog.SpeciesName);
        }

        [TestCase()]
        public void Dog_NumOfLegsNotNull_Success()
        {
            var dog = AnimalMaker.Core.AnimalFactory.Make<Dog>();
            dog.NumberOfLegs = 4;
            Assert.IsNotNull(dog.NumberOfLegs);
        }

        [TestCase()]
        public void Dog_NumOfLegs_Success()
        {
            var dog = AnimalMaker.Core.AnimalFactory.Make<Dog>();
            dog.NumberOfLegs = 4;
            Assert.AreEqual(4, dog.NumberOfLegs.Value);
        }

        [TestCase()]
        public void Dog_DailyFeedCost_Success()
        {
            var dog = AnimalMaker.Core.AnimalFactory.Make<Dog>();
            dog.DailyFeedCost = 10.55M;
            Assert.AreEqual(10.55M, dog.DailyFeedCost);
        }

        [TestCase()]
        public void Dog_Name_Success()
        {
            var dog = AnimalMaker.Core.AnimalFactory.Make<Dog>();
            dog.Name = "Pluto";
            Assert.AreEqual("Pluto", dog.Name);
        }
        #endregion
    }
}
