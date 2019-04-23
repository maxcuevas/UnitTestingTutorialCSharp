# UnitTestingTutorialCSharp

This tutorial will use Visual Studio 2017 Community Edition

## Testing A Class That Depends On Another Class

1. Navigate to the following project [**"ExampleDLLProjectForUnitTestDependingOnAnotherClass"**](./SourceCode/ExampleDLLProjectForUnitTestDependingOnAnotherClass) 
2. The specific classes to look at are
- **SalaryCalculator**
- **AddsBonusToSalary**

**SalaryCalculator** is a simple class that does some *time intensive* calculations to produce a salary.
**AddsBonusToSalary** is a class that depends on **SalaryClculator**. **AddsBonusToSalary** will take a salary and a bonus to the salary that was provided.

3. Navigate to the following Unit Test Project [**"UnitTestClassesWithDependencies"**](./SourceCode/UnitTestClassesWithDependencies)
4. The class to look at is **AddsBonusToSalaryTest**

The test is simple, just making sure that the expected salary + bonus is correct. 
To make a real instance of **AddsBonusToSalary** we had to create a real instance of **SalaryCalculator**.
For anyone who has either read the code, or ran the unit tests, it takes ~5 seconds to run. This is because part of the code 
has a sleep for 5 seconds. This is just an example of time intensive code that could happen in the real world.

Imagine having 60 unit tests, and each unit test take ~5 seconds. Running all of the tests would take 300 seconds, or 5 minutes.
This would slow down development and lead to people running tests less frequently.

This is not a true *Unit* test. A true unit test of **AddsBonusToSalary** would only test the functionality of the **AddsBonusToSalary** class and nothing else.




2. Using Interfaces on a class that depends on something else 
3. Why decoupling code is good
4. Not always having integration like tests
7. Examples of Test After
