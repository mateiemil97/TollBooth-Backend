using Highway.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Highway.Repository.PriceRepository
{
    public interface IPriceRepository
    {
        object GetPriceByLocationAndCategory(int locId, int catId);
    }
}
