using BigBlueClothingFactory.Database;
using System.Collections;
using System.Collections.Generic;

namespace BigBlueClothingFactory.DataAccess
{
    public interface IClothesRepository
    {
        IEnumerable<Clothes> GetAll();

        IEnumerable<Clothes> GetCloth(int clothId);

        IEnumerable<Manufacturer> GetManfacturer(int clothId);

        IEnumerable<Manufacturer> GetManfacturers();

        Clothes AddCloth(Clothes clothes);
    }
}
