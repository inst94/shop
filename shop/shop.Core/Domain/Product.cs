using System;
using System.Collections.Generic;

namespace shop.Core.Domain
{
    public class Product
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public IEnumerable<ExistingFilePath> ExistingFilePaths { get; set; } = new List<ExistingFilePath>();

    }
}
