using System;


namespace shop.Core.Dtos
{
    public class ExistingFilePathDto
    {
        public Guid PhotoId { get; set; }
        public string FilePath { get; set; }
        public Guid ProductId { get; set; }
        public Guid CarId { get; set; }
    }
}
