using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Gardens.Any())
            {
                var gardenId = Guid.NewGuid();
                var strainId = Guid.NewGuid();
                var plantId = Guid.NewGuid();
                var nutrientRecipeId = Guid.NewGuid();

                var gardens = new List<Garden>
                {
                    new Garden
                    {
                        Id = gardenId,
                        Name = "Garden A",
                        Comment = "This is a Comment",
                        Location = "Outside",
                        GrowType = "SOIL",
                        GrowSize = "{\"value\":\"7.15\",\"metric\":\"sq. ft.\"}",
                        GrowStyle = "AEROPONIC",
                        ContainerSize = "{\"value\":\"7.15\",\"metric\":\"sq. ft.\"}",
                        Tags = "[\"Tag A\", \"Tag B\"]",
                        Owner = Guid.NewGuid(),
                        Editors = "[\"Editor A\", \"Editor B\"]",
                        Created = DateTime.Now,
                        LastUpdated = DateTime.Now.AddMonths(1)
                    },
                    new Garden
                    {
                        Name = "Garden B",
                        Comment = "This is a Comment",
                        Location = "Outside",
                        GrowType = "SOIL",
                        GrowSize = "{\"value\":\"7.15\",\"metric\":\"sq. ft.\"}",
                        GrowStyle = "EBB_AND_FLOW",
                        ContainerSize = "{\"value\":\"7.15\",\"metric\":\"sq. ft.\"}",
                        Tags = "[\"Tag A\", \"Tag B\"]",
                        Owner = Guid.NewGuid(),
                        Editors = "[\"Editor A\", \"Editor B\"]",
                        Created = DateTime.Now,
                        LastUpdated = DateTime.Now.AddMonths(1)
                    },
                    new Garden
                    {
                        Name = "Garden C",
                        Comment = "This is a Comment",
                        Location = "Outside",
                        GrowType = "SOIL",
                        GrowSize = "{\"value\":\"7.15\",\"metric\":\"sq. ft.\"}",
                        GrowStyle = "DEEP_WATER_CULTURE",
                        ContainerSize = "{\"value\":\"7.15\",\"metric\":\"sq. ft.\"}",
                        Tags = "[\"Tag A\", \"Tag B\"]",
                        Owner = Guid.NewGuid(),
                        Editors = "[\"Editor A\", \"Editor B\"]",
                        Created = DateTime.Now,
                        LastUpdated = DateTime.Now.AddMonths(1)
                    }
                };

                var gardenEntries = new List<GardenEntry> {
                    new GardenEntry {
                        GardenId = gardenId,
                        Title = "Garden Entry XX1",
                        Comment = "This is a test comment",
                        Temperature = "{\"value\":74.2,\"metric\":\"F\"}",
                        Humidity = 10.2,
                        LightLevel = "{\"value\":\"8\",\"metric\":\"hours\"}",
                        Tags = "[\"Tag A\", \"Tag B\"]",
                        Editors = "[\"Editor A\"]",
                    },
                    new GardenEntry {
                        GardenId = gardenId,
                        Title = "Garden Entry XX2",
                        Comment = "This is a test comment",
                        Temperature = "{\"value\":\"74.2\",\"metric\":\"F\"}",
                        Humidity = 10.2,
                        LightLevel = "{\"value\":\"8\",\"metric\":\"hours\"}",
                        Tags = "[\"Tag A\", \"Tag B\"]",
                        Editors = "[\"Editor A\"]",
                    },
                    new GardenEntry {
                        GardenId = gardenId,
                        Title = "Garden Entry XX3",
                        Comment = "This is a test comment",
                        Temperature = "{\"value\":\"74.2\",\"metric\":\"F\"}",
                        Humidity = 10.2,
                        LightLevel = "{\"value\":\"8\",\"metric\":\"hours\"}",
                        Tags = "[\"Tag A\", \"Tag B\"]",
                        Editors = "[\"Editor A\"]",
                    },
                    new GardenEntry {
                        GardenId = gardenId,
                        Title = "Garden Entry XX4",
                        Comment = "This is a test comment",
                        Temperature = "{\"value\":\"74.2\",\"metric\":\"F\"}",
                        Humidity = 10.2,
                        LightLevel = "{\"value\":\"8\",\"metric\":\"hours\"}",
                        Tags = "[\"Tag A\", \"Tag B\"]",
                        Editors = "[\"Editor A\"]",
                    },
                    new GardenEntry {
                        GardenId = gardenId,
                        Title = "Garden Entry XX5",
                        Comment = "This is a test comment",
                        Temperature = "{\"value\":74.2,\"metric\":\"F\"}",
                        Humidity = 10.2,
                        LightLevel = "{\"value\":8,\"metric\":\"hours\"}",
                        Tags = "[\"Tag A\", \"Tag B\"]",
                        Editors = "[\"Editor A\"]",
                    }
                };

                var plants = new List<Plant> {
                    new Plant 
                    {
                        Id = plantId,
                        Name = "Plant XX1",
                        GardenId = gardenId,
                        StrainId = strainId,
                        Comment = "This is a test comment",
                        Notes = "This is a test note",
                        GrowCycleLength = "{\"value\":\"8\",\"metric\":\"weeks\"}",
                        Aquired = DateTime.Now,
                        Parentage = "N/A",
                        Origin = "N/A",
                        Gender = "Female",
                        DaysFlowering = 24,
                        DaysCured = 8,
                        HarvestedWeight = "{\"value\":\"8\",\"metric\":\"lbs\"}",
                        BudDensity = 5,
                        BudPistils = true,
                        Owner = Guid.NewGuid(),
                        Editors = "[\"Editor A\", \"Editor B\"]",
                        Created = DateTime.Now,
                        LastUpdated = DateTime.Now.AddMonths(1)
                    },
                    new Plant 
                    {
                        Name = "Plant XX2",
                        GardenId = gardenId,
                        StrainId = strainId,
                        Comment = "This is a test comment",
                        Notes = "This is a test note",
                        GrowCycleLength = "{\"value\":\"8\",\"metric\":\"weeks\"}",
                        Aquired = DateTime.Now,
                        Parentage = "N/A",
                        Origin = "Clone",
                        Gender = "FEMINIZED",
                        DaysFlowering = 24,
                        DaysCured = 8,
                        HarvestedWeight = "{\"value\":\"8\",\"metric\":\"lbs\"}",
                        BudDensity = 5,
                        BudPistils = true,
                        Owner = Guid.NewGuid(),
                        Editors = "[\"Editor A\", \"Editor B\"]",
                        Created = DateTime.Now,
                        LastUpdated = DateTime.Now.AddMonths(1)
                    },
                    new Plant 
                    {
                        Name = "Plant XX3",
                        GardenId = gardenId,
                        StrainId = Guid.NewGuid(),
                        Comment = "This is a test comment",
                        Notes = "This is a test note",
                        GrowCycleLength = "{\"value\":\"8\",\"metric\":\"weeks\"}",
                        Aquired = DateTime.Now,
                        Parentage = "N/A",
                        Origin = "SEED",
                        Gender = "FEMINIZED",
                        DaysFlowering = 24,
                        DaysCured = 8,
                        HarvestedWeight = "{\"value\":\"8\",\"metric\":\"lbs\"}",
                        BudDensity = 5,
                        BudPistils = true,
                        Owner = Guid.NewGuid(),
                        Editors = "[\"Editor A\", \"Editor B\"]",
                        Created = DateTime.Now,
                        LastUpdated = DateTime.Now.AddMonths(1)
                    },
                    new Plant 
                    {
                        Name = "Plant XX4",
                        GardenId = gardenId,
                        StrainId = strainId,
                        Comment = "This is a test comment",
                        Notes = "This is a test note",
                        GrowCycleLength = "{\"value\":\"8\",\"metric\":\"weeks\"}",
                        Aquired = DateTime.Now,
                        Parentage = "N/A",
                        Origin = "SEED",
                        Gender = "FEMINIZED",
                        DaysFlowering = 24,
                        DaysCured = 8,
                        HarvestedWeight = "{\"value\":\"8\",\"metric\":\"lbs\"}",
                        BudDensity = 5,
                        BudPistils = true,
                        Owner = Guid.NewGuid(),
                        Editors = "[\"Editor A\", \"Editor B\"]",
                        Created = DateTime.Now,
                        LastUpdated = DateTime.Now.AddMonths(1)
                    }
                };

                var plantEntries = new List<PlantEntry> {
                    new PlantEntry {
                        PlantId = plantId,
                        NutrientRecipeId = nutrientRecipeId,
                        Title = "Plant Entry XX1",
                        Comment = "This is a test comment",
                        SoilSaturation = 30.5,
                        PH = 6.4,
                        Height = "{\"value\":\"4\",\"metric\":\"ft\"}",
                        BudTrichomeColor = "White",
                        GrowState = "SEED",
                        ColaSize = "{\"value\":\"7\",\"metric\":\"in\"}",
                        AverageBudSize = "{\"value\":\"2\",\"metric\":\"in\"}",
                        StalkDiameter = "{\"value\":\"2\",\"metric\":\"cm\"}",
                        Tags = "[\"Tag A\", \"Tag B\"]",
                        Editors = "[\"Editor A\", \"Editor B\"]",
                        Created = DateTime.Now,
                        LastUpdated = DateTime.Now
                    },
                    new PlantEntry {
                        PlantId = plantId,
                        NutrientRecipeId = nutrientRecipeId,
                        Title = "Plant Entry XX2",
                        Comment = "This is a test comment",
                        SoilSaturation = 30.5,
                        PH = 6.4,
                        Height = "{\"value\":\"4\",\"metric\":\"ft\"}",
                        BudTrichomeColor = "White",
                        GrowState = "VEGETATION",
                        ColaSize = "{\"value\":\"7\",\"metric\":\"in\"}",
                        AverageBudSize = "{\"value\":\"2\",\"metric\":\"in\"}",
                        StalkDiameter = "{\"value\":\"2\",\"metric\":\"cm\"}",
                        Tags = "[\"Tag A\", \"Tag B\"]",
                        Editors = "[\"Editor A\", \"Editor B\"]",
                        Created = DateTime.Now.AddDays(14),
                        LastUpdated = DateTime.Now.AddDays(14)
                    },
                    new PlantEntry {
                        PlantId = plantId,
                        NutrientRecipeId = nutrientRecipeId,
                        Title = "Plant Entry XX3",
                        Comment = "This is a test comment",
                        SoilSaturation = 30.5,
                        PH = 6.4,
                        Height = "{\"value\":\"4\",\"metric\":\"ft\"}",
                        BudTrichomeColor = "White",
                        GrowState = "FLOWER",
                        ColaSize = "{\"value\":\"7\",\"metric\":\"in\"}",
                        AverageBudSize = "{\"value\":\"2\",\"metric\":\"in\"}",
                        StalkDiameter = "{\"value\":\"2\",\"metric\":\"cm\"}",
                        Tags = "[\"Tag A\", \"Tag B\"]",
                        Editors = "[\"Editor A\", \"Editor B\"]",
                        Created = DateTime.Now.AddDays(21),
                        LastUpdated = DateTime.Now.AddDays(21)
                    },
                    new PlantEntry {
                        PlantId = plantId,
                        NutrientRecipeId = nutrientRecipeId,
                        Title = "Plant Entry XX4",
                        Comment = "This is a test comment",
                        SoilSaturation = 30.5,
                        PH = 6.4,
                        Height = "{\"value\":\"4\",\"metric\":\"ft\"}",
                        BudTrichomeColor = "White",
                        GrowState = "HARVEST",
                        ColaSize = "{\"value\":\"7\",\"metric\":\"in\"}",
                        AverageBudSize = "{\"value\":\"2\",\"metric\":\"in\"}",
                        StalkDiameter = "{\"value\":\"2\",\"metric\":\"cm\"}",
                        Tags = "[\"Tag A\", \"Tag B\"]",
                        Editors = "[\"Editor A\", \"Editor B\"]",
                        Created = DateTime.Now.AddDays(28),
                        LastUpdated = DateTime.Now.AddDays(28)
                    }
                };

                var strains = new List<Strain> {
                    new Strain {
                        Id = strainId,
                        Name = "Strain XX1",
                        Comment = "This is a test comment",
                        Notes = "This is a test Note",
                        Aquired = DateTime.Now,
                        Price = 45.00,
                        ThcPercentage = 76.21,
                        CbdPercentage = 10.08,
                        Parentage = "N/A",
                        Aroma = "[\"Citrus\", \"Strawberry\"]",
                        Taste = "[\"Citrus\", \"Strawberry\"]",
                        Tags = "[\"Tag A\", \"Tag B\"]",
                        Editors = "[\"Editor A\", \"Editor B\"]",
                        Created = DateTime.Now,
                        LastUpdated = DateTime.Now
                    },
                    new Strain {
                        Name = "Strain XX2",
                        Comment = "This is a test comment",
                        Notes = "This is a test Note",
                        Aquired = DateTime.Now,
                        Price = 45.00,
                        ThcPercentage = 76.21,
                        CbdPercentage = 10.08,
                        Parentage = "N/A",
                        Aroma = "[\"Citrus\", \"Strawberry\"]",
                        Taste = "[\"Citrus\", \"Strawberry\"]",
                        Tags = "[\"Tag A\", \"Tag B\"]",
                        Editors = "[\"Editor A\", \"Editor B\"]",
                        Created = DateTime.Now,
                        LastUpdated = DateTime.Now
                    }
                };

                var nutrientRecipes = new List<NutrientRecipe> {
                    new NutrientRecipe {
                        Id = nutrientRecipeId,
                        Name = "Nutrient Recipe XX1",
                        Comment = "This is a test comment",
                        Instructions = "This is test instructions",
                        PH = "7.12",
                        MixTime = "{\"value\":\"12\",\"metric\":\"minutes\"}",
                        Tags = "[\"Tag A\", \"Tag B\"]",
                        Owner = Guid.NewGuid(),
                        Editors = "[\"Editor A\", \"Editor B\"]",
                        Created = DateTime.Now,
                        LastUpdated = DateTime.Now,
                    },
                    new NutrientRecipe {
                        Name = "Nutrient Recipe XX2",
                        Comment = "This is a test comment",
                        Instructions = "This is test instructions",
                        PH = "7.12",
                        MixTime = "{\"value\":\"12\",\"metric\":\"minutes\"}",
                        Tags = "[\"Tag A\", \"Tag B\"]",
                        Owner = Guid.NewGuid(),
                        Editors = "[\"Editor A\", \"Editor B\"]",
                        Created = DateTime.Now,
                        LastUpdated = DateTime.Now,
                    }
                };

                context.Gardens.AddRange(gardens);
                context.GardenEntries.AddRange(gardenEntries);
                context.Plants.AddRange(plants);
                context.PlantEntries.AddRange(plantEntries);
                context.Strains.AddRange(strains);
                context.NutrientRecipes.AddRange(nutrientRecipes);
                context.SaveChanges();
            }
        }
    }
}