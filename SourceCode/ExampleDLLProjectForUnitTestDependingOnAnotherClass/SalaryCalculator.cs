using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

[assembly: InternalsVisibleTo("UnitTestClassesWithDependencies")]

namespace ExampleDLLProjectForUnitTestDependingOnAnotherClass
{
    class SalaryCalculator : ISalaryCalculator
    {
        int employeesAge;

        public SalaryCalculator(int employeesAge)
        {
            this.employeesAge = employeesAge;
        }

        public double calculateSalary()
        {
            //Time intensive calculations
            Thread.Sleep(5000);
            //Time intensive calculations
            return 10000 * employeesAge;
        }

    }
}
