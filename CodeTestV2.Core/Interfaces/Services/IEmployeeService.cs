using CodeTestV2.Core.Interfaces.Employees;
using CodeTestV2.Core.Models;

namespace CodeTestV2.Core.Interfaces.Services;

public interface IEmployeeService<T> 
    where T : class, IEmployee 

{
    Task<T?> GetEmployeeAsync(int employeeId, CancellationToken token);
    Task<IResponse<T>> ListEmployees(IQuery employeeQuery, CancellationToken token);
    Task<T> UpdateEmployeeAsync(T employee, CancellationToken token);
}