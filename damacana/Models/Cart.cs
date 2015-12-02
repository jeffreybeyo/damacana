using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace damacana.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public ICollection<Product> Products;
    }
}