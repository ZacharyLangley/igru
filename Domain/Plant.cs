using System;

namespace Domain
{
    public class Plant
    {
        public Guid Id { get; set; }
        public Guid GardenId { get; set; }
        public Guid StrainId { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Notes { get; set; }
        public string GrowCycleLength { get; set; }
        public DateTime Aquired { get; set; }
        public string Parentage { get; set; }
        public string Origin { get; set; }
        public string Gender { get; set; }
        public double DaysFlowering { get; set; }
        public double DaysCured { get; set; }
        public string HarvestedWeight { get; set; }
        public double BudDensity { get; set; }
        public bool BudPistils { get; set; }
        public string Tags { get; set; }
        public Guid Owner { get; set; }
        public string Editors { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}