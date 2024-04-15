

namespace AdoDotNetEFProject.BLL
{
    public class Context
    {
      public ListOfAirplane airplane { get;}
      public ListOfPassengers passengers { get;}
      public ListOfTicket ticket { get;}

        public Context()
        {
            airplane = new ListOfAirplane();
            passengers = new ListOfPassengers();
            ticket = new ListOfTicket();

        }
    }
}
