namespace PlanetService.BusinessLogic.Clients.CatalogClient
{
    /// <summary>
    /// Levels construction mapping model
    /// </summary>
    public class CatalogConstructionLevel
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the level value.</summary>
        /// <value>The level value.</value>
        public int LevelValue { get; set; }

        /// <summary>Gets or sets the construction id.</summary>
        /// <value>The construction id.</value>
        public Guid ConstructionId { get; set; }

        /// <summary>Gets or sets the delay in seconds.</summary>
        /// <value>The delay in seconds.</value>
        public int DelayInSeconds { get; set; }

        /// <summary>Gets or sets the energy cost.</summary>
        /// <value>The energy cost.</value>
        public int? EnergyCost { get; set; }

        /// <summary>Gets or sets the boost rocket capacity.</summary>
        /// <value>The boost rocket capacity.</value>
        public int? BoostRocketCapacity { get; set; }

        /// <summary>Gets or sets the boost ship speed percent.</summary>
        /// <value>The boost ship speed percent.</value>
        public double? BoostShipSpeedPercent { get; set; }

        /// <summary>Gets or sets the boost ship shield percent.</summary>
        /// <value>The boost ship shield percent.</value>
        public double? BoostShipShieldPercent { get; set; }

        /// <summary>Gets or sets the boost defence shield percent.</summary>
        /// <value>The boost defence shield percent.</value>
        public double? BoostDefenceShieldPercent { get; set; }

        /// <summary>Gets or sets the boost ship attack percent.</summary>
        /// <value>The boost ship attack percent.</value>
        public double? BoostShipAttackPercent { get; set; }

        /// <summary>Gets or sets the boost defence attack percent.</summary>
        /// <value>The boost defence attack percent.</value>
        public double? BoostDefenceAttackPercent { get; set; }

        /// <summary>Gets or sets the resource cost.</summary>
        /// <value>The resource cost.</value>
        public List<ResourceValue>? ResourceCost { get; set; }

        /// <summary>Gets or sets the resource produce.</summary>
        /// <value>The resource produce.</value>
        public List<ResourceValue>? ResourceProduce { get; set; }

        /// <summary>Gets or sets the boost resource capacity.</summary>
        /// <value>The boost resource capacity.</value>
        public List<ResourceValue>? BoostResourceCapacity { get; set; }

        /// <summary>Gets or sets the boost build speed.</summary>
        /// <value>The boost build speed.</value>
        public List<CatalogConstructionBoost>? BoostBuildSpeed { get; set; }
    }
}
