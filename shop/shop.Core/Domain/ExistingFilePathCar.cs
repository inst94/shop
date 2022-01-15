using System;

namespace shop.Core.Domain
{
    public class ExistingFilePathCar
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        public Guid? CarId { get; set; }
    }
}