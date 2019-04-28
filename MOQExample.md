# MOQ Example

There is already a [DLL project](./SourceCode/ExampleDLLUsingMoqForMocking) and [Unit Test Project](./SourceCode/ExampleDLLUsingMoqForMockingUnitTest) 
pair created in this git repository. 

This will be a very simple example of what can be done with MOQ and mocking libraries.
For further examples and examples please go to the [MOQ Quick Start page](https://github.com/Moq/moq4/wiki/Quickstart)

In [TestingAClassThatDependsOnAnotherClass](./TestingAClassThatDependsOnAnotherClass.md) we use an interface to abstract us 
away from the actual implementation of **SalaryCalculator**. In our unit test we add a small class that implements what we 
want the **ISalaryCalculator** to really do.

Some classes may have >10 unit tests and if each unit test needs a special implementation of **ISalaryCalculator**
then we will start to have many little classes made for each test. This could easily become cumbersome and may
deter people from doing this entirely.

[MOQ](https://www.nuget.org/packages/moq/) is a mocking library for C# to aid the developer when they want to mock an object.

Instead of having to create special classes everytime a unit test needs it, you could use MOQ. 
For example [MoqExample](./SourceCode/ExampleDLLUsingMoqForMockingUnitTest/MoqExample.cs):

```[TestClass]
    public class MoqExample
    {
        AddBonusToSalaryUsingISalaryCalculator subject;
        Mock<ISalaryCalculator> mockISalaryCalculator;


        [TestInitialize]
        public void setUp()
        {
            mockISalaryCalculator = new Mock<ISalaryCalculator>();
            subject = new AddBonusToSalaryUsingISalaryCalculator(mockISalaryCalculator.Object);

        }

        [TestMethod]
        public void calculateYearlySalary_GivenSalary100e5_Return110e5()
        {
            mockISalaryCalculator.Setup(mock => mock.calculateSalary()).Returns((int)100e5);

            int expected = (int)110e5;
            int actual = subject.calculateYearlySalary();

            Assert.AreEqual(expected, actual);

        }
    }
```

We have a ```Mock<ISalaryCalculator> mockISalaryCalculator``` object.
Then it is initialized ``` mockISalaryCalculator = new Mock<ISalaryCalculator>();```.
The Moq library is creating a **Mocked** version of the ***ISalaryCalculator*

The **AddBonusToSalaryUsingISalaryCalculator** depends on an implementation of **ISalaryCalculator**.
```subject = new AddBonusToSalaryUsingISalaryCalculator(mockISalaryCalculator.Object);```

Calling **Object** on the mocked **ISalaryCalculator** is needed for the **object** to be accepted.


Now the special class that was created before to create our implementation of **ISalaryCaluculator** can actually be 
avoided by doing this ```mockISalaryCalculator.Setup(mock => mock.calculateSalary()).Returns((int)100e5);```

We are calling **Setup** and **Returns** on this mocked object.
We are basically saying, hey MOQ library I want you to **setup calculateSalary** on this mocked object, to **return** (int)100e5
everytime that I call it for this instance of **mockISalaryCalculator**.

With Moq we don't have to implement every function that the interface may have, just the functions that will be called in our test.

For example, we know that in **calculateYearlySalary** we only call **calculateSalary** from the **ISalaryCalculator** implementation.
Even if that interface had 20 other functions, MOQ wouldn't need us to **setup** those functions.

However, if you do not setup the functions that are called in the unit test for that interface, Visual Studio will get angry.
Not the end of the world, you just need to setup that function for your test to work.

By adding the Moq library to our unit test project, we have just saved a lot of code from being written and maintained.
