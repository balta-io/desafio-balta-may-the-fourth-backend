using MediatR;

namespace MayTheFourth.Core.Contexts.PersonContext.UseCases.SearchAll;

public class Request : IRequest<Response>
{
    public Request(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public int PageNumber { get; private set; }
    public int PageSize { get; private set; }

    public void ChangePageSize(int newPageSize)
    {
        PageSize = newPageSize;
    }
}

