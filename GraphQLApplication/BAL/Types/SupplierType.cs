using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using DAL.Entities;

namespace BAL.Types
{
    public class SupplierType:ObjectGraphType<Supplier>
    {
        public SupplierType()
        {
            Field(x => x.Id).Description("Supplier Id");
            Field(x => x.ContactTitle).Description("Supplier Title");
            Field(x => x.ContactName).Description("Supplier Contact Name");
            Field(x => x.CompanyName).Description("Supplier Company name");
            Field(x => x.Address).Description("Supplier Address");
        }
    }
}
