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
    public class CustomerRepository:ICustomerRepository
    {
        private readonly AdventureWorksDbContext _adventureWorksDbContext;

        public CustomerRepository(AdventureWorksDbContext adventureWorksDbContext)
        {
            _adventureWorksDbContext = adventureWorksDbContext;
        }
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _adventureWorksDbContext.Customers.ToListAsync();
        }
        public async Task<Customer> GetCustomer(int customerId)
        {
            return await  _adventureWorksDbContext.Customers.FirstOrDefaultAsync(x=>x.Id==customerId);
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
           await _adventureWorksDbContext.Customers.AddAsync(customer);
           await  _adventureWorksDbContext.SaveChangesAsync();
           return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
             _adventureWorksDbContext.Update(customer);
            await _adventureWorksDbContext.SaveChangesAsync();
            return customer;
        }
    }
}
