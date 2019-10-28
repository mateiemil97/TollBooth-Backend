using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Highway.Entities
{
    public class HighwayContext: DbContext
    {
        public HighwayContext(DbContextOptions options): base(options) { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Incomes> Incomes { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<TollBooth> TollBooth { get; set; }
        public DbSet<User> User { get; set; }
    }
}
