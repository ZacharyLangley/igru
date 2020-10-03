using System;

namespace Domain
{
    public class GardenEntry
    {
        public Guid Id { get; set; }
        public Guid GardenId { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string Tags { get; set; }
        public string Temperature { get; set; }
        public double Humidity { get; set; }
        public string LightLevel { get; set; }
        public Guid Owner { get; set; }
        public string Editors { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}