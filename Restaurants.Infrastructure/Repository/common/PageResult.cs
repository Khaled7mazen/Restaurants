namespace Restaurants.Infrastructure.Repository.common;

public class PageResult<T>
{
    public PageResult(IEnumerable<T> iteams , int pageSize , int PageNumber , int totalCount)
    {
        Iteams = iteams;
        TotalIteamsCount = totalCount;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        IteamsFrom = (PageNumber - 1) * pageSize + 1;
        IteamsTo  = IteamsFrom + pageSize - 1;
    }
    IEnumerable<T> Iteams { get; set; }
    public int TotalIteamsCount { get; set; }
    public int TotalPages { get; set; }
    public int IteamsFrom { get; set; }
    public int IteamsTo { get; set; }

}
