using System;


namespace shop.Core.Domain
{
    public class ExistingFilePath
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        public Guid? ProductId { get; set; }
        public Guid SpaceshipId { get; set; }
    }
}
