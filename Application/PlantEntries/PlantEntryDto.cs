using System;

namespace Application.PlantEntries
{
    public class PlantEntryDto
    {
        public Guid Id { get; set; }
        public Guid PlantId { get; set; }
        public Guid NutrientRecipeId { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public double SoilSaturation { get; set; }
        public double PH { get; set; }
        public string Height { get; set; }
        public string BudTrichomeColor { get; set; }
        public string GrowState { get; set; }
        public string ColaSize { get; set; }
        public string AverageBudSize { get; set; }
        public string StalkDiameter { get; set; }
        public string Tags { get; set; }
        public Guid Owner { get; set; }
        public string Editors { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}