namespace SimpleMDB;

public class PagedResult<T>
{
    public List<T> Values { get; }
    public int TotalCount { get; }

    public PagedResult(List<T> values, int totalcount)
    {
        Values = values;
        TotalCount = totalcount;
    }
}