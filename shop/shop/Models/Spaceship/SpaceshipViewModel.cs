﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace shop.Models.Spaceship
{
    public class SpaceshipViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Mass { get; set; }
        public decimal Price { get; set; }
        public int Crew { get; set; }
        public DateTime Constructed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<ImagesViewModel> Image { get; set; } = new List<ImagesViewModel>();
    }
}
