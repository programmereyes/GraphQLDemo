using BAL.Services;
using BAL.Types;
using DAL.Entities;
using DAL.Repositories.Contracts;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Queries
{
    public class CustomerMutation : ObjectGraphType
    {
        public CustomerMutation(Func<ICustomerRepository> funcCustomerRepository, CustomerAddedMessageService customerAddedMessageService)
        {
            FieldAsync<CustomerType>(
                "CreateCustomer",
                "Create Customer",
                new QueryArguments(new QueryArgument<CustomerInputType>() { Name = "customer" })
                , resolve: async context =>
                {
                    var customer = context.GetArgument<Customer>("customer");
                    return await context.TryAsyncResolve(async c => await funcCustomerRepository().AddCustomer(customer));
                });

            FieldAsync<CustomerType>(
                "UpdateCustomer",
                "Update Customer",
                new QueryArguments(new QueryArgument<CustomerInputType>() { Name = "customer" }, new QueryArgument<IdGraphType>() { Name = "customerid" }),
                resolve: async context =>
                 {
                     var customer = context.GetArgument<Customer>("customer");
                     var customerId = context.GetArgument<int>("customerid");
                     customer.Id = customerId;
                     customerAddedMessageService.AddCustomerMessage(customer);
                     return await context.TryAsyncResolve(async c => await funcCustomerRepository().UpdateCustomer(customer));
                 }
                );
        }
    }
}
