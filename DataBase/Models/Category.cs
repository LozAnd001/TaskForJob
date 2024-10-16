namespace DataBase.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Establishment> Places { get; set; }
        
    }
}
