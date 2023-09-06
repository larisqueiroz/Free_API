namespace Free_API.Models.DTO.Pagination;

public class PagedResult<T>
{
    public List<T> Itens { get; set; }= new List<T>();
    public int CurrentPage { get; set; }
    public double PagesCount { get; set; }

    public void PagedSearch(int page, List<T> itensSearched, double pageItens = 2f)
    {
        var pageItensCount = Math.Ceiling(itensSearched.Count / pageItens);

        var paged = itensSearched.Skip((page - 1) * (int)pageItens)
            .Take((int)pageItens).ToList();

        Itens = paged;
        CurrentPage = page;
        PagesCount = (int)pageItensCount;
    }
    
}