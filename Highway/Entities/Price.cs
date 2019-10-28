using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Highway.Entities
{
    public class Price
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public float Amount { get; set; }

        public Location Location { get; set; }
        public Category Category { get; set; }
    }
}
