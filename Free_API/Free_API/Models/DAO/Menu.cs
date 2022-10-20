using Free_API.Models.DAO;

namespace Free_API.Models.DAO
{
    public class Menu
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Dish> dishes { get; set; }
    }
}
