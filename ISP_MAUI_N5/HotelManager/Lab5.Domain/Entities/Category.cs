namespace Lab5.Domain.Entities
{
    public class Category: Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Room>? Rooms { get; set; }
    }
}