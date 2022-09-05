# PlanetService

The service provides an external WebAPI for getting data about the planet and its current research, buildings, ships, defensive weapons.
And also to create and manage them through interaction with other services.

**Methods used:**
1. ResourcesService
- Getting data on the current resources of the planet, storage capacity and the level of resource growth.
- Updating the storage capacity, the amount of resources and the level of resource growth.
2. BuilderService
- Get current queue
- Adding and canceling a queue.
3. CatalogService
- Getting a list of buildings (type + description)
- Getting details of each building/research/ship.
- Getting the dependencies of the selected building/research/ships.
4. FleetService
- Getting the result of the battle for both sides (ships, guns, resources)

**Provided Methods:**
1. BuilderService
- Notification that the building/ship/cannons are completed.

# External WebAPI Methods
| Method                      | Description                                                                        |
| --------------------------- | ---------------------------------------------------------------------------------  |
| GetPlanetInfo               | Obtaining information about the planet;The queue for construction, research, ships |
| GetRecources                | Getting the current balance of the planet's resources                              |
| GetDefensiveGuns            | Obtaining data on the current defense guns of the planet                           |
| GetBuildings                | Get building types and their parameters                                            |
| GetShipments                | Getting the current ships on the planet                                            |
| CreateBuilding              | Create a building on the planet                                                    |
| CreateShipment              | Creation of a ship on the planet                                                   |
| CreateResearch              | Exploring new technology on the planet                                             |
| CreateDefensiveGuns         | Creation of protective structures on the planet                                    |

## Technologies
- PostgreSQL.  
- PostgreSQL Listen/Notify.  


## Database structure:

| Planets                   |
| ------------------------- |
| Id                        |
| Name                      |
| Diameter                  |
| Temperature               |

| ConstructionTypes         |
| ------------------------- |
| Id                        |
| Name                      |

| Constructions             |
| ------------------------- |
| Id                        |
| ConstructionTypeId        |
| Level                     |
| PlanetId                  |

| MilitaryConstructions     |
| ------------------------- |
| Id                        |
| ConstructionTypeId        |
| Count                     |
| PlanetId                  |

| Coefficients              |
| ------------------------- |
| Id                        |
| Value                     |
| ConstructionId            |
  
#### Logic:
If the user wants to build any of the buildings, he calls the PlanetService. Retrieves building types and parameters via the CatalogService. Checks if there is a build queue for this via BuilderSerivce. It then gets the current state of the resources through the ResourceService. Then, if there are enough resources to build this building, the build process in the BuilderService is started. Once the BuilderService has finished building, it will notify PlanetService and an entry will be added to the **Constructions** table.  
**MilitaryConstructions** will be added following the same logic.  
**Сoefficient table** will be stored by PlanetService and when it changes, ResourcesService will be notified about it.  

# Cases:
**Feature**: Create building  
**As a** planet owner to get benefits  
**I want to** build any construction  

**Scenario** Build started successfully  
**Given** a planet owner who want to build any construction    
**Then** building process successfully started  
**And** values of construction will be returned  

**Scenario** Building process didn't start for queue reason    
**Given** a planet owner who want to build any construction    
**Then** building process didn't start  
**And** busy queue status message will be returned   

**Scenario** The build process did not start due to lack of resources  
**Given** a planet owner who want to build any construction  
**Then** building process didn't start  
**And** a resource shortage message will be returned  

---
**Feature**: Create shipment  
**As a** planet owner to get ships  
**I want to** create any ship  

**Scenario** Build started successfully  
**Given** a planet owner who want to create any ship  
**Then** building process successfully started  
**And** message about the successful creation of the ship will be returned   

**Scenario** Building process didn't start for queue reason  
**Given** a planet owner who want to build any ship   
**Then** building process didn't start  
**And** busy queue status message will be returned  

**Scenario** The build process did not start due to lack of resources  
**Given** a planet owner who want to build any ship  
**Then** building process didn't start   
**And** a resource shortage message will be returned   

---

**Feature**: Create research   
**As a** planet owner to get new technology  
**I want to** create new technology   

**Scenario** Research successfully started  
**Given** a planet owner who want to explore new technology  
**Then** research process successfully started  
**And** message about the successful creation of the technology will be returned  

**Scenario** Technology cannot be learned due to lack of other technologies  
**Given** a planet owner who want to explore new technology   
**Then** research process didn't start   
**And** technology cannot be learned due to lack of other technologies message will be returned  

**Scenario** Technology cannot be learned due to lack of resources  
**Given** a planet owner who want to explore new technology  
**Then** research process didn't start  
**And** a resource shortage message will be returned 
 
---

**Feature**: Create defensive guns    
**As a** planet owner to get defensive guns  
**I want to** create any defensive guns   

**Scenario** Build started successfully  
**Given** a planet owner who want to create any defensive guns  
**Then** building process successfully started  
**And** message about the successful creation of the defensive guns will be returned  

**Scenario** Building process didn't start for queue reason  
**Given** a planet owner who want to build any defensive guns  
**Then** building process didn't start  
**And** busy queue status message will be returned  

**Scenario** The build process did not start due to lack of resources  
**Given** a planet owner who want to build any defensive guns  
**Then** building process didn't start  
**And** a resource shortage message will be returned   
