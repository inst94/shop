using System;

namespace shop.Models.Spaceship
{
    public class SpaceshipListViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Mass { get; set; }
        public decimal Prise { get; set; }
        public int Crew { get; set; }
        public DateTime Constructed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
