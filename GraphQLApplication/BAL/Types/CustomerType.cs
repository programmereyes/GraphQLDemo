using DAL.Entities;
using DAL.Repositories.Contracts;
using GraphQL.DataLoader;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BAL.Types
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType(IDataLoaderContextAccessor accessor,Func<IOrderRepository> funcCustomerRepository) : base()
        {
            Field(x => x.Id).Description("Customer Id");
            Field(x => x.ContactTitle).Description("Contact Title");
            Field(x => x.ContactName).Description("Customer Contact Name");
            Field(x => x.CompanyName).Description("Company name");
            FieldAsync<ListGraphType<OrderType>>("Orders", "Orders of the client", null, resolve: async context =>
            {
                var userContext =(ClaimsPrincipal) context.UserContext;
                if (userContext.HasClaim(x => x.Type == "customclaim" && x.Value == "customvalue"))
                {
                    // Get or add a collection batch loader with the key "GetOrdersByUserId"
                    // The loader will call GetOrdersByUserIdAsync with a batch of keys
                    var repository = funcCustomerRepository();
                    var orderLoader = accessor.Context.GetOrAddCollectionBatchLoader<int, Order>("GetOrdersByCustomerId", repository.GetOrdersByCustomerId);
                    // Add this customerId to the pending keys to fetch data for
                    // The task will complete with an IEnumberable<Order> once the fetch delegate has returned
                    return await orderLoader.LoadAsync(context.Source.Id);
                    //return await funcCustomerRepository.Invoke().GetOrders(context.Source.Id);
                    //return await context.Source.CustomerOrdersNavigation.Select(x=>x).ToList()
                }
                else
                {
                    context.Errors.Add(new GraphQL.ExecutionError("Unauthorized user", new UnauthorizedAccessException()));
                    return null;
                }
            });
        }
    }
}
