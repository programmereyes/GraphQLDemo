using System;
using System.Collections.Generic;
using System.Text;
using BAL.Types;
using DAL.Repositories.Contracts;
using GraphQL.Types;

namespace BAL.Queries
{
    public class SupplierQueryType:ObjectGraphType
    {
        public SupplierQueryType(Func<ISupplierRepository> funcSupplierRepository)
        {
            FieldAsync<ListGraphType<SupplierType>>(
                "Suppliers", "Get All Suppliers"
                , null
                , resolve: async context => await funcSupplierRepository.Invoke().GetSuppliers());
        }
    }
}
