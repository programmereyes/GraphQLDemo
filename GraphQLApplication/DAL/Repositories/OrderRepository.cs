using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private readonly AdventureWorksDbContext _adventureWorksDbContext;

        public OrderRepository(AdventureWorksDbContext adventureWorksDbContext)
        {
            _adventureWorksDbContext = adventureWorksDbContext;
        }
        public async Task<List<Order>> GetOrders(int customerId)
        {
            return await _adventureWorksDbContext.Orders.Where(x => x.CustomerId == customerId).ToListAsync();
        }

        public async Task<ILookup<int, Order>> GetOrdersByCustomerId(IEnumerable<int> customerIds)
        {
            var orders = await _adventureWorksDbContext.Orders.ToListAsync();
            return orders.ToLookup(x => x.CustomerId);
        }
    }
}
