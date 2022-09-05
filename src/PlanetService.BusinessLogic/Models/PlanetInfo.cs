using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetService.BusinessLogic.Models
{
    /// <summary>PlanetInfo class</summary>
    public class PlanetInfo
    {
        /// <summary>
        /// Gets or sets the planet.
        /// </summary>
        /// <value>
        /// The planet.
        /// </value>
        public Planet Planet { get; set; }

        /// <summary>
        /// Gets or sets the planet place.
        /// </summary>
        /// <value>
        /// The planet place.
        /// </value>
        public List<BuildingQueue> BuildingQueues { get; set; }
    }
}
