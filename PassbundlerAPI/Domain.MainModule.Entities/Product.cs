using System;
using System.Collections.Generic;

namespace Domain.MainModule.Entities
{
    public partial class Product
    {
        public Product()
        {
            this.ClientProducts = new List<ClientProduct>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int BundleId { get; set; }
        public int Id { get; set; }
        public virtual Bundle Bundle { get; set; }
        public virtual ICollection<ClientProduct> ClientProducts { get; set; }
    }
}
