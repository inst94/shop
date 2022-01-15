using System;

namespace shop.Core.Dtos
{
    public class ExistingFilePathCarDto
    {
        public Guid PhotoId { get; set; }
        public string FilePath { get; set; }
        public Guid? CarId { get; set; }
    }
}
