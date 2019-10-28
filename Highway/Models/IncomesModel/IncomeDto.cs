using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Highway.Models.IncomesModel
{
    public class IncomeDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int EmployeeId { get; set; }
        public int TollBoothId { get; set; }
    }
}
