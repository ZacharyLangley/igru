using System;

namespace Domain
{
    public class Strain
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Notes { get; set; }
        public DateTime Aquired { get; set; }
        public double Price { get; set; }
        public double ThcPercentage { get; set; }
        public double CbdPercentage { get; set; }
        public string Parentage { get; set; }
        public string Aroma { get; set; }
        public string Taste { get; set; }
        public string Tags { get; set; }
        public Guid Owner { get; set; }
        public string Editors { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}