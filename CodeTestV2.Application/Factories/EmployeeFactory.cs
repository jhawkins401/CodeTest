using CodeTestV2.Application.Models;
using CodeTestV2.Core.Interfaces.Employees;

namespace CodeTestV2.Application.Factories;

public static class EmployeeFactory
{
    public static IEmployee CreateEmployeeWithId(int id, EmployeeType type)
    => type switch
    {
        EmployeeType.Hourly =>  new HourlyEmployee(id) ,
        EmployeeType.Salaried => new SalariedEmployee(id),
        EmployeeType.Manager => new ManagerEmployee(id),
        _ => throw new Exception()
    };
    
    public static IEmployee CreateEmployee(EmployeeType type) =>
    type switch
        {
            EmployeeType.Hourly =>  DefaultHourlyEmployee.CloneHourly(),
            EmployeeType.Salaried => DefaultSalariedEmployee.CloneSalaried(),
            EmployeeType.Manager => DefaultManagerEmployee.CloneManager(),
            _ => throw new Exception()
        };

    private static readonly HourlyEmployee DefaultHourlyEmployee = new ();
    private static readonly SalariedEmployee DefaultSalariedEmployee = new ();
    private static readonly ManagerEmployee DefaultManagerEmployee = new ();
}