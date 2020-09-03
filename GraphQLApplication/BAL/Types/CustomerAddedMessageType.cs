using System;
using System.Collections.Generic;
using System.Text;
using BAL.Messages;
using GraphQL.Types;

namespace BAL.Types
{
    public class CustomerAddedMessageType:ObjectGraphType<CustomerAddedMessage>
    {
        public CustomerAddedMessageType()
        {
            Field(x => x.CustomerId);
        }
    }
}
