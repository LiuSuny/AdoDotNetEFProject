

namespace AdoDotNetEFProject.BLL
{
    /// <summary>
    /// Mappers Class for initialization of our BLL and DALL method - BLL stand for Business logic Layers (BLL) is an intermediate 
    /// between the Presentation Layer (PL) and the Data Access Layer (DAL). 
    /// </summary>
    public static class BLMappers
    {
        /// <summary>
        /// Mappers Method for Business logic Layers (BLL) for airplane DAL to Airplane BLL
        /// </summary>
        /// <param name="airplane">Values parameter</param>
        /// <returns></returns>
        public static BLL.Airplane MapAirplaneDALToAirplaneBLL(DAL.Airplane airplane)
        {
            return new BLL.Airplane()
            {
               Id = airplane.airplaneId,
               planeNumbers = airplane.PlaneNumbers,
               Colors = airplane.Colors,
               planeProductionYear = airplane.planeProductionYear,
               NumberOfPassanges = airplane.NumberOfPassanges
               
            };
        }

        /// <summary>
        /// Mappers Method for data access layer (DAL) for airplane BLL to Airplane DAL
        /// </summary>
        /// <param name="airplane">Values parameter</param>
        /// <returns></returns>
        public static DAL.Airplane MapAirplaneBLLToAirplaneDAL(BLL.Airplane airplane)
        {
            return new DAL.Airplane()
            {
               airplaneId = airplane.Id,
               PlaneNumbers = airplane.planeNumbers,
               Colors = airplane.Colors,
               planeProductionYear = airplane.planeProductionYear,
               NumberOfPassanges = airplane.NumberOfPassanges
            };
        }

        /// <summary>
        /// Mappers Method for Business logic Layers (BLL) for Passengers DAL to Passengers BLL
        /// </summary>
        /// <param name="passenger">Values parameter</param>
        /// <returns></returns>
        public static BLL.Passengers MapPassengerDALToPassengerBLL(DAL.Passengers passenger,
            IEnumerable<DAL.Airplane> airplane = null)
        {
            return new BLL.Passengers()
            {
               Id = passenger.passenger_id,
               First_Name = passenger.First_Name,
               Last_Name = passenger.Last_Name,
               Age = passenger.Age,
               passeengerTakeOffTime = passenger.passeengerTakeOffTime,
               passeengerArrivalTime = passenger.passeengerArrivalTime,
               airplaneId = MapAirplaneDALToAirplaneBLL(airplane.First(u => u.airplaneId == passenger.airplaneId))

            };
        }

        /// <summary>
        /// Mappers Method for data access layer (DAL) for Passengers BLL to Passengers DAL
        /// </summary>
        /// <param name="passenger">Values</param>
        /// <returns></returns>
        public static DAL.Passengers MapPassengerBLLToPassengerDAL(BLL.Passengers passenger)
        {
            return new DAL.Passengers()
            {
               passenger_id = passenger.Id,
               First_Name = passenger.First_Name,
               Last_Name = passenger.Last_Name,
               Age = passenger.Age,
               passeengerTakeOffTime = passenger.passeengerTakeOffTime,
               passeengerArrivalTime = passenger.passeengerArrivalTime,
               airplaneId = passenger.airplaneId.Id
            };
        }

        /// <summary>
        /// Mappers Method for Business logic Layers (BLL) for ticket DAL to ticket BLL
        /// </summary>
        /// <param name="ticket">Values parameter</param>
        /// <returns></returns>
        public static BLL.Ticket MapTicketDALToTicketBLL(DAL.Ticket ticket, 
                 IEnumerable<DAL.Passengers> passenger)
        {
            return new BLL.Ticket()
            {
              Id = ticket.Ticket_Id,
              TickNumbers = ticket.TickNumbers,
              passengersId = MapPassengerDALToPassengerBLL(passenger.First(u => u.passenger_id== ticket.passangerId)) //sort of join in sql
               
            };
        }

        /// <summary>
        /// Mappers Method for data access layer (DAL) for ticket BLL to ticket DAL
        /// </summary>
        /// <param name="ticket">Values</param>
        /// <returns></returns>
        public static DAL.Ticket MapTicketBLLToTicketDAL(BLL.Ticket ticket)     
        {
            return new DAL.Ticket()
            {
                Ticket_Id = ticket.Id,
                TickNumbers = ticket.TickNumbers,
                passangerId = ticket.passengersId.Id
               
            };
        }

    }
}
