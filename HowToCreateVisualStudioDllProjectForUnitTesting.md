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
