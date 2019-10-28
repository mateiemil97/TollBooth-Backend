using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Highway.Models.PriceModel
{
    public class PriceForCreationDto
    {
        public int LocationId { get; set; }
        public int CategoryId { get; set; }
        public float Price { get; set; }
    }
}
