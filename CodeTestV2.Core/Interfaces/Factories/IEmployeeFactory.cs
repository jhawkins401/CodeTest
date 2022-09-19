using CodeTestV2.Core.Interfaces.Employees;

namespace CodeTestV2.Core.Interfaces.Factories;

public interface IEmployeeFactory
{
    IEmployee CreateEmployee();
}