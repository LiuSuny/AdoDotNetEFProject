

namespace AdoDotNetEntityFrameworkProject1.DataEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Airplane
    {
        public int id { get; set; }
        public string PlaneNumbers { get; set; }
        public string Full_Name { get; set; }
        public Nullable<int> Age { get; set; }
        public string TakeOffDestination { get; set; }
        public string ArrivalDestination { get; set; }
        public string Color { get; set; }
        public Nullable<int> NumberOfPassengers { get; set; }
        public string TicketNumber { get; set; }
    }
}
