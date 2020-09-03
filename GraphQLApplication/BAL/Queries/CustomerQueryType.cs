using BAL.Types;
using DAL.Repositories.Contracts;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using GraphQL.DataLoader;
using DAL.Entities;

namespace BAL.Queries
{
    public class CustomerQueryType : ObjectGraphType
    {
        public CustomerQueryType(IDataLoaderContextAccessor accessor , Func<ICustomerRepository> customerRepository) : base()
        {
            //FieldAsync<ListGraphType<CustomerType>>("Customers", Description = "Get All Customers", resolve: async context => 
            //await customerRepository.Invoke().GetCustomers());

            Field<ListGraphType<CustomerType>, IEnumerable<Customer>>().Name("Customers").Description("Get Customer Details").ResolveAsync(context =>
             {
                 var loader = accessor.Context.GetOrAddLoader<IEnumerable<Customer>>("GetAllCustomers",()=>customerRepository().GetCustomers());
                 return loader.LoadAsync();
             });

            FieldAsync<CustomerType>("Customer", Description = "Get Customer Details",
                new QueryArguments(new QueryArgument(typeof(IntGraphType)) { Name = "customerId", Description = "Customer Id to be find" }),
                resolve: async context => await customerRepository.Invoke().GetCustomer(context.GetArgument<int>("customerId"))
                );

        }

    }
}
