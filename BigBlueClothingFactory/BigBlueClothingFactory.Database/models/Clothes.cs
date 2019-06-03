using System;
using System.Collections.Generic;
using System.Text;

namespace BigBlueClothingFactory.Database
{
    public class Clothes
    {
        public int id { get; set; }

        public string Cost { get; set; }

        public string DressType { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public Manufacturer Manfacturer { get; set; }
    }
}
