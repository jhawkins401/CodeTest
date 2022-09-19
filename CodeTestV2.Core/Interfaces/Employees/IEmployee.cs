namespace CodeTestV2.Core.Interfaces.Employees;

public interface IEmployee : IWork, IVacation, ITimeSheet
{
    int EmployeeId { get; }
}