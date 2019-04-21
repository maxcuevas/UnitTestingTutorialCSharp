## Simple Unit Test in C#

1. Add a class named **"StringCreator"** to the project **ExampleDLLProjectForUnitTesting**
    1. Right Click **ExampleDLLProjectForUnitTesting** > Add > Class... > Name the class **"StringCreator"**
2. Replace the default code in the **StringCreator** class with the following:

```namespace ExampleDLLProjectForUnitTesting
{
     class StringCreator
    {
        public string getStringToReturn(string stringToReturn)
        {
            return stringToReturn;
        }
    }
}
```

3. Add a unit test named **"StringCreatorTest"** to the project **UnitTestProject**
    1. Right Click **UnitTestProject** > Add > New Item... 
    2. Visual C# Items> Test > Basic Unit Test > Name the unit test **"StringCreatorTest"**
4. Replace the code in the unit test **StringCreatorTest** with the following:

```
using System;
using ExampleDLLProjectForUnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class StringCreatorTest
    {
        private StringCreator subject;

        [TestInitialize]
        public void setUp() {
            subject = new StringCreator();
        }

        [TestMethod]
        public void getStringToReturn()
        {

            string expected = "I expect this string to return";
            string actual = subject.getStringToReturn(expected);

            Assert.AreEqual(expected, actual);
        }
    }
}
```

*Note: If StringCreator does not work(is not a class that the unit test can access) make sure that the ExampleDLLProjectForUnitTesting was added as a reference to the UnitTestProject*

5. Go the Menu Bar at the top of the Visual Studio IDE
6. Test > Run > All Tests
7. On the Left side of the IDE a panel named **Test Explorer** should appear with a **green** check next to the test **UnitTestProject**
