
using Project2.DatabaseContext.DatabaseContext;
using Project2MVCApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Repository.Repository
{
    public class CustomerRepository
    {
        Project2DbContext db;
        public CustomerRepository()
        {
            db = new Project2DbContext();
        }
        public bool Add(Customer customer)
        {
            int isExecuted = 0;
            db.Customers.Add(customer);
            isExecuted = db.SaveChanges();
            return isExecuted > 0;
        } 
        public bool IsCodeDuplicate(Customer customer)
        {
            var aCustomer = db.Customers.FirstOrDefault(c => c.Code == customer.Code);
            if(aCustomer!=null)
            {
                return true;
            }
            return false ;
        } 
        public List<Customer> GetAll()
        {
            var customers = db.Customers.ToList();
            return customers;
        } 
        public Customer GetById(int id)
        {
            var customer = db.Customers.FirstOrDefault(c => c.Id == id);
            return customer;
        }
        public bool isUpdated(Customer customer)
        {
            int isExecuted = 0;
            db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            isExecuted = db.SaveChanges();
            return isExecuted > 0;
        }
    }
}
