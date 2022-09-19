namespace CodeTestV2.Core.Models;

public interface IResponse<TResponse>
{
    public long? Count { get; }
    
    public IList<TResponse> Data { get; }
}