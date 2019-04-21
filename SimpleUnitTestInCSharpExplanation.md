## Explanation of the SimpleUnitTestInCSharp

Let's go over what happened in [SimpleUnitTestInCSharp.md.](./SimpleUnitTestInCSharp.md)

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
