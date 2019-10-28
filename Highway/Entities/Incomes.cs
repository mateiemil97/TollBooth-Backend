using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Highway.Entities
{
    public class Incomes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public DateTimeOffset DateTime { get; set; }

        public float Amount { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("TollBooth")]
        public int TollBoothId { get; set; }
        public int LocationId { get; set; }

        public Employee Employee { get; set; }
        public TollBooth TollBooth { get; set; }
        public Location Location { get; set; }
    }
}
