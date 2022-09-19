using CodeTestV2.Core.Models;

namespace CodeTestV2.Application.Models;

public class Request : IQuery
{
    public Request(ushort skip, ushort top)
    {
        Skip = skip;
        Top = top;
    }

    public ushort Top { get; }
    public ushort Skip { get; }
}