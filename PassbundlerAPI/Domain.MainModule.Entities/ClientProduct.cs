using System;
using System.Collections.Generic;

namespace Domain.MainModule.Entities
{
    public partial class ClientProduct
    {
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public int Id { get; set; }
        public virtual Client Client { get; set; }
        public virtual Product Product { get; set; }
    }
}
