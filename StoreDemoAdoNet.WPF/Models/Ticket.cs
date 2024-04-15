


namespace AdoDotNetEFProject.WPF
{
    public class Ticket :BaseNotify
    {
        private int _id;
        private int _tickNumbers;      
        private Passengers _passengerId;

        public int Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        public int TickNumbers 
        {
            get => _tickNumbers;
            set => SetField(ref _tickNumbers, value);
        }
        
      
        public Passengers PassengersId
        {
            get => _passengerId;
            set => SetField(ref _passengerId, value);
        }
    }
}
