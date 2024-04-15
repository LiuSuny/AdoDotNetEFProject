

namespace AdoDotNetEFProject.WPF
{
    public class UIMappers
    {
        /// <summary>
        /// Mappers Method for Business logic Layers (BLL) Map BLL Airplane To UI Airplane
        /// </summary>
        /// <param name="airplane">Values parameter</param>
        /// <returns></returns>
        public static WPF.Airplane MapBLLAirplaneToUIAirplane(BLL.Airplane airplane)
        {
            return new WPF.Airplane()
            {
                Id = airplane.Id,
                PlaneNumbers = airplane.planeNumbers,
                Colors = airplane.Colors,
                PlaneProductionYear = airplane.planeProductionYear,
                NumberOfPassanges = airplane.NumberOfPassanges
               
            };
        }

        /// <summary>
        /// Mappers Method for MapUIAirplaneToBLLAirplane
        /// </summary>
        /// <param name="airplane">Values parameter</param>
        /// <returns></returns>
        public static BLL.Airplane MapUIAirplaneToBLLAirplane(WPF.Airplane airplane)
        {
            return new BLL.Airplane()
            {
                Id = airplane.Id,
                planeNumbers = airplane.PlaneNumbers,
                Colors = airplane.Colors,
                planeProductionYear = airplane.PlaneProductionYear,
                NumberOfPassanges = airplane.NumberOfPassanges
               
            };
        }

        /// <summary>
        /// Mappers Method for MapBLLPassengerToUIPassenger
        /// </summary>
        /// <param name="passenger">Values parameter</param>
        /// <returns></returns>
        public static WPF.Passengers MapBLLPassengerToUIPassenger(BLL.Passengers passenger)
        {
            return new WPF.Passengers()
            {
               Id = passenger.Id,
               First_Name = passenger.First_Name,
               Last_Name = passenger.Last_Name,
               Age = passenger.Age,
               PasseengerTakeOffTime = passenger.passeengerTakeOffTime,
               PasseengerArrivalTime = passenger.passeengerArrivalTime,
               AirplaneId = MapBLLAirplaneToUIAirplane(passenger.airplaneId)
               
            };
        }

        /// <summary>
        /// Mappers Method for MapUIPassengerToBLLPassenger WPF
        /// </summary>
        /// <param name="passenger">Values parameter</param>
        /// <returns></returns>
        public static BLL.Passengers MapUIPassengerToBLLPassenger(WPF.Passengers passenger)
        {
            return new BLL.Passengers()
            {
                Id = passenger.Id,
                First_Name = passenger.First_Name,
                Last_Name = passenger.Last_Name,
                Age = passenger.Age,
                passeengerTakeOffTime = passenger.PasseengerTakeOffTime,
                passeengerArrivalTime = passenger.PasseengerArrivalTime,
                airplaneId = MapUIAirplaneToBLLAirplane(passenger.AirplaneId)
               
            };
        }

        /// <summary>
        /// Mappers Method for MapBLLTicketToUITicket
        /// </summary>
        /// <param name="ticket">Values parameter</param>
        /// <returns></returns>
        public static WPF.Ticket MapBLLTicketToUITicket(BLL.Ticket ticket)
        {
            return new WPF.Ticket()
            {
               Id = ticket.Id,
               TickNumbers = ticket.TickNumbers,
               PassengersId = MapBLLPassengerToUIPassenger(ticket.passengersId)
            };
        }

        /// <summary>
        /// Mappers Method for MapUITicketToBLLTicket
        /// </summary>
        /// <param name="ticket">Values parameter</param>
        /// <returns></returns>
        public static BLL.Ticket MapUITicketToBLLTicket(WPF.Ticket ticket)
        {
            return new BLL.Ticket()
            {
                Id = ticket.Id,
                TickNumbers = ticket.TickNumbers,
                passengersId = MapUIPassengerToBLLPassenger(ticket.PassengersId)
            };
        }

        /// <summary>
        /// Mappers Method for MapperBllAirplaneToUIAirplaneInfo that work for one side of business logical
        /// </summary>
        /// <param name="sales"></param>
        /// <returns></returns>
        public static WPF.AirplaneInfo MapperBllAirplaneToUIAirplaneInfo(BLL.Airplane airplane)
        {
            return new WPF.AirplaneInfo()
            {
               Id = airplane.Id,
               PlaneNumbers = airplane.planeNumbers,
               Colors = airplane.Colors,
               PlaneProductionYear = airplane.planeProductionYear,
               NumberOfPassanges = airplane.NumberOfPassanges
             
            };
        }
    }
}
