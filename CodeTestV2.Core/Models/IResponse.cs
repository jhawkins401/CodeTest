using CodeTestV2.Core.Interfaces.Employees;

namespace CodeTestV2.Core.Models;

public interface IResponse<TResponse> where TResponse : class, IEmployee 
{
    public IList<TResponse> Data { get; }
}