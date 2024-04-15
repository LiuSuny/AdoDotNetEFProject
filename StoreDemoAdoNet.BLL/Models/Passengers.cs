
using AdoDotNetEFProject.DAL.Enum;

namespace AdoDotNetEFProject.BLL
{
    public record Passengers
    {
        public int Id { get; set; }        
        public string First_Name { get; set; }     
        public string Last_Name { get; set; }
        public int Age { get; set; }
        public PasseengerTime passeengerArrivalTime;
        public PasseengerTime passeengerTakeOffTime;
        public Airplane airplaneId { get; set; }
        

        
    }
}
