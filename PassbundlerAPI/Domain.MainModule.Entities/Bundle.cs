using System;
using System.Collections.Generic;

namespace Domain.MainModule.Entities
{
    public partial class Bundle
    {
        public Bundle()
        {
            //this.ClientBundles = new List<ClientBundle>();
            this.Customers = new List<Customer>();
            this.Products = new List<Product>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        //public virtual ICollection<ClientBundle> ClientBundles { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
