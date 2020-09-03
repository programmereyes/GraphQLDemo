using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;

namespace BAL.Types
{
    public class CustomerInputType : InputObjectGraphType
    {
        public CustomerInputType()
        {
            Name = "CustomerInputType";
            Field<NonNullGraphType<StringGraphType>>("ContactTitle");
            Field<StringGraphType>("ContactName");
            Field<StringGraphType>("CompanyName");
            Field<StringGraphType>("Address");
            Field<StringGraphType>("City");
            Field<StringGraphType>("Region");
            Field<StringGraphType>("PostalCode");
            Field<StringGraphType>("Country");
            Field<StringGraphType>("Phone");
            Field<StringGraphType>("Fax");
        }
    }
}
