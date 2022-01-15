using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace shop.Core.Dtos
{
    public class CarDto
    {
        public Guid? Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public List<IFormFile> Files { get; set; }
        public IEnumerable<ExistingFilePathCarDto> ExistingFilePathsCar { get; set; } = new List<ExistingFilePathCarDto>();
    }
}
