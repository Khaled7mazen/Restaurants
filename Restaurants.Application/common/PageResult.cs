namespace Restaurants.Infrastructure.Repository.common;

public class PageResult<T>
{
    public PageResult(IEnumerable<T> items, int totalCount, int pageSize, int pageNumber)
    {
        Items = items;
        TotalIteamsCount = totalCount;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        IteamsFrom = (pageNumber - 1) * pageSize + 1;
        IteamsTo  = IteamsFrom + pageSize - 1;
    }
    public IEnumerable<T> Items { get; set; }
    public int TotalIteamsCount { get; set; }
    public int TotalPages { get; set; }
    public int IteamsFrom { get; set; }
    public int IteamsTo { get; set; }

}
