using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Highway.Models.IncomesModel
{
    public class IncomesForCreationDto
    {
        public DateTime DateTime { get; set; }
        public int EmployeeId { get; set; }
        public int TollBoothId { get; set; }
        public int LocationId { get; set; }
        public float Amount { get; set; }
    }
}
