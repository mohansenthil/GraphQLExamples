using BigBlueClothingFactory.Mutation;
using BigBlueClothingFactory.Queries;
using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBlueClothingFactory.Schema
{
    public class BigBlueSchema : GraphQL.Types.Schema
    {

        public BigBlueSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<BigBlueStoreQuery>();

            Mutation = dependencyResolver.Resolve<BigBlueMutation>();
        }

    }
}
