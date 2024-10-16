﻿namespace DataBase.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<EstablishmentTag> EstablishmentTags { get; set; } 
    }
}
