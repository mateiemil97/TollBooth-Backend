using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Highway.Entities;

namespace Highway.Repository.TollBoothRepository
{
    public class TollBoothRepository : ITollBoothRepository
    {
        private HighwayContext _ctx;

        public TollBoothRepository(HighwayContext ctx)
        {
            _ctx = ctx;
        }

  
        public IEnumerable<object> GetTollBoothByLocation(int locationId)
        {
            var tollbooths = (from p in _ctx.Price
                             join tb in _ctx.TollBooth on p.Id equals tb.PriceId
                             join l in _ctx.Location on p.LocationId equals l.Id
                             where p.LocationId == locationId
                             select new
                             {
                                 Id = tb.Id,
                                 Name = tb.Name,
                                 //PiceId = tb.PriceId
                             });
            return tollbooths;
        }

        public IEnumerable<object> GetTollBooth(int locationId, int tollboothId)
        {
            var tollbooths = (from p in _ctx.Price
                              join tb in _ctx.TollBooth on p.Id equals tb.PriceId
                              join l in _ctx.Location on p.LocationId equals l.Id
                              where p.LocationId == locationId && tb.Id == tollboothId
                              select new
                              {
                                  Id = tb.Id,
                                  Name = tb.Name,
                                  //PiceId = tb.PriceId
                              });
            return tollbooths;
        }
    }
}
