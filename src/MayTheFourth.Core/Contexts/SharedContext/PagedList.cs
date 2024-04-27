namespace MayTheFourth.Core.Contexts.SharedContext;

public class PagedList <T>
{
    public PagedList(int pageNumber, int pageSize, int count, List<T>? items)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        Count = count;
        Items = items;
    }

    public int PageNumber { get; }
    public int PageSize { get; private set; }
    public int Count { get; }
    public List<T>? Items { get; }
    public bool HasNext => Count - (PageNumber * PageSize) > 0;
    public bool HasPrevious => PageNumber > 1;

    public void ChangePageSize(int newPageSize)
    {
        PageSize = newPageSize;
    }
}
