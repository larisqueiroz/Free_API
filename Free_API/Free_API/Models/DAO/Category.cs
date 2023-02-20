namespace Free_API.Models.DAO
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Dish> dishes { get; set; } = new List<Dish>();
    }
}
