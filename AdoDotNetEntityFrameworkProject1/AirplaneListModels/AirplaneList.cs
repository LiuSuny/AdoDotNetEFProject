using AdoDotNetEntityFrameworkProject1.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNetEntityFrameworkProject1.AirplaneListModels
{
    public class AirplaneList
    {
       
        public AirplaneList()
        {
            Airplane airplanelist = new Airplane()
            {                
                PlaneNumbers = "Su100",
                Full_Name = "John Dan",
                Age = 20,
                TakeOffDestination = "Moscow",
                ArrivalDestination = "Sochi",
                Color = "Blue",
                NumberOfPassengers = 150,
                TicketNumber = "28xl"
                
            };           
        }
    }
}
