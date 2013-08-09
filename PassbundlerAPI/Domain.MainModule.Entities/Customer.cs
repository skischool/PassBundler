using System;
using System.Collections.Generic;

namespace Domain.MainModule.Entities
{
    public partial class Customer
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BundleId { get; set; }
        public int Id { get; set; }
        public virtual Bundle Bundle { get; set; }
    }
}
