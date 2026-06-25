

using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TaxiApp.Exceptions;
using TaxiApp.Fakes;
using TaxiApp.Models;
using TaxiApp.Services;

namespace TaxiApp.Test
{
    //Guid example: "00000000-0000-0000-0000-000000000000"

    public class TaxiServiceTest
    {
        private FakeDriverService _fakeDriverService;
        private FakeDriveService _fakeDriveService;
        private FakeZoneService _fakeZoneService;
        private TaxiService _taxiService;

        [SetUp]
        public void SetUp()
        {
            _fakeDriveService = new FakeDriveService(new List<Drive>
         {
             new Drive
             {
                 Distance=400,
                 EstimatedTotalTravelTimeInMinutes=20,
                 EstimatedStopTimeInMinutes=3,
                 EstimatedWaitTimeInMinutes=3,
                 StartingPrice=10,
                 Assigned=true
             }
         });
            _fakeZoneService = new FakeZoneService(Zone.Green);

            _fakeDriverService = new FakeDriverService();

            _taxiService = new TaxiService(_fakeZoneService, _fakeDriveService, _fakeDriverService);

        }

        [TestCaseSource(typeof(PictParser), nameof(PictParser.GetTestCases))]
        public void CalculateCrowdfactor_ReturnsCrowdFactor(Zone zone, int hour, int numOfInterections, WeatherConditions weatherConditions, bool railwayCrossing, int crowdFactor)
        {
            int result = _taxiService.CalculateCrowdFactor(zone, hour, numOfInterections, weatherConditions, railwayCrossing);
            Assert.That(result, Is.EqualTo(crowdFactor));
        }

        [Test]
        public void Price3AndHalf()
        {
            var from = new Address
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000")
            };
            var to = new Address
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000")   /*Testove sam radila tako da kad dodam jednu voznju ona je automatski i sa najmanjim vremenom*/
            };

            var drive = new Drive
            {
                Distance = 1500,
                EstimatedWaitTimeInMinutes = 6,
                EstimatedTotalTravelTimeInMinutes = 10
            };

            _fakeDriveService = new FakeDriveService(new List<Drive> { drive });
            _fakeZoneService = new FakeZoneService(Zone.Blue);
            _fakeDriverService = new FakeDriverService();

            _taxiService = new TaxiService(_fakeDriveService, _fakeZoneService, _fakeDriverService);

            _taxiService.AssignDrive(from, to, DateTime.Now);

            Assert.That(_fakeDriverService.drives.Count, Is.EqualTo(1));
            Assert.That(_fakeDriverService.drives[0].StartingPrice, Is.EqualTo(3.5));
        }

        [Test]
        public void Price3()
        {
            var from = new Address
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000")
            };
            var to = new Address
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000")
            };

            var drive = new Drive
            {
                Distance = 1500,
                EstimatedWaitTimeInMinutes = 2,
                EstimatedTotalTravelTimeInMinutes = 10
            };

            _fakeDriveService = new FakeDriveService(new List<Drive> { drive });
            _fakeZoneService = new FakeZoneService(Zone.Blue);
            _fakeDriverService = new FakeDriverService();

            _taxiService = new TaxiService(_fakeDriveService, _fakeZoneService, _fakeDriverService);

            _taxiService.AssignDrive(from, to, DateTime.Now);

            Assert.That(_fakeDriverService.drives.Count, Is.EqualTo(1));
            Assert.That(_fakeDriverService.drives[0].StartingPrice, Is.EqualTo(3));
        }
        [Test]
        public void Price4I()
        {
            var from = new Address
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000")
            };
            var to = new Address
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000")
            };

            var drive = new Drive
            {
                Distance = 1000,
                EstimatedWaitTimeInMinutes = 6,
                EstimatedTotalTravelTimeInMinutes = 30
            };

            _fakeDriveService = new FakeDriveService(new List<Drive> { drive });
            _fakeZoneService = new FakeZoneService(Zone.Green);
            _fakeDriverService = new FakeDriverService();

            _taxiService = new TaxiService(_fakeDriveService, _fakeZoneService, _fakeDriverService);

            _taxiService.AssignDrive(from, to, DateTime.Now);

            Assert.That(_fakeDriverService.drives.Count, Is.EqualTo(1));
            Assert.That(_fakeDriverService.drives[0].StartingPrice, Is.EqualTo(4.0));
        }
        [Test]
        public void Price4II()
        {
            var from = new Address
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000")
            };
            var to = new Address
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000")
            };

            var drive = new Drive
            {
                Distance = 1500,
                EstimatedWaitTimeInMinutes = 6,
                EstimatedTotalTravelTimeInMinutes = 15
            };

            _fakeDriveService = new FakeDriveService(new List<Drive> { drive });
            _fakeZoneService = new FakeZoneService(Zone.Green);
            _fakeDriverService = new FakeDriverService();

            _taxiService = new TaxiService(_fakeDriveService, _fakeZoneService, _fakeDriverService);

            _taxiService.AssignDrive(from, to, DateTime.Now);

            Assert.That(_fakeDriverService.drives.Count, Is.EqualTo(1));
            Assert.That(_fakeDriverService.drives[0].StartingPrice, Is.EqualTo(4.0));
        }
        [Test]
        public void Price4III()
        {
            var from = new Address
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000")
            };
            var to = new Address
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000")
            };

            var drive = new Drive
            {
                Distance = 1500,
                EstimatedWaitTimeInMinutes = 6,
                EstimatedTotalTravelTimeInMinutes = 25
            };

            _fakeDriveService = new FakeDriveService(new List<Drive> { drive });
            _fakeZoneService = new FakeZoneService(Zone.Green);
            _fakeDriverService = new FakeDriverService();

            _taxiService = new TaxiService(_fakeDriveService, _fakeZoneService, _fakeDriverService);

            _taxiService.AssignDrive(from, to, DateTime.Now);

            Assert.That(_fakeDriverService.drives.Count, Is.EqualTo(1));
            Assert.That(_fakeDriverService.drives[0].StartingPrice, Is.EqualTo(4.0));
        }
        [Test]
        public void Price3AndHalf()
        {
            var from = new Address
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000")
            };
            var to = new Address
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000")
            };

            var drive = new Drive
            {
                Distance = 1000,
                EstimatedWaitTimeInMinutes = 6,
                EstimatedTotalTravelTimeInMinutes = 15
            };

            _fakeDriveService = new FakeDriveService(new List<Drive> { drive });
            _fakeZoneService = new FakeZoneService(Zone.Green);
            _fakeDriverService = new FakeDriverService();

            _taxiService = new TaxiService(_fakeDriveService, _fakeZoneService, _fakeDriverService);

            _taxiService.AssignDrive(from, to, DateTime.Now);

            Assert.That(_fakeDriverService.drives.Count, Is.EqualTo(1));
            Assert.That(_fakeDriverService.drives[0].StartingPrice, Is.EqualTo(3.5));
        }
        [Test]
        public void Price2I()
        {
            var from = new Address
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000")
            };
            var to = new Address
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000")
            };

            var drive = new Drive
            {
                Distance = 1000,
                EstimatedWaitTimeInMinutes = 6,
                EstimatedTotalTravelTimeInMinutes = 15
            };

            _fakeDriveService = new FakeDriveService(new List<Drive> { drive });
            _fakeZoneService = new FakeZoneService(Zone.Red);
            _fakeDriverService = new FakeDriverService();

            _taxiService = new TaxiService(_fakeDriveService, _fakeZoneService, _fakeDriverService);

            _taxiService.AssignDrive(from, to, DateTime.Now);

            Assert.That(_fakeDriverService.drives.Count, Is.EqualTo(1));
            Assert.That(_fakeDriverService.drives[0].StartingPrice, Is.EqualTo(2.0));
        }
        [Test]
        public void Price2II()
        {
            var from = new Address
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000")
            };
            var to = new Address
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000")
            };

            var drive = new Drive
            {
                Distance = 800,
                EstimatedWaitTimeInMinutes = 6,
                EstimatedTotalTravelTimeInMinutes = 15
            };

            _fakeDriveService = new FakeDriveService(new List<Drive> { drive });
            _fakeZoneService = new FakeZoneService(Zone.Blue);
            _fakeDriverService = new FakeDriverService();

            _taxiService = new TaxiService(_fakeDriveService, _fakeZoneService, _fakeDriverService);

            _taxiService.AssignDrive(from, to, DateTime.Now);

            Assert.That(_fakeDriverService.drives.Count, Is.EqualTo(1));
            Assert.That(_fakeDriverService.drives[0].StartingPrice, Is.EqualTo(2.0));
        }
        [Test]
        public void Exception()
        {
            var from = new Address
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000")
            };
            var to = new Address
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000")
            };

            var drive = new Drive
            {
                Distance = 1000,
                EstimatedWaitTimeInMinutes = 6,
                EstimatedTotalTravelTimeInMinutes = 15
            };
            var availableList = new List<Drive>();
            var driverservice = Substitute.For<IDriverService>();
            var driveservice = Substitute.For<IDriveService>();
            var zoneservice = Substitute.For<IZoneService>();

            driveservice.GetAvalilableDrives(from.Id, to.Id, DateTime.Now).Returns(availableList);
            zoneservice.CheckZone(from.Id, to.Id).Returns(Zone.Green);

            var service = new TaxiService(zoneservice, driveservice, driverservice);
            
            Assert.Throws<NoAvailableDriveExeption>()((TestDelegate)(() => service.AssignDrive(from, to, DateTime.Now)));


        }







    }
}
