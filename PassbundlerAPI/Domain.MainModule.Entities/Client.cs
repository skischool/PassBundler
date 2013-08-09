using System;
using System.Collections.Generic;

namespace Domain.MainModule.Entities
{
    public partial class Client
    {
        public Client()
        {
            this.ClientBundles = new List<ClientBundle>();
            this.ClientProducts = new List<ClientProduct>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public virtual ICollection<ClientBundle> ClientBundles { get; set; }
        public virtual ICollection<ClientProduct> ClientProducts { get; set; }
    }
}
