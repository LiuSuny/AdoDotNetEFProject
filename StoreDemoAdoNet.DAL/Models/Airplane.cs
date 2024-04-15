


using System.ComponentModel.DataAnnotations;

namespace AdoDotNetEFProject.DAL
{
    public record Airplane
    {
        
        public int airplaneId { get; set; }        

        #region Private members     
        private string planeNumbers;
        #endregion

        #region public Property      
        public int NumberOfPassanges { get; set; }
        public string Colors { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd-MMM-yyyy}", ConvertEmptyStringToNull = false)]
        public DateTime planeProductionYear { get; set; }
        #endregion

        #region Public check validation Getters and setters
        public string PlaneNumbers
        {
            get => planeNumbers;
            set => planeNumbers = value ?? throw new ArgumentNullException(nameof(value), "Cannot set to null");
        }
        #endregion

    }
}
