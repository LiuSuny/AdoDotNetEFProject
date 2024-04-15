

using AdoDotNetEFProject.BLL;
using AdoDotNetEFProject.WPF.Windows.NewSaleWindow;
using System.Collections.ObjectModel;
using System.Windows;

namespace AdoDotNetEFProject.WPF.WindowModels
{
    public class MainWindowModel :BaseNotify
    {
        private readonly Context _context; //this allow us to colllect info from our list of context
        public ObservableCollection<AirplaneInfo> airplaneInfo { get; set; }

        public LambdaCommand AddNewProductButtonCommand { get; set; }
        public LambdaCommand UpdateProductButtonCommand { get; set; }

        public MainWindowModel()
        {
            _context = new Context();

            ListOfAirplane sourceAirplane = _context.airplane;

            //NOTE:ToBlockingEnumerable() block our Iasync enumerable and convert our GetAllAsync()
            ////to normal variable using linq SELECT afterward
            IEnumerable<AirplaneInfo> airplane = sourceAirplane.GetAllAsync()
                .ToBlockingEnumerable()
                .Select(s => UIMappers.MapperBllAirplaneToUIAirplaneInfo(s));

            airplaneInfo = new ObservableCollection<AirplaneInfo>(airplane);

            AddNewProductButtonCommand = new LambdaCommand(
                execute: o =>
                {
                    var window = new NewSaleWindow
                    {
                        Owner = (Window)Application.Current.Resources["Owner"]!
                    };
                    window.ShowDialog();
                });

                 UpdateProductButtonCommand = new LambdaCommand(
                  execute: _ =>
                      {
                          ListOfAirplane sourceAirplane = _context.airplane;
                          IEnumerable<AirplaneInfo> airplane = sourceAirplane
                                    .GetAllAsync()
                                    .ToBlockingEnumerable()
                                    .Select(UIMappers.MapperBllAirplaneToUIAirplaneInfo);
                          airplaneInfo.Clear();
                          foreach (var airplanes in airplane)
                          {
                              airplaneInfo.Add(airplanes);
                          }
                  });
        }      
    }
}
