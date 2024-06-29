namespace Lab5.Domain.Entities
{
    public class Room: Entity
    {
        public Category Category;
        public string Name { get; set; }
        public double ServiceCost { get; set; }
        public int CategoryId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string ImageSrc { get; set; }
    }
}