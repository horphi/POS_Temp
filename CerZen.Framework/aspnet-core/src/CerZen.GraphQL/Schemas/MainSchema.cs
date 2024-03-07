using Abp.Dependency;
using GraphQL.Types;
using GraphQL.Utilities;
using CerZen.Queries.Container;
using System;

namespace CerZen.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IServiceProvider provider) :
            base(provider)
        {
            Query = provider.GetRequiredService<QueryContainer>();
        }
    }
}