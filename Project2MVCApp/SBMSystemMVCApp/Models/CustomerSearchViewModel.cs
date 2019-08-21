
using Project2MVCApp.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project2.Models
{
    public class CustomerSearchViewModel
    {        
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string ImageCustomer { get; set; }
        public int LoyaltyPoint { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}