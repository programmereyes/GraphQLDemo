using System;
using System.Collections.Generic;
using System.Text;
using BAL.Queries;
using BAL.Types;
using GraphQL;
using GraphQL.Types;

namespace BAL.Schemas
{
    public class CustomerSchema : Schema
    {
        public CustomerSchema(IDependencyResolver dependencyResolver):base(dependencyResolver)
        {
            try
            {
                Query = dependencyResolver.Resolve<CustomerQueryType>();
                Mutation = dependencyResolver.Resolve<CustomerMutation>();
                Subscription = dependencyResolver.Resolve<CustomerAddedSubscription>();

            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
