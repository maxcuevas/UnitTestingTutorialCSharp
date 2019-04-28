# Preparing For MOQ library Without Internet

I have already created a project with the code and set up for using the MOQ library. 

For our example code, I have already included the necessary [DLLs](https://github.com/maxcuevas/UnitTestingTutorialCSharp/tree/master/SourceCode/DLLSForMoq) 
in this git project and referrenced the DLLs in the Unit Test Project. 

This section is for anyone who would like to get MOQ working from scratch or as a reference.

## NUGET PACKAGES

[NUGET] (https://www.nuget.org/packages) is a package manager created by Microsoft for people to store their packages/DLLs.
[MOQ](https://www.nuget.org/packages/moq/) is where we can manually download the NUGET packages. 

There is a really easy way of acquiring NUGET packages if the internet is available. I am going to assume the internet is 
not available in my example.

1. Go to [MOQ](https://www.nuget.org/packages/moq/) 
2. On the far right of the page there is a link that says **"Download Package"**, click it to download the package
    - This link provides a NUGET package
3. There is a big header that says **"Dependencies"** towards the middle of the page    
4. Click the arrow to the left of the **Dependencies Text**
5. There should now be a label that says **".NETFramework 4.5"** 
    - Everything lists below the **.NETFramework 4.5** are other NUGET packages that MOQ depends on
6. Right Click on the first dependency **"Castle.Core"** and open the link on a new tab
7. Right Click on the second dependency **"System.Threading.Tasks.Extensions"** and open the link on a new tab
8. Download the **Castle.Core** NUGET package by clicking the **Download package** text
9. Check the dependencies of **Castle.Core**
10. For **.NETFramework 4.5** it says **"No Dependencies"**
11. Download the **System.Threading.Tasks.Extensions** NUGET package
12. Check the dependencies of **System.Threading.Tasks.Extensions**
13. Under **.NETFramework 4.5** there is one dependency **"System.Runtime.CompilerServices.Unsafe"**
14. Open **System.Runtime.CompilerServices.Unsafe** in a new tab
15. Download the **System.Runtime.CompilerServices.Unsafe** NUGET package
16. Check dependencies for **System.Runtime.CompilerServices.Unsafe**
17. For **.NETFramework 4.5** it says **"No dependencies"**

You have all the packages necessary to use MOQ now.
However, you need the DLLs contained inside the package

1. Go to the folder where all the packages have been downloaded
2. One by one unzip each NUGET package
    - The NUGET package does not need to be changed or have its extension altered, it can be unziped as is
    - I used 7zip to unzip the NUGET package
3. Each new folder should have a **"lib"** folder
4. There will either be a **"net45"** folder or a **"netstandard2.0"** folder in the **lib** folder
5. In either of those folder there should be a DLL file that needs to be referenced by the project
6. I would recommened a making a folder with the DLLs needed

Finally you need to reference those DLLs in your project

1. Create any C# project, I will use a DLL project as my example.
2. On the far right of Visual Studio there is a pane titled **"Solution Explorer"**
3. You should see your **Solution**, then below you **Project**
4. Click the arrow to the left of the Porject name to show what is contained in the project
5. There should be a label named **"References"**
6. Right Click **References** > Add Reference... 
7. A window should appear titled **"Reference Manager"**
8. On the far left of the window there should be a few labels
9. One of the labels should be **"Browse"**
10. Click **Browse**
11. On the far bottom right of the window there should be a button named **"Browse..."**
12. Click the button
13. Navigate to where all of the DLLs needed to use MOQ are
14. You can select all of the DDLs at once
    - Castle.Core.dll
    - Moq.dll
    - System.Runtime.CompilerServices.Unsafe.dll
    - System.Threading.Tasks.Extensions
15. Click the **"Add"** button on the far bottom right of the window
16. You should now see all four DLLs in the middle section of the **Reference Manager** window
17. Each DLL should have a check mark to the left of the DLL's name

You are now set to use MOQ in your project
