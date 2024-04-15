
namespace AdoDotNetEFProject.BLL
{
    public record Ticket
    {
        public int Id { get; set; }
        public int TickNumbers { get; set; }

        public Passengers passengersId { get; set; } 
    }
}
