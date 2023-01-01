namespace Rezept.Api.Services.Core;

public class PagedList<T> : List<T>
{
    public int CurrentPage { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }

    public bool HasPrevious => CurrentPage > 1;

    public bool HasNext => CurrentPage < TotalPages;

    public PagedList()
    {

    }
    private PagedList(List<T> items, int count, int pageNumber, int pageSize)
    {
        AddRange(items);
        TotalCount = count;
        CurrentPage = pageNumber;
        PageSize = pageSize;
        TotalPages = (int) Math.Ceiling(count / (double) PageSize);
    }

    public static PagedList<T> Create(
        IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = source.Count();

        var items = source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new PagedList<T>(items, count, pageNumber, pageSize);
    }
}
