using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BigBlueClothingFactory.Database
{
    public static class GetDataFromDB
    {
        public static IEnumerable<Clothes> LoadClothesJsonData()
        {
            IEnumerable<Clothes> clothes = null;
            
            var wholePath = Path.Combine(Directory.GetCurrentDirectory(), "MockData/dresses.json");
            using (StreamReader r = new StreamReader(wholePath))
            {
                string json = r.ReadToEnd();
                clothes = JsonConvert.DeserializeObject<List<Clothes>>(json);
            }

            return clothes;

        }

        public static void AddClothes(Clothes newclothes)
        {

          
            List<Clothes> clothes = null;

            var wholePath = Path.Combine(Directory.GetCurrentDirectory(), "MockData/dresses.json");
            using (StreamReader r = new StreamReader(wholePath))
            {
                string json = r.ReadToEnd();
                clothes = JsonConvert.DeserializeObject<List<Clothes>>(json);
                clothes.Add(newclothes);               
            }

            var serializeClothes = JsonConvert.SerializeObject(clothes);
            File.WriteAllText(wholePath, serializeClothes);


        }

        public static IEnumerable<Manufacturer> LoadManfacturerJsonData()
        {
            IEnumerable<Manufacturer> manfactures = null;

            var wholePath = Path.Combine(Directory.GetCurrentDirectory(), "MockData/Manfacturers.json");

            using (StreamReader r = new StreamReader(wholePath))
            {
                string json = r.ReadToEnd();
                manfactures = JsonConvert.DeserializeObject<List<Manufacturer>>(json);
            }

            return manfactures;
        }

        public static void Main(string[] args)
        {
            GetDataFromDB.LoadClothesJsonData();
        }
    }
}
