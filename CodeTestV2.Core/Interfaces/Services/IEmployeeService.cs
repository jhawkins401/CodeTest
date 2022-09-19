using CodeTestV2.Core.Interfaces.Employees;
using CodeTestV2.Core.Models;

namespace CodeTestV2.Core.Interfaces.Services;

public interface IEmployeeService<TResponse, T> 
    where T : IEmployee
    where TResponse : IResponse<T>
{
    Task<T?> GetEmployeeAsync(int employeeId, CancellationToken token);
    Task<TResponse> ListEmployees(IQuery employeeQuery, CancellationToken token);
    Task<T> UpdateEmployeeAsync(T employee, CancellationToken token);
}