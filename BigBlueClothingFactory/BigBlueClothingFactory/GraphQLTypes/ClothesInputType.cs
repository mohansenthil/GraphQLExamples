using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBlueClothingFactory.GraphQLTypes
{
    public class ClothesInputType : InputObjectGraphType
    {
        public ClothesInputType()
        {

            Field<NonNullGraphType<StringGraphType>>("DressType");
            Field<StringGraphType>("Color");
            Field<StringGraphType>("Size");
            Field<StringGraphType>("Cost");           
        }       
    }
}
