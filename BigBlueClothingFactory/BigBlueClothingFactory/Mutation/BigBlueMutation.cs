using BigBlueClothingFactory.DataAccess;
using BigBlueClothingFactory.Database;
using BigBlueClothingFactory.GraphQLTypes;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBlueClothingFactory.Mutation
{
    public class BigBlueMutation : ObjectGraphType
    {
        public BigBlueMutation(IClothesRepository repository)
        {
            Field<ClothesType>(
                "addClothes", 
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ClothesInputType>> { Name = "cloth" }), 
                resolve: context => {
                    var cloth = context.GetArgument<Clothes>("cloth");
                    return repository.AddCloth(cloth);
                });
        }
    }
}
