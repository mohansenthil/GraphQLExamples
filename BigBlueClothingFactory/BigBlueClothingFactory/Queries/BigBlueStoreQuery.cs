using BigBlueClothingFactory.DataAccess;
using BigBlueClothingFactory.GraphQLTypes;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBlueClothingFactory.Queries
{
    public class BigBlueStoreQuery : ObjectGraphType
    {

        public BigBlueStoreQuery(IClothesRepository repository)
        {

            Field<IntGraphType>("StoreContactNumber","gets user PhoneNumber" ,resolve: context => { return 8926; });

            Field<ListGraphType<ClothesType>>(
                "clothes",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id"}),
                resolve: context => {

                    var id = context.GetArgument<int?>("id");

                    if (id != null)
                    {
                        return repository.GetCloth(id.Value);
                    }

                    return repository.GetAll();
                    
                    }
                );

            Field<ListGraphType<ManufacturerType>>(
                "manfactures",
                arguments: new QueryArguments(new QueryArgument<IntGraphType>{Name = "id" }),
                resolve : context =>
                {
                    var id = context.GetArgument<int?>("id");

                    return id != null ? repository.GetManfacturer(id.Value) : repository.GetManfacturers();
                }
                );
        }


    }
}
