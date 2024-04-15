

using AdoDotNetEFProject.DAL.Enum;
using System.ComponentModel;

namespace AdoDotNetEFProject.WPF
{
    public class Passengers : BaseNotify
    {
        private int _id;
        private string _first_Name;
        private string _last_Name;
        private int _age;
        private PasseengerTime _passeengerTakeOffTime;
        private PasseengerTime _passeengerArrivalTime;
        private Airplane _airplaneId;

        public int Id 
        {
            get => _id;
            set => SetField(ref _id, value); 
        }
        public string First_Name
        {
            get => _first_Name;
            set => SetField(ref _first_Name, value);
        }

        public string Last_Name
        {
            get => _last_Name;
            set => SetField(ref _last_Name, value);
        }
        public int Age
        {
            get => _age;
            set => SetField(ref _age, value);
        }
        public PasseengerTime PasseengerTakeOffTime
        {
            get => _passeengerTakeOffTime;
            set => SetField(ref _passeengerTakeOffTime, value);
        }

        public PasseengerTime PasseengerArrivalTime
        {
            get => _passeengerArrivalTime;
            set => SetField(ref _passeengerArrivalTime, value);
        }

        public Airplane AirplaneId 
        {
            get => _airplaneId;
            set => SetField(ref _airplaneId, value);
        }
    }
}
