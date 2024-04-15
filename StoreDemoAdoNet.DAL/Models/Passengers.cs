

using AdoDotNetEFProject.DAL.Enum;

namespace AdoDotNetEFProject.DAL
{
   
    public record Passengers
    {
        #region Private memebers
        private int age;
        //[Required]
        private string first_Name;
        //[Required]
        private string last_Name;
            #endregion

        #region Public members
        public int passenger_id { get; set; }
        public PasseengerTime passeengerArrivalTime;
        public PasseengerTime passeengerTakeOffTime;
        public int airplaneId { get; set; }
        #endregion

        public int Age
        {
            get => age;
            set
            {
                if (age <= 0)
                {
                    throw new ArgumentNullException(nameof(value), "Too small to fly");
                }
                age = value;
            }
        }

        public string First_Name
        {
            get => first_Name;
            set => first_Name = value ?? throw new ArgumentNullException(nameof(value), "First Name can not be empty");
        }

        public string Last_Name
        {
            get => last_Name;
            set => last_Name = value ?? throw new ArgumentNullException(nameof(value), "Last Name can not be empty");
        }

    }
}
