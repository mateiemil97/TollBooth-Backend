using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Highway.Entities;

namespace Highway.Repository.PriceRepository
{
    public class PriceRepository : IPriceRepository
    {
        private HighwayContext _context;

        public PriceRepository(HighwayContext ctx)
        {
            _context = ctx;
        }

        public object GetPriceByLocationAndCategory(int locId, int catId)
        {
           var priceByCatAndLoc = (from p in _context.Price
              join c in _context.Category on p.CategoryId equals c.Id
              join l in _context.Location on p.CategoryId equals l.Id
              where p.LocationId == locId && p.CategoryId == catId 
              select new
              {
                  LocationId = p.LocationId,
                  Location = l.Name,
                  CategoryId = p.CategoryId,
                  Category = c.Name,
                  PriceId = p.Id,
                  Price = p.Amount

              });
            return priceByCatAndLoc;
        }
    }
}
