using Project2.Models.Models;
using Project2.Repository.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.BLL.BLL
{
    public class SupplierManager
    {
       SupplierRepository _supplierRepository = new SupplierRepository();
        public SupplierManager()
        {
            _supplierRepository = new SupplierRepository();
        }
        public bool Add(Supplier supplier)
        {
            return _supplierRepository.Add(supplier);
        }
        public bool IsCodeDuplicate(Supplier supplier)
        {
            return _supplierRepository.IsCodeDuplicate(supplier);
        }
        public List<Supplier> GetAll()
        {
            return _supplierRepository.GetAll();
        }
        public Supplier GetById(int id)
        {
            return _supplierRepository.GetById(id);
        }
        public bool isUpdated(Supplier supplier)
        {
            return _supplierRepository.isUpdated(supplier);
        }
    }
}
