using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Models;
using TaxiApp.Services;

namespace TaxiApp.Fakes
{
    public class FakeDriveService : IDriveService
    {
        public readonly List<Drive> _availableDrive;

        public FakeDriverService (List<Drive> availableDrive)
        {
            _availableDrive= availableDrive;
        }
        public List<Drive> GetAvalilableDrives(Guid addressFrom, Guid addressTo, DateTime time)
        {
            return _availableDrive;
        }
    }
}
