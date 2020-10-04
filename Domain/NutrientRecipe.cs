using System;

namespace Domain
{
    public class NutrientRecipe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Instructions { get; set; }
        public string PH { get; set; }
        public string MixTime { get; set; }
        public string Tags { get; set; }
        public Guid Owner { get; set; }
        public string Editors { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}