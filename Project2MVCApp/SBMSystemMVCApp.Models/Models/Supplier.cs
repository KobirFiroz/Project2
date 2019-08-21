using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Models.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Code is Empty")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name is Empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is Empty")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Email is Empty")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Contact is Empty")]
        public string Contact { get; set; }
        public string ImageLogo { get; set; }
        [Required(ErrorMessage = "Contact Person is Empty")]
        public string ContactPerson { get; set; }
    }
}
