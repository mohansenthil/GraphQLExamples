using BigBlueClothingFactory.DataAccess;
using BigBlueClothingFactory.Database;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBlueClothingFactory.GraphQLTypes
{
    public class ManufacturerType : ObjectGraphType<Manufacturer>
    {

        public ManufacturerType(IClothesRepository repository)
        {
            Field(x => x.ID);
            Field(x => x.Name);
            Field(x => x.Rating);
            Field(x => x.ContactNumber);                
        }
    }
}
