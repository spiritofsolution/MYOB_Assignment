using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Zoo.AnimalMaker.Core.Lib;

namespace Zoo.AnimalMaker.Core
{
    public static class AnimalFactory
    {
        /// <summary>
        /// Register all animal types when calling any static API for the first time.
        /// </summary>
        static AnimalFactory()
        {
            RegisterAnimals();
        }

        /// <summary>
        /// Used to register all the concrete animals implemented in the <c>IAnimal </c> assembly in the <c>IoCContainer</c>
        /// </summary>
        private static void RegisterAnimals()
        {
            Assembly animalsLib = typeof(IAnimal).Assembly;
            // Find all animal types in the IAnimal assembly.
            Type[] animalTypes = animalsLib.GetTypes().Where(t => t.IsClass && !t.IsAbstract && typeof(IAnimal).IsAssignableFrom(t)).ToArray();

            if (animalTypes != null)
            {
                // Register found animals in the IoCContainer.
                foreach (var animalType in animalTypes)
                {
                    IoCContainer.Register(animalType, animalType);
                }
            }
        }


        /// <summary>
        /// Used to create object from the provided animal type.
        /// </summary>
        /// <typeparam name="T">Target animal type.</typeparam>
        /// <returns>Animal object</returns>
        public static IAnimal Make<T>() where T : IAnimal
        {
            return IoCContainer.Resolve<T>();
        }
    }
}
