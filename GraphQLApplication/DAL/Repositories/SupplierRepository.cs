using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AdventureWorksDbContext _adventureWorksDbContext;

        public SupplierRepository(AdventureWorksDbContext adventureWorksDbContext)
        {
            _adventureWorksDbContext = adventureWorksDbContext;
        }
        public async Task<List<Supplier>> GetSuppliers()
        {
            return await _adventureWorksDbContext.Suppliers.ToListAsync();
        }
    }
}
