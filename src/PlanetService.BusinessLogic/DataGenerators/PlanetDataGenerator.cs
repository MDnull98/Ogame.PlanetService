namespace PlanetService.BusinessLogic.DataGenerators
{
    /// <summary>Planet Data generator</summary>
    public class PlanetDataGenerator
    {

        private static readonly Random s_random = new Random();

        /// <summary>Gets the random place.</summary>
        /// <returns>Place.</returns>
        public static string GetRandomPlace()
        {
            var place = s_random.Next(0, 999).ToString() + "."
                + s_random.Next(0, 999).ToString() + "."
                + s_random.Next(0, 999).ToString();

            return place;
        }

        /// <summary>Gets the random diameter.</summary>
        /// <returns>Diameter</returns>
        public static int GetRandomDiameter()
        {
            return s_random.Next(6000, 20000);
        }

        /// <summary>Gets the random temperature.</summary>
        /// <returns>Temperature.</returns>
        public static int GetRandomTemperature()
        {
            return s_random.Next(-50, 50);
        }
    }
}
