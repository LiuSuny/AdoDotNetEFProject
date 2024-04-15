
using System.Xml.Linq;

namespace AdoDotNetEFProject.WPF
{
    public class Airplane : BaseNotify
    {
        private int _id;      
        private string _planeNumbers;
        private string _colors;
        private DateTime _planeProductionYear;
        private int _numberOfPassanges;
        public int Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        public string PlaneNumbers 
        {
            get => _planeNumbers;
            set => SetField(ref _planeNumbers, value); 
        }
        public string Colors 
        { 
            get =>_colors; 
            set => SetField(ref _colors, value); 
        }
        public DateTime PlaneProductionYear 
        { 
            get => _planeProductionYear; 
            set => SetField(ref _planeProductionYear, value);
        }
        public int NumberOfPassanges
        { 
            get => _numberOfPassanges; 
            set => SetField(ref _numberOfPassanges, value); 
        }
    }
}
