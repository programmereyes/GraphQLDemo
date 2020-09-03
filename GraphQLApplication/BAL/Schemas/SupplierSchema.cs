using System;
using System.Collections.Generic;
using System.Text;
using GraphQL;
using GraphQL.Types;
using BAL.Queries;

namespace BAL.Schemas
{
    public class SupplierSchema:Schema
    {
        public SupplierSchema(IDependencyResolver dependencyResolver)
        {
            try{
                Query = dependencyResolver.Resolve<SupplierQueryType>();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
