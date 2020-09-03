using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using DAL.Entities;

namespace BAL.Types
{
    public class ShipperType:ObjectGraphType<Shipper>
    {
        public ShipperType()
        {
            Field(x => x.Id).Description("Shipper Type Id");
            Field(x => x.CompanyName).Description("Shipper Company Name");
            Field(x => x.Phone).Description("Shipper Phone Number");
            //Field(x=>x.ShipperOrderNavigation,"ShipperOrders","Order Delivered/Delivering by Shipper",)
        }
    }
}
