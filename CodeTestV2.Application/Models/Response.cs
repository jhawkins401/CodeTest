using CodeTestV2.Core.Models;

namespace CodeTestV2.Application.Models;

public class Response : IResponse<Employee>
{
    public Response(long? count, IList<Employee> data)
    {
        Count = count;
        Data = data;
    }

    public long? Count { get; }
    public IList<Employee> Data { get; }
}