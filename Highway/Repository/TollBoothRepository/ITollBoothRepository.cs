using Highway.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Highway.Repository.TollBoothRepository
{
    public interface ITollBoothRepository
    {
        IEnumerable<object> GetTollBoothByLocation(int locationId);
        IEnumerable<object> GetTollBooth(int locationId, int tollboothId);

    }
}
