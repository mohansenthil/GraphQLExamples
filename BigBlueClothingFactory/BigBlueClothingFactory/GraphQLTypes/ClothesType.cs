using BigBlueClothingFactory.DataAccess;
using BigBlueClothingFactory.Database;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBlueClothingFactory.GraphQLTypes
{
    public class ClothesType : ObjectGraphType<Clothes>
    {

        public ClothesType(IClothesRepository repository)
        {
            Field(x => x.id); // Leaves of the query
            Field(x => x.Color);
            Field(x => x.Cost);
            Field(x => x.DressType);
            Field(x => x.Size);
            Field<ListGraphType<ManufacturerType>>("manfacturer", resolve : context => {
                return repository.GetManfacturer(context.Source.id);
            });
        }
    }
}
