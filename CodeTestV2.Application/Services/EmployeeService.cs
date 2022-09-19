using CodeTestV2.Application.Models;
using CodeTestV2.Application.Repositories;
using CodeTestV2.Core.Interfaces.Services;
using CodeTestV2.Core.Models;

namespace CodeTestV2.Application.Services;

public class EmployeeService : IEmployeeService<Employee>
{
    private EmployeeContext Context { get; }

    public EmployeeService(EmployeeContext context)
    {
        Context = context;
    }
    
    public Task<Employee?> GetEmployeeAsync(int employeeId, CancellationToken token)
    {
        return Task.Run(() => Context.AllEmployees.FirstOrDefault(x => x.EmployeeId.Equals(employeeId)), token);
    }

    public Task<IResponse<Employee>> ListEmployees(IQuery employeeQuery, CancellationToken token)
    {
        var result = Context.AllEmployees.Skip(employeeQuery.Skip).Take(employeeQuery.Top).ToList();
        
        return Task.Run(() => (IResponse<Employee>)new Response(result), token);
    }

    public Task<Employee> UpdateEmployeeAsync(Employee employee, CancellationToken token)
    {
        return Task.Run(() => Context.UpdateRecord(employee), token)
            .ContinueWith(_ => employee, token);
    }
}