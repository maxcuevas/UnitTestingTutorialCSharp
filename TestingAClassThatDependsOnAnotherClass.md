## Testing A Class That Depends On Another Class

Navigate to the following project [**"ExampleDLLProjectForUnitTestDependingOnAnotherClass"**](./SourceCode/ExampleDLLProjectForUnitTestDependingOnAnotherClass) 

The specific classes to look at are
- **SalaryCalculator**
- **AddsBonusToSalary**

**SalaryCalculator** is a simple class that does some *time intensive* calculations to produce a salary.
**AddsBonusToSalary** is a class that depends on **SalaryClculator**. **AddsBonusToSalary** will take a salary and a bonus to the salary that was provided.

Navigate to the following Unit Test Project [**"UnitTestClassesWithDependencies"**](./SourceCode/UnitTestClassesWithDependencies)
The class to look at is **AddsBonusToSalaryTest**

The test is simple, just making sure that the expected salary + bonus is correct. 
To make a real instance of **AddsBonusToSalary** we had to create a real instance of **SalaryCalculator**.

For anyone who has either read the code, or ran the unit tests, it takes ~5 seconds to run. This is because part of the code 
has a sleep for 5 seconds. This is just an example of time intensive code that could happen in the real world.

Imagine having 60 unit tests, and each unit test take ~5 seconds. Running all of the tests would take 300 seconds, or 5 minutes.
This would slow down development and lead to people running tests less frequently.

This is not a true *Unit* test. A true unit test of **AddsBonusToSalary** would only test the functionality 
of the **AddsBonusToSalary** class and nothing else.

An example of actually only testing **AddsBonusToSalary** is next.

In [**"ExampleDLLProjectForUnitTestDependingOnAnotherClass"**](./SourceCode/ExampleDLLProjectForUnitTestDependingOnAnotherClass) 
there is an interface class **ISalaryCalculator** and **SalaryCalculator** implements the interface. 
The  **AddBonusToSalaryUsingISalarayCalculator** depends on the interface **ISalaryCalculator** instead of **SalaryCalculator**. 

Before we move on, what is the point of an interface?
The interface allows a developer to abstract functions from the actual implementation of a function.
A unit test should only test the class it is trying to test. If the class has dependencies on other classes,
it would be nice to have our own implementation of those functions, to provide exactly what we want, when we want it.

Now go to the unit test project [**"UnitTestClassesWithDependencies"**](./SourceCode/UnitTestClassesWithDependencies)
and look at the **AddsBonusToSalaryUsingISalaryCalculatorTest** class.

There is a public class that was added to the bottom of the unit test class named **MySalaryCalculator**. The
**ISalaryCalculator** was implemented in the **MySalaryCalculator** class. This gives the developer full control of what is 
needed for the **AddBonusToSalary** unit test.

This is a unit test. We don't worry about other classes, only worry about testing the functionality of the class at hand.
