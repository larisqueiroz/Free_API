using Free_API.Models.DAO;

namespace Free_API.Models.DAO
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public List<Category> categories { get; set; } = new List<Category>();
    }
}
