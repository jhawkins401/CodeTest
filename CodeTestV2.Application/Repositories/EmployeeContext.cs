using CodeTestV2.Application.Factories;
using CodeTestV2.Application.Models;

namespace CodeTestV2.Application.Repositories;

public class EmployeeContext
{
    public EmployeeContext()
    {
        var all = new List<Employee>();
        
        var count = 0;
        foreach (var unused in Enumerable.Range(0, 10))
        {
            var hourlyEmployee = EmployeeFactory.CreateEmployeeWithId(++count, EmployeeType.Hourly) as HourlyEmployee;
            var managerEmployee = EmployeeFactory.CreateEmployeeWithId(++count, EmployeeType.Manager) as ManagerEmployee;
            var salariedEmployee = EmployeeFactory.CreateEmployeeWithId(++count, EmployeeType.Salaried) as SalariedEmployee;
            
            all.AddRange(new Employee[] { hourlyEmployee, salariedEmployee, managerEmployee });
        }

        AllEmployees = all;
    }

    public void UpdateRecord(Employee employee)
    {
        var rec = AllEmployees.FirstOrDefault(x => x.EmployeeId.Equals(employee.EmployeeId));
        var index = AllEmployees.IndexOf(rec);
        
        AllEmployees[index] = employee;
    }
    public IList<Employee> AllEmployees { get; }
}