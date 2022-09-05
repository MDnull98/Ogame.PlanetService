namespace PlanetService.BusinessLogic.Clients.MissionClient
{
    /// <summary>Spaceship value.</summary>
    public class SpaceshipValue
    {
        /// <summary>Gets or sets the type.</summary>
        /// <value>The type.</value>
        public SpaceshipClassification Type { get; set; }
        /// <summary>Gets or sets the amount.</summary>
        /// <value>The amount.</value>
        public int Amount { get; set; }
    }

    /// <summary>Spaceship classification</summary>
    public enum SpaceshipClassification
    {
        /// <summary>The none</summary>
        None = 0,

        /// <summary>The fighter light ship</summary>
        LightFighter = 1,

        /// <summary>The fighter heavy ship</summary>
        HeavyFighter = 2,

        /// <summary>The cruiser ship</summary>
        Cruiser = 3,

        /// <summary>The battleship ship</summary>
        Battleship = 4,

        /// <summary>The battleCruiser ship</summary>
        BattleCruiser = 5,

        /// <summary>The bomber ship</summary>
        Bomber = 6,

        /// <summary>The destroyer ship</summary>
        Destroyer = 7,

        /// <summary>The deathstar ship</summary>
        Deathstar = 8,

        /// <summary>The small cargo small ship</summary>
        SmallCargo = 9,

        /// <summary>The large cargo ship</summary>
        LargeCargo = 10,

        /// <summary>The colony ship</summary>
        ColonyShip = 11,

        /// <summary>The recycler ship</summary>
        Recycler = 12,

        /// <summary>The espionage probe</summary>
        EspionageProbe = 13,

        /// <summary>The solar satellite</summary>
        SolarSatellite = 14,

    }
}
