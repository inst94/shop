using System;

namespace shop.Models.Car
{
    public class ImagesViewModel
    {
        public Guid Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string Image { get; set; }
        public Guid CarId { get; set; }
    }
}
