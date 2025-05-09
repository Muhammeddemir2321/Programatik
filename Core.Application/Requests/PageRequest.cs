namespace Core.Application.Requests;

public class PageRequest
{
    public int Page { get; set; }
    public int PageSize { get; set; }

    public PageRequest()
    {
        this.Page = 0;
        this.PageSize = 100;
    }
}
