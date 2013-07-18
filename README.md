## MYOB_Assignment - Animal library for Acme Zoo

Below are all the modifications and enhancements made on the original “Acme Zoo” library.

###1- Architecture Changes
* Moved the implementation of the data objects “The animals” to separate assembly called “Zoo.AnimalMaker.Core.Lib”. The target from this change is to loos couple the relationship between the data object im p lementation and the logic of the animal making, so no recompilation for the maker is needed when adding new animals.
* Introduced abstract class called “AnimalBase” which sits between the “IAnimal” interface and the animal concrete implementation. The goal from this change is to provide a basic implementation for the common animal properties.

###2- Component design additions/changes
* Renamed the “TypeName”  property in the “IAnimal” interface to “SpeciesName”, the reason is to differentiate between the class type name which can be retrieved from the “Type.FullName” property and the animal type from business perspective. 
* Added “Name” property to the “IAnimal”. This property is added to be used to identify the object by the consuming applications. This will be useful to identify the animals inside collections. 
* Implemented a light weight IoC container to handle the actual animal object instantiation. This component is implemented as static class with the two following APIs
  ```
  - Void Register(Type tFrom, Type tTo)
  
    Used to register the concrete animal types defined in the animals library.
  ```
  ```
  - T Resolve<T>()
  
    Used to instantiate an object from the required animal using its default constructor.
  ```
* Implemented custom exception type for the animal maker to throw when needed. The class directly inherits from “Exception” and it is called “AnimalMakerException”. All exception messages are stored in resource file called “ExceptionMessage.resx” 
* The animal maker is implemented as static class called “AnimalFactory.cs”. The static constructor of the class call private function which register all the concrete animals defined in the “IAnimal” assemble in the IoC Container. The animal make hosts only one static API “Make” which is used to call the IoC Container “Resolve” API and pass the created object to the caller, this API can only be used to create objects from concrete (not virtual) types that implement “IAnimal”.

###3- Unit test cases
* Split the unit test cases between two fixtures, CateTest and DogTest. The reason behind this is to increase the maintainability of the files.
* Added test cases to test that the set and get of each property is properly working.

###4- Removed features
* The constructor of the Dog and Cat objects were setting default values for the TypeName, DailyFeedCost and NumberOfLegs which I removed for the following reasons
  - The requirements mentioned that our task is to create a pluggable library that can be used by the customer to create animal objects without mentioning default values for any type of animal. 
  - All the properties have get and set defined by the interface which means that the caller can set the values after initialization.
* Removed the “IMaker” interface as I founded it not needed after applying the above mentioned modifications.
* Removed the “Maker” class because it’s functionally has been fully overridden by the “AnimalFactory” class.
