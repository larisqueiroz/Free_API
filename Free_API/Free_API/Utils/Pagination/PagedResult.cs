using System.Linq.Expressions;

namespace Free_API.Models.DTO.Pagination;

public class PagedResult<T>
{
    public List<T> Items { get; set; }= new List<T>();
    public int CurrentPage { get; set; }
    public double PagesCount { get; set; }

    public void PagedSearch(int page, List<T> itemsSearched, string? keyword, double pageItems = 2f, bool alphabeticalOrder = false)
    {
        var type = typeof(T);

        var property = type.GetProperty("Name");
        Expression<Func<T, object>> expressionOrder = item => property.GetValue(item);
        
        if (alphabeticalOrder)
            itemsSearched = itemsSearched.OrderBy(expressionOrder.Compile()).ToList();

        if (keyword != null)
        {
            Expression<Func<T, bool>> expressionKeyword = item =>
                item.GetType().GetProperty(property.Name).GetValue(item, null).ToString().ToLower()
                    .Contains(keyword.ToLower());
            itemsSearched = itemsSearched.Where(expressionKeyword.Compile()).ToList();
        }

        var pageItensCount = Math.Ceiling(itemsSearched.Count / pageItems);

        var paged = itemsSearched.Skip((page - 1) * (int)pageItems)
            .Take((int)pageItems).ToList();

        Items = paged;
        CurrentPage = page;
        PagesCount = (int)pageItensCount;
    }
    
}