using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedServices.Entities.Dto
{
    public class Bundle
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }

        public List<Dto.Product> Products { get; set; }
    }
}
