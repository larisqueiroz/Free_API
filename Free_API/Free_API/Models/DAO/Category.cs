namespace Free_API.Models.DAO
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Dish> dishes { get; set; }
    }
}
