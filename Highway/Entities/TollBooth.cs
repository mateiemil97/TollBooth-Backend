using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Highway.Entities
{
    public class TollBooth
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Price")]
        public int PriceId { get; set; }

        public Price Price { get; set; }
        public ICollection<Incomes> Incomes { get; set; } = new List<Incomes>();

    }
}
