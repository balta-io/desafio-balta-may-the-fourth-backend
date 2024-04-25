using May.The.Fourth.Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace May.The.Fourth.Backend.Data.Factories;

public static class StarShipFactory
{
    public static void Execute(ModelBuilder modelBuilder)
    {
        var starships = new[]
        {
            new StarshipEntity
            {
                Id = 2, Name = "CR90 corvette", Model = "CR90 corvette",
                Manufacturer = "Corellian Engineering Corporation", CostInCredits = "3500000", Length = "150",
                MaxSpeed = "950", Crew = "30-165", Passengers = "600", CargoCapacity = "3000000",
                HyperdriveRating = "2.0", Mglt = "60", Consumables = "1 year", Class = "corvette",
            },
            new StarshipEntity
            {
                Id = 3, Name = "Star Destroyer", Model = "Imperial I-class Star Destroyer",
                Manufacturer = "Kuat Drive Yards", CostInCredits = "150000000", Length = "1,600", MaxSpeed = "975",
                Crew = "47,060", Passengers = "n/a", CargoCapacity = "36000000", HyperdriveRating = "2.0", Mglt = "60",
                Consumables = "2 years", Class = "Star Destroyer",
            },
            new StarshipEntity
            {
                Id = 5, Name = "Sentinel-class landing craft", Model = "Sentinel-class landing craft",
                Manufacturer = "Sienar Fleet Systems, Cyngus Spaceworks", CostInCredits = "240000", Length = "38",
                MaxSpeed = "1000", Crew = "5", Passengers = "75", CargoCapacity = "180000", HyperdriveRating = "1.0",
                Mglt = "70", Consumables = "1 month", Class = "landing craft",
            },
            new StarshipEntity
            {
                Id = 9, Name = "Death Star", Model = "DS-1 Orbital Battle Station",
                Manufacturer = "Imperial Department of Military Research, Sienar Fleet Systems",
                CostInCredits = "1000000000000", Length = "120000", MaxSpeed = "n/a", Crew = "342,953",
                Passengers = "843,342", CargoCapacity = "1000000000000", HyperdriveRating = "4.0", Mglt = "10",
                Consumables = "3 years", Class = "Deep Space Mobile Battlestation",
            },
            new StarshipEntity
            {
                Id = 10, Name = "Millennium Falcon", Model = "YT-1300 light freighter",
                Manufacturer = "Corellian Engineering Corporation", CostInCredits = "100000", Length = "34.37",
                MaxSpeed = "1050", Crew = "4", Passengers = "6", CargoCapacity = "100000", HyperdriveRating = "0.5",
                Mglt = "75", Consumables = "2 months", Class = "Light freighter",
            },
            new StarshipEntity
            {
                Id = 11, Name = "Y-wing", Model = "BTL Y-wing", Manufacturer = "Koensayr Manufacturing",
                CostInCredits = "134999", Length = "14", MaxSpeed = "1000km", Crew = "2", Passengers = "0",
                CargoCapacity = "110", HyperdriveRating = "1.0", Mglt = "80", Consumables = "1 week",
                Class = "assault starfighter",
            },
            new StarshipEntity
            {
                Id = 12, Name = "X-wing", Model = "T-65 X-wing", Manufacturer = "Incom Corporation",
                CostInCredits = "149999", Length = "12.5", MaxSpeed = "1050", Crew = "1", Passengers = "0",
                CargoCapacity = "110", HyperdriveRating = "1.0", Mglt = "100", Consumables = "1 week",
                Class = "Starfighter",
            },
            new StarshipEntity
            {
                Id = 13, Name = "TIE Advanced x1", Model = "Twin Ion Engine Advanced x1",
                Manufacturer = "Sienar Fleet Systems", CostInCredits = "unknown", Length = "9.2", MaxSpeed = "1200",
                Crew = "1", Passengers = "0", CargoCapacity = "150", HyperdriveRating = "1.0", Mglt = "105",
                Consumables = "5 days", Class = "Starfighter",
            },
            new StarshipEntity
            {
                Id = 15, Name = "Executor", Model = "Executor-class star dreadnought",
                Manufacturer = "Kuat Drive Yards, Fondor Shipyards", CostInCredits = "1143350000", Length = "19000",
                MaxSpeed = "n/a", Crew = "279,144", Passengers = "38000", CargoCapacity = "250000000",
                HyperdriveRating = "2.0", Mglt = "40", Consumables = "6 years", Class = "Star dreadnought",
            },
            new StarshipEntity
            {
                Id = 17, Name = "Rebel transport", Model = "GR-75 medium transport",
                Manufacturer = "Gallofree Yards, Inc.", CostInCredits = "unknown", Length = "90", MaxSpeed = "650",
                Crew = "6", Passengers = "90", CargoCapacity = "19000000", HyperdriveRating = "4.0", Mglt = "20",
                Consumables = "6 months", Class = "Medium transport",
            },
            new StarshipEntity
            {
                Id = 21, Name = "Slave 1", Model = "Firespray-31-class patrol and attack",
                Manufacturer = "Kuat Systems Engineering", CostInCredits = "unknown", Length = "21.5",
                MaxSpeed = "1000", Crew = "1", Passengers = "6", CargoCapacity = "70000", HyperdriveRating = "3.0",
                Mglt = "70", Consumables = "1 month", Class = "Patrol craft",
            },
            new StarshipEntity
            {
                Id = 22, Name = "Imperial shuttle", Model = "Lambda-class T-4a shuttle",
                Manufacturer = "Sienar Fleet Systems", CostInCredits = "240000", Length = "20", MaxSpeed = "850",
                Crew = "6", Passengers = "20", CargoCapacity = "80000", HyperdriveRating = "1.0", Mglt = "50",
                Consumables = "2 months", Class = "Armed government transport",
            },
            new StarshipEntity
            {
                Id = 23, Name = "EF76 Nebulon-B escort frigate", Model = "EF76 Nebulon-B escort frigate",
                Manufacturer = "Kuat Drive Yards", CostInCredits = "8500000", Length = "300", MaxSpeed = "800",
                Crew = "854", Passengers = "75", CargoCapacity = "6000000", HyperdriveRating = "2.0", Mglt = "40",
                Consumables = "2 years", Class = "Escort ship",
            },
            new StarshipEntity
            {
                Id = 27, Name = "Calamari Cruiser", Model = "MC80 Liberty type Star Cruiser",
                Manufacturer = "Mon Calamari shipyards", CostInCredits = "104000000", Length = "1200", MaxSpeed = "n/a",
                Crew = "5400", Passengers = "1200", CargoCapacity = "unknown", HyperdriveRating = "1.0", Mglt = "60",
                Consumables = "2 years", Class = "Star Cruiser",
            },
            new StarshipEntity
            {
                Id = 28, Name = "A-wing", Model = "RZ-1 A-wing Interceptor",
                Manufacturer = "Alliance Underground Engineering, Incom Corporation", CostInCredits = "175000",
                Length = "9.6", MaxSpeed = "1300", Crew = "1", Passengers = "0", CargoCapacity = "40",
                HyperdriveRating = "1.0", Mglt = "120", Consumables = "1 week", Class = "Starfighter",
            },
            new StarshipEntity
            {
                Id = 29, Name = "B-wing", Model = "A/SF-01 B-wing starfighter", Manufacturer = "Slayn & Korpil",
                CostInCredits = "220000", Length = "16.9", MaxSpeed = "950", Crew = "1", Passengers = "0",
                CargoCapacity = "45", HyperdriveRating = "2.0", Mglt = "91", Consumables = "1 week",
                Class = "Assault Starfighter",
            },
            new StarshipEntity
            {
                Id = 31, Name = "Republic Cruiser", Model = "Consular-class cruiser",
                Manufacturer = "Corellian Engineering Corporation", CostInCredits = "unknown", Length = "115",
                MaxSpeed = "900", Crew = "9", Passengers = "16", CargoCapacity = "unknown", HyperdriveRating = "2.0",
                Mglt = "unknown", Consumables = "unknown", Class = "Space cruiser",
            },
            new StarshipEntity
            {
                Id = 32, Name = "Droid control ship", Model = "Lucrehulk-class Droid Control Ship",
                Manufacturer = "Hoersch-Kessel Drive, Inc.", CostInCredits = "unknown", Length = "3170",
                MaxSpeed = "n/a", Crew = "175", Passengers = "139000", CargoCapacity = "4000000000",
                HyperdriveRating = "2.0", Mglt = "unknown", Consumables = "500 days", Class = "Droid control ship",
            },
            new StarshipEntity
            {
                Id = 39, Name = "Naboo fighter", Model = "N-1 starfighter",
                Manufacturer = "Theed Palace Space Vessel Engineering Corps", CostInCredits = "200000", Length = "11",
                MaxSpeed = "1100", Crew = "1", Passengers = "0", CargoCapacity = "65", HyperdriveRating = "1.0",
                Mglt = "unknown", Consumables = "7 days", Class = "Starfighter",
            },
            new StarshipEntity
            {
                Id = 40, Name = "Naboo Royal Starship", Model = "J-type 327 Nubian royal starship",
                Manufacturer = "Theed Palace Space Vessel Engineering Corps, Nubia Star Drives",
                CostInCredits = "unknown", Length = "76", MaxSpeed = "920", Crew = "8", Passengers = "unknown",
                CargoCapacity = "unknown", HyperdriveRating = "1.8", Mglt = "unknown", Consumables = "unknown",
                Class = "yacht",
            },
            new StarshipEntity
            {
                Id = 41, Name = "Scimitar", Model = "Star Courier", Manufacturer = "Republic Sienar Systems",
                CostInCredits = "55000000", Length = "26.5", MaxSpeed = "1180", Crew = "1", Passengers = "6",
                CargoCapacity = "2500000", HyperdriveRating = "1.5", Mglt = "unknown", Consumables = "30 days",
                Class = "Space Transport",
            },
            new StarshipEntity
            {
                Id = 43, Name = "J-type diplomatic barge", Model = "J-type diplomatic barge",
                Manufacturer = "Theed Palace Space Vessel Engineering Corps, Nubia Star Drives",
                CostInCredits = "2000000", Length = "39", MaxSpeed = "2000", Crew = "5", Passengers = "10",
                CargoCapacity = "unknown", HyperdriveRating = "0.7", Mglt = "unknown", Consumables = "1 year",
                Class = "Diplomatic barge",
            },
            new StarshipEntity
            {
                Id = 47, Name = "AA-9 Coruscant freighter", Model = "Botajef AA-9 Freighter-Liner",
                Manufacturer = "Botajef Shipyards", CostInCredits = "unknown", Length = "390", MaxSpeed = "unknown",
                Crew = "unknown", Passengers = "30000", CargoCapacity = "unknown", HyperdriveRating = "unknown",
                Mglt = "unknown", Consumables = "unknown", Class = "freighter",
            },
            new StarshipEntity
            {
                Id = 48, Name = "Jedi starfighter", Model = "Delta-7 Aethersprite-class interceptor",
                Manufacturer = "Kuat Systems Engineering", CostInCredits = "180000", Length = "8", MaxSpeed = "1150",
                Crew = "1", Passengers = "0", CargoCapacity = "60", HyperdriveRating = "1.0", Mglt = "unknown",
                Consumables = "7 days", Class = "Starfighter",
            },
            new StarshipEntity
            {
                Id = 49, Name = "H-type Nubian yacht", Model = "H-type Nubian yacht",
                Manufacturer = "Theed Palace Space Vessel Engineering Corps", CostInCredits = "unknown",
                Length = "47.9", MaxSpeed = "8000", Crew = "4", Passengers = "unknown", CargoCapacity = "unknown",
                HyperdriveRating = "0.9", Mglt = "unknown", Consumables = "unknown", Class = "yacht",
            },
            new StarshipEntity
            {
                Id = 52, Name = "Republic Assault ship", Model = "Acclamator I-class assault ship",
                Manufacturer = "Rothana Heavy Engineering", CostInCredits = "unknown", Length = "752",
                MaxSpeed = "unknown", Crew = "700", Passengers = "16000", CargoCapacity = "11250000",
                HyperdriveRating = "0.6", Mglt = "unknown", Consumables = "2 years", Class = "assault ship",
            },
            new StarshipEntity
            {
                Id = 58, Name = "Solar Sailer", Model = "Punworcca 116-class interstellar sloop",
                Manufacturer = "Huppla Pasa Tisc Shipwrights Collective", CostInCredits = "35700", Length = "15.2",
                MaxSpeed = "1600", Crew = "3", Passengers = "11", CargoCapacity = "240", HyperdriveRating = "1.5",
                Mglt = "unknown", Consumables = "7 days", Class = "yacht",
            },
            new StarshipEntity
            {
                Id = 59, Name = "Trade Federation cruiser", Model = "Providence-class carrier/destroyer",
                Manufacturer = "Rendili StarDrive, Free Dac Volunteers Engineering corps.", CostInCredits = "125000000",
                Length = "1088", MaxSpeed = "1050", Crew = "600", Passengers = "48247", CargoCapacity = "50000000",
                HyperdriveRating = "1.5", Mglt = "unknown", Consumables = "4 years", Class = "capital ship",
            },
            new StarshipEntity
            {
                Id = 61, Name = "Theta-class T-2c shuttle", Model = "Theta-class T-2c shuttle",
                Manufacturer = "Cygnus Spaceworks", CostInCredits = "1000000", Length = "18.5", MaxSpeed = "2000",
                Crew = "5", Passengers = "16", CargoCapacity = "50000", HyperdriveRating = "1.0", Mglt = "unknown",
                Consumables = "56 days", Class = "transport",
            },
            new StarshipEntity
            {
                Id = 63, Name = "Republic attack cruiser", Model = "Senator-class Star Destroyer",
                Manufacturer = "Kuat Drive Yards, Allanteen Six shipyards", CostInCredits = "59000000", Length = "1137",
                MaxSpeed = "975", Crew = "7400", Passengers = "2000", CargoCapacity = "20000000",
                HyperdriveRating = "1.0", Mglt = "unknown", Consumables = "2 years", Class = "star destroyer",
            },
            new StarshipEntity
            {
                Id = 64, Name = "Naboo star skiff", Model = "J-type star skiff",
                Manufacturer = "Theed Palace Space Vessel Engineering Corps/Nubia Star Drives, Incorporated",
                CostInCredits = "unknown", Length = "29.2", MaxSpeed = "1050", Crew = "3", Passengers = "3",
                CargoCapacity = "unknown", HyperdriveRating = "0.5", Mglt = "unknown", Consumables = "unknown",
                Class = "yacht",
            },
            new StarshipEntity
            {
                Id = 65, Name = "Jedi Interceptor", Model = "Eta-2 Actis-class light interceptor",
                Manufacturer = "Kuat Systems Engineering", CostInCredits = "320000", Length = "5.47", MaxSpeed = "1500",
                Crew = "1", Passengers = "0", CargoCapacity = "60", HyperdriveRating = "1.0", Mglt = "unknown",
                Consumables = "2 days", Class = "starfighter",
            },
            new StarshipEntity
            {
                Id = 66, Name = "arc-170", Model = "Aggressive Reconnaissance-170 starfighte",
                Manufacturer = "Incom Corporation, Subpro Corporation", CostInCredits = "155000", Length = "14.5",
                MaxSpeed = "1000", Crew = "3", Passengers = "0", CargoCapacity = "110", HyperdriveRating = "1.0",
                Mglt = "100", Consumables = "5 days", Class = "starfighter",
            },
            new StarshipEntity
            {
                Id = 68, Name = "Banking clan frigte", Model = "Munificent-class star frigate",
                Manufacturer = "Hoersch-Kessel Drive, Inc, Gwori Revolutionary Industries", CostInCredits = "57000000",
                Length = "825", MaxSpeed = "unknown", Crew = "200", Passengers = "unknown", CargoCapacity = "40000000",
                HyperdriveRating = "1.0", Mglt = "unknown", Consumables = "2 years", Class = "cruiser",
            },
            new StarshipEntity
            {
                Id = 74, Name = "Belbullab-22 starfighter", Model = "Belbullab-22 starfighter",
                Manufacturer = "Feethan Ottraw Scalable Assemblies", CostInCredits = "168000", Length = "6.71",
                MaxSpeed = "1100", Crew = "1", Passengers = "0", CargoCapacity = "140", HyperdriveRating = "6",
                Mglt = "unknown", Consumables = "7 days", Class = "starfighter",
            },
            new StarshipEntity
            {
                Id = 75, Name = "V-wing", Model = "Alpha-3 Nimbus-class V-wing starfighter",
                Manufacturer = "Kuat Systems Engineering", CostInCredits = "102500", Length = "7.9", MaxSpeed = "1050",
                Crew = "1", Passengers = "0", CargoCapacity = "60", HyperdriveRating = "1.0", Mglt = "unknown",
                Consumables = "15 hours", Class = "starfighter",
            },
        };
        modelBuilder.Entity<StarshipEntity>().HasData(starships);
    }
}