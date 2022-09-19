using CodeTestV2.Core.Interfaces.Employees;
using CodeTestV2.Core.Models;

namespace CodeTestV2.Application.Models;

public class Response : IResponse<Employee> 
{
    public Response(IList<Employee> data)
    {
        Data = data;
    }
    
    public IList<Employee> Data { get; }
}