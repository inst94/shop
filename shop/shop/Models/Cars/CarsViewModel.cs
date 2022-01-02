using Microsoft.AspNetCore.Http;
using shop.Models.Files;
using System;
using System.Collections.Generic;


namespace shop.Views.Cars
{
    public class CarsViewModel
    {
        public Guid? Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<ExistingFilePathViewModel> ExistingFilePaths { get; set; } = new List<ExistingFilePathViewModel>();

    }
}
