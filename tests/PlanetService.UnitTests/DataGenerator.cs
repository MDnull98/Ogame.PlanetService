using Bogus;
using PlanetService.BusinessLogic.Models;

namespace PlanetService.UnitTests
{
    public class DataGenerator
    {
        private static readonly Faker<Planet>? s_planetGenerator;
        private static readonly Random s_random = new Random();

        public DataGenerator(Faker<Planet> s_planetGenerator)
        {
            s_planetGenerator = new Faker<Planet>()
                .RuleFor(x => x.Diameter, (f, x) => f.Random.Int(20, 200))
                .RuleFor(x => x.Temperature, (f, x) => f.Random.Int(-20, 50))
                .RuleFor(x => x.Name, (f, u) => f.Name.FirstName())
                .RuleFor(x => x.Place, (f, u) => u.Place = GetRandomPlace());
        }

        public static Planet GenerateFakePlanet()
        {
            return s_planetGenerator.Generate();
        }

        public static string GetRandomPlace()
        {
            var place = s_random.Next(0, 999).ToString() + "."
                + s_random.Next(0, 999).ToString() + "."
                + s_random.Next(0, 999).ToString();

            return place;
        }
    }
}
