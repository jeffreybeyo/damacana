using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace damacana.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }

        public ICollection<Product> Products;

        public decimal TotalPrice { get; set; }
    }
}