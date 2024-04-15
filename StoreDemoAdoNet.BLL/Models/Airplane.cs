
using System.ComponentModel.DataAnnotations;

namespace AdoDotNetEFProject.BLL
{
    public record Airplane
    {
        public int Id { get; set; }
        public string planeNumbers { get; set; }
        public string Colors { get; set; }
        public DateTime planeProductionYear { get; set; }
        public int NumberOfPassanges { get; set; }

    }
}
