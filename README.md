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
To test StringCreator a unit test named StringCreatorTest was made.

In a unit test, only 1 class should be tested, and only the public functions of that class should be tested. 
If you ever feel the need to start testing some of the private functions that a class has, it might be time 
to break out those few private functions into their own class. Make only the functions that were 
previously needed public, and then you can test those public functions.

C# has a special feature called **"attributes"** that are used for the testing framework.
Some of the key attributes that I use on a regular basis are:
- [TestMethod]
- [TestClass]
- [TestIntialize]
- [TestCleanup]
- [ClassInitialize]
- [ClassCleanup]


### TestMethod

The function that follows this attribute tells the testing framework it is a test to be run.

### TestClass

The class following this attribute tells the testing framework the class contains unit tests

### TestInitialize

The function following this attribute will run before each test in a test class. I most 
commonly use it to set up a new instance of the class(*subject*) under test for each test to have a 
clean environment. Another common use for this attribute is to reduce duplicity that may
occur among multiple tests in a **TestClass**. 

### TestCleanup

The function following this attribute will run after each test in a test class. One example I 
have had for using this was an executable that acted as a server to a client program I made.
I would spin up a new, clean, version of the executable with **TestInitialize** and after each test, 
**TestCleanup** would kill the executable. 

### ClassInitialize

The function following this attribute will run before any **TestMethod** in a **TestClass**, and before **TestInitialize**.

### ClassCleanup

The function following this attribute will run after every **TestMethod** has run in a **TestClass** and before **TestCleanup**.

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

Looking at **StringCreatorTest** we can see **3** of the attributes listed above.
- TestClass
- TestInitialize
- TestMethod

The **TestClass** is the **StringCreatorTest**.
The **TestInitialize** function is named **setUp** 
The **TestMethod** is **getStringToReturn**.

The class to be tested is StringCreator and it was named **"subject"**. A common practice is to name the 
class under test, or the subject under test, **subject**. This helps readibility when a unit test may 
have multiple variable used. By having the subject under test named appropriately it is easier to focus on 
what variable is to be tested, and avoid confusion.  

In the **TestInialize** function a new instance of **StringCreator** is being applied to **subject**.
This helps keep our subject under test from keeping state. We do not want to have a subject under test shared 
among multiple tests. Every test, should always have a clean subject to make sure that the developer has full control of what state the subject under test should be in for a specific **TestMethod**.

Finally the **TestMethod** has three lines of code. There are two variables **expected**, and **actual**.
The names for those variable are common in most unit testing frameworks. The **expected** variable always has what you
expect your subject under test to do when calling a specific function from it.
The **actual** variable is the answer that *actually* came out of your subject under test.

In the example, we *expect* the string *"I expect this string to return"* to be what is returned by our subject under test.
The subject under test produces some output string that is stored in our **actual** variable.

After the expected and actual variables have been set, it is time to verify the results.
The Assert class has a function where two object can be compared. Pass in **expected**, and 
**actual** as the parameters of the Assert.AreEqual call. Every test should have a way 
to validate the success of the test. In our example, our subject under test returns something,
we are then able to compare the returned *actual* value with an *expected* value.

2. Using Interfaces on a class that depends on something else 
3. Why decoupling code is good
4. Not always having integration like tests
## List of books/resources I found useful

- Clean Code by Robert C. Martin
- Refactoring by Martin Fowler
- Test Driven Development for Embedded C by James W. Grenning
- Domain Driven Design by Eric J. Evans
- Test Driven Development by Kent Beck

## Debug later/Test After/Test Driven Development(TDD)

Grenning talks about three different methods of testing that are done in his book *Test Driven Development for Embedded C*.

### Debug Later
There is the Debug later version of testing that most developers are fond of. 
This is the testing that occurs when something breaks in your legacy code. 
You probably make a little supplemental main function that tests ***just*** the 
functions you need in ***just*** the right state for the very specific bug you are fixing. 
After some pain, and maybe hours of work, the bug is fixed, you take a deep sigh of 
relief and throw the little main function away forever. Never to look back until the next 
time something breaks and you go throw this painful cycle all over again.

### Test After
For developers new to unit testing I recommend this approach first. Really, what you should aim for is true TDD, but I think that this is a good way to get a feel for how unit testing works, why it is useful and should always be done. Unit Testing can be very complex and difficult when it's new, and that may turn some people away. 

This approach can either be done with legacy code or code you wrote yesterday that you just want to feel confident in. The point of adding the unit tests for a class is to make sure that the developer has full control, understanding, and confidence that a class is doing exactly what it was written to do. There shouldn't be any crazy things that happens because the class has fully been exhausted of its different path of execution. There should be a test for every single branch a function can go down. 

For any bugs that appear in the future, there should be a test written to make sure that does not occur again. These unit tests that are created are living documentation and alarms that let the developer know something went wrong. Any weird, special case, that caused a bug which you never anticipated, that is a test waiting to be written. 

### Test Driven Development (TDD)

TDD for me was a hard concept to buy in on. When someone mentioned testing your code automatically, I instantly agreed without question that it was brilliant and must be done. TDD I was skeptical for a long time on the way it is always taught and what it was trying to accomplish. It did not fully click until I read Grenning's book on TDD for Embedded C.

In TDD, the test is written before any code has been written. 
The test is expected to fail because no code has been written.
Then the easiest, simplest answer to make the test pass is written.
Finally the test is re-run, and hopefully your test passed.


7. Examples of Test After
