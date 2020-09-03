using DAL.Entities;
using DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Context;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly AdventureWorksDbContext _adventureWorksDbContext;

        public ShipperRepository(AdventureWorksDbContext adventureWorksDbContext)
        {
            _adventureWorksDbContext = adventureWorksDbContext;
        }
        public async Task<Shipper> GetShipper(int ShipperId)
        {
            return await _adventureWorksDbContext.Shippers.FindAsync(ShipperId);
        }
    }
}
