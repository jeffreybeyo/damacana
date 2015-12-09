using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace damacana2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Cart
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        //public virtual ICollection<Product> Products { get; set; }
    }
    public class Purchase
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedOn { get; set; }

        //public virtual ICollection<Product> Products { get; set; }

        public decimal TotalPrice { get; set; }
    }

    public class ProductDBContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
    }


}