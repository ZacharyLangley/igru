using System;

namespace Application.Gardens
{
    public class GardenDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Location { get; set; }
        public string GrowType { get; set; }
        public string GrowSize { get; set; }
        public string GrowStyle { get; set; }
        public string ContainerSize { get; set; }
        public string Tags { get; set; }
        public Guid Owner { get; set; }
        public string Editors { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}