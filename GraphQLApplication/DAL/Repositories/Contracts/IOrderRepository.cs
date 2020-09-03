using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace DAL.Repositories.Contracts
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrders(int customerId);
        Task<ILookup<int, Order>> GetOrdersByCustomerId(IEnumerable<int> customerIds);
    }
}
