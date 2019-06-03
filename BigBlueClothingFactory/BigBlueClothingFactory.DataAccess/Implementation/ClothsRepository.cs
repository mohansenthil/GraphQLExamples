using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BigBlueClothingFactory.Database;

namespace BigBlueClothingFactory.DataAccess.Implementation
{
    public class ClothsRepository : IClothesRepository
    {
       
        public ClothsRepository()
        {
            
        }

        public Clothes AddCloth(Clothes clothes)
        {
            if(clothes?.id == 0)
            {
                var allClothes = GetAll();
                var number = allClothes.Select(x => x.id).OrderByDescending(x => x).FirstOrDefault();
                clothes.id = number + 1;
            }

            GetDataFromDB.AddClothes(clothes);

           return clothes;
        }

        public IEnumerable<Clothes> GetAll()
        {
            return GetDataFromDB.LoadClothesJsonData();
        }

        public IEnumerable<Clothes> GetCloth(int clothId)
        {
            return new List<Clothes>
            {
                GetDataFromDB.LoadClothesJsonData().FirstOrDefault(id => id.id == clothId)
            };
        }

        public IEnumerable<Manufacturer> GetManfacturer(int clothId)
        {
            var cloth = GetDataFromDB.LoadClothesJsonData().FirstOrDefault(id => id.id == clothId);

            var manfacturer = GetDataFromDB.LoadManfacturerJsonData().FirstOrDefault(id => id.ID == cloth?.Manfacturer?.ID);

            return new List<Manufacturer>
            {
                manfacturer
            };

        }

        public IEnumerable<Manufacturer> GetManfacturers()
        {
            var data = GetDataFromDB.LoadManfacturerJsonData();

            return data;           
            
        }
    }
}
