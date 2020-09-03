using System;
using System.Collections.Generic;
using System.Text;
using BAL.Messages;
using GraphQL.Types;
using GraphQL.Resolvers;
using BAL.Services;

namespace BAL.Types
{
    public class CustomerAddedSubscription:ObjectGraphType
    {
        public CustomerAddedSubscription(CustomerAddedMessageService messageService)
        {
            Name = "Subscription";
            AddField(new EventStreamFieldType()
            {
                Name="CustomerAdded",
                Type=typeof(CustomerAddedMessageType),
                Resolver=new FuncFieldResolver<CustomerAddedMessage>(x=>x.Source as CustomerAddedMessage),
                Subscriber=new EventStreamResolver<CustomerAddedMessage>(x=>messageService.GetCustomerAddedMessage())
            });
        }
    }
}
