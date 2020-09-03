using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Contracts
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetSuppliers();
    }
}
