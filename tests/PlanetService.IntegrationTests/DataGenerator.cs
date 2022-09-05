using System;

namespace PlanetService.IntegrationTests
{
    public class DataGenerator
    {
        private static readonly Random s_random = new Random();
        public static string GetRandomPlace()
        {
            var place = s_random.Next(0, 999).ToString() + "."
                + s_random.Next(0, 999).ToString() + "."
                + s_random.Next(0, 999).ToString();

            return place;
        }
    }
}
