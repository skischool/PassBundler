using System;
using System.Collections.Generic;

namespace Domain.MainModule.Entities
{
    public partial class ClientBundle
    {
        public int BundleId { get; set; }
        public int ClientId { get; set; }
        public int Id { get; set; }
        public virtual Bundle Bundle { get; set; }
        public virtual Client Client { get; set; }
    }
}
