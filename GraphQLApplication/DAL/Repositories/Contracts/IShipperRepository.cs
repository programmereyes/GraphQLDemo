using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories.Contracts
{
    public interface IShipperRepository
    {
        Task<Shipper> GetShipper(int orderId);
    }
}
