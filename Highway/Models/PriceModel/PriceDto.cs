using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Highway.Controllers
{
    public class PriceDto
    {
        public int LocationId { get; set; }
        public int CategoryId { get; set; }
        public float Amount { get; set; }
    }
}
