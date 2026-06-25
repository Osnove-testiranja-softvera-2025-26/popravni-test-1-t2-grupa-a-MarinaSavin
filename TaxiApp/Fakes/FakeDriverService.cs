using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Models;
using TaxiApp.Services;

namespace TaxiApp.Fakes
{
    public class FakeDriverService : IDriverService
    {
       public List<Drive> drives { get; }= new List<Drive>
        public void AssignDriveToDriver(Drive drive)
        {
            drives.Add(drive);
        }
    }
}
