namespace DataBase.Models
{
    public class Establishment
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Address { get; set; } 
        public string? Description { get; set; }
        public List<EstablishmentTag> EstablishmentTags { get; set; }
    }
}
