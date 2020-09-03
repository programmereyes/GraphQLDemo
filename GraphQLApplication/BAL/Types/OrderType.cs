using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories.Contracts;
using GraphQL;
using GraphQL.Types;

namespace BAL.Types
{
    public class OrderType:ObjectGraphType<Order>
    {
        public OrderType(Func<IShipperRepository> funcShipperRepository)
        {
            Field(x => x.Id).Description("Order Id");
            Field(x => x.OrderDate).Description("Order Placed Date");
            Field(x => x.RequiredDate).Description("Order Required Date");
            Field(x => x.ShipAddress).Description("Shipping Adderess");
            Field(x => x.Shipcity).Description("Shipping City");
            Field(x => x.ShipCountry).Description("Shipping Country");
            Field(x => x.ShipName).Description("Ship Name");
            Field(x => x.ShippedDate,nullable:true).Description("Shipping Date");
            Field(x => x.ShipperId,nullable:true).Description("Shipper Id");
            Field(x => x.ShipRegion).Description("Ship Region");
            FieldAsync<ShipperType>(
                "Shipper", "Shipper assign for the order"
                , null
                , resolve: async context => await funcShipperRepository().GetShipper(context.Source.ShipperId.Value));
        }
    }
}
