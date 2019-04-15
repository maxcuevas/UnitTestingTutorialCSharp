# UnitTestingTutorialCSharp

This tutorial will use Visual Studio 2017 Community Edition

## How to Create a Visual Studio DLL Project for Unit testing

1. Open Visual Studio
2. File > New > Project...
3. Visual C# > Class Library (.Net Framework)
4. Name the project something descriptive, I chose **"ExampleDllProjectForUnitTesting"**
5. Click the "OK" button to finalize the creation of the project
6. Right click the Solution
7. Add > New Project...
8. On the far left of the opened window there should be a tree like structure
9. Installed > Visual C# > Test
10. Select the **"Unit Test Project (.NET Framework)"**
11. Name the project something descriptive, I chose **"UnitTestProject"**
12. Click the **"OK"** button to create the project
13. Now you need to add your DLL project as a reference to the unit test project
14. Right Click **"UnitTestProject"**
15. Add > Reference...
16. On the far left of the new window there should be a tree structure
17. Select "Projects"
18. The middle of the window should now have the **ExampleDllProjectForUnitTesting**
19. Check the box to the left of the **ExampleDllProjectForUnitTesting**
20. Click the **"OK"** button
21. Go to any class under the **ExampleDllProjectForUnitTesting**
22. Add the following text **"[assembly: InternalsVisibleTo("<insert your unit test project's name here>")]"** like so to your project. Our example will have **"UnitTestProject"** for our unit test project.
```
[assembly: InternalsVisibleTo("UnitTestProject")]
namespace ExampleDllProjectForUnitTesting
{...}
```
23. Right Click the **"InternalsVisibleTo"** text to include the required libraries
24. You now have a skeleton of a project and a unit testing project

Note: Steps 22-23 are used to allow your UnitTestProject to see these not public classes and therefore be able to unit test them.





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

You have written your first test. Let's go over what just happened.

There was a class created named StringCreator that did something very simple, returns a string.


2. Using Interfaces on a class that depends on something else 
3. Why decoupling code is good
4. Not always having integration like tests
## List of books/resources I found useful

- Clean Code by Robert C. Martin
- Refactoring by Martin Fowler
- Test Driven Development for Embedded C by James W. Grenning
- Domain Driven Design by Eric J. Evans
- Test Driven Development by Kent Beck

6. Debug later/Test After/TDD
7. Examples of Test After
