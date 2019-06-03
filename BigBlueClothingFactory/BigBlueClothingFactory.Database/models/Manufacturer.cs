using System;
using System.Collections.Generic;
using System.Text;

namespace BigBlueClothingFactory.Database
{
    public class Manufacturer
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public decimal Rating { get; set; }

        public string  ContactNumber { get; set; }
    }
}
