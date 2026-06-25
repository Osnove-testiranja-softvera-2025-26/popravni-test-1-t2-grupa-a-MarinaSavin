using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Models;
using TaxiApp.Services;

namespace TaxiApp.Fakes
{
    public class FakeZoneService : IZoneService
    {
        public readonly Zone _zone;

        public FakeZoneService(Zone zone) {  _zone = zone; }
        public Zone CheckZone(Guid addressFrom, Guid addressTo)
        {
            return _zone;
        }
    }
}
