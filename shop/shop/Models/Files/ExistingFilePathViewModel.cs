﻿using System;


namespace shop.Models.Files
{
    public class ExistingFilePathViewModel
    {
        public Guid PhotoId { get; set; }
        public string FilePath { get; set; }
        public Guid ProductId { get; set; }
        public Guid CarId { get; set; }
    }
}
