using System;
using System.ComponentModel.DataAnnotations;

namespace shop.Core.Domain
{
    public class Car
    {
        [Key]
        public Guid? Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
