using System;

namespace shop.Models.Weather
{
    public class Moon
    {
        public string Rise { get; set; }
        public Int64 EpochRise { get; set; }
        public string Set { get; set; }
        public Int64 EpochSet { get; set; }
        public string Phase { get; set; }
        public int Age { get; set; }
    }
}