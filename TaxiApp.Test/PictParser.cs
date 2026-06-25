using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Models;

namespace TaxiApp.Test
{
    internal class PictParser
    {
        private static readonly string PictResultsPath = Path.Combine(
       AppDomain.CurrentDomain.BaseDirectory, "PictResults.txt");

        public static IEnumerable<TestCaseData> GetTestCases()
        {
            string[] lines = File.ReadAllLines(PictResultsPath);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split('\t');

                if (parts.Length < 6)
                    continue;

                TaxiZone zone = (TaxiZone)Enum.Parse(typeof(TaxiZone), parts[0].Trim());
                int hour = int.Parse(parts[1].Trim());
                int numOfInterections = int.Parse(parts[2].Trim());
                WeatherConditions weatherConditions = (WeatherConditions)Enum.Parse(typeof(WeatherConditions), parts[3].Trim());
                bool railwayCrossing = bool.Parse(parts[4].Trim());
                int crowdFactor = int.Parse(parts[5].Trim());

                yield return new TestCaseData(zone, hour, numOfInterections, weatherConditions, railwayCrossing, crowdfactor).SetName(
                    $"ExpectedFactor: {expectedResult}" +
                    $"Zone:{zone}" +
                    $"Interactions: {numOfInterections}" +
                    $"weather: {weather}" +
                    $"RaiyWay Crossing :{true}"


                    );
            }
        }
    }
}
