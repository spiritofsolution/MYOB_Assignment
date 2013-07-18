using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.AnimalMaker.Core.Resources;

namespace Zoo.AnimalMaker.Core
{
    /// <summary>
    /// An IoC container
    /// </summary>
    public class IoCContainer
    {
        /// <summary>
        /// Configuration map.
        /// </summary>
        private static readonly Dictionary<Type, Type> map = new Dictionary<Type, Type>();

        /// <summary>
        /// Add type to the configuration map.
        /// </summary>
        /// <typeparam name="tFrom">Interface type.</typeparam>
        /// <typeparam name="tTo">Concrete implementation type.</typeparam>
        public static void Register(Type tFrom, Type tTo)
        {
            // Type can only be registered once.
            if (map.ContainsKey(tFrom))
                throw new AnimalMakerException(string.Format(ExceptionMessage.ExistingType, tFrom.FullName));

            // Add type to the configuration map.
            map.Add(tFrom, tTo);
        }

        /// <summary>
        /// Object resolving API.
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <returns>Object from the <c>Type T</c></returns>
        public static T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        /// <summary>
        /// Initialize object from the requested type using the default constructor.
        /// </summary>
        /// <param name="requestedType">Target type.</param>
        /// <returns>Object implementing the requested type.</returns>
        private static object Resolve(Type requestedType)
        {
            // Verify the existence of the requested animal
            Type targetType;
            if (map.ContainsKey(requestedType))
                targetType = map[requestedType];
            else
                throw new AnimalMakerException(string.Format(ExceptionMessage.DoesNotExists, requestedType.FullName));

            // Get the default constructor.
            var constructor = targetType.GetConstructors().Where(cnt => cnt.GetParameters().Count() == 0).FirstOrDefault();

            if (constructor != null)
            {
                return Activator.CreateInstance(targetType);
            }
            else
                throw new AnimalMakerException(string.Format(ExceptionMessage.DefaultConstructorNeeded, requestedType.FullName));
        }
    }
}
