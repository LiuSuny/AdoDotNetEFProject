using AdoDotNetEntityFrameworkProject1.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace AdoDotNetEntityFrameworkProject1.Pages
{
    /// <summary>
    /// Interaction logic for EditPages.xaml
    /// </summary>
    public partial class EditPages : Window
    {
        AdoNetEntityFrameWorkProjectEntities _db = new AdoNetEntityFrameWorkProjectEntities();
        int ID;
        public EditPages(int AirplaneID)
        {
            InitializeComponent();

            ID = AirplaneID;

            var data = (from m in _db.Airplanes where m.id == ID select m).First();
            
            TBPlaneNumbers.Text = data.PlaneNumbers;
            TBFullName.Text = data.Full_Name;
            TBAge.Text = data.Age.ToString();
            TBTakeOffDestination.Text = data.TakeOffDestination;
            TBArrivalDestination.Text = data.ArrivalDestination;
            TBColor.Text = data.Color;
            TBNumberOfPassengers.Text = data.NumberOfPassengers.ToString();
            TBTicketNumber.Text = data.TicketNumber;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Airplane updateAirplaneDBDetail = (from m in _db.Airplanes where m.id == ID select m).Single();
            updateAirplaneDBDetail.PlaneNumbers = TBPlaneNumbers.Text;
            updateAirplaneDBDetail.Full_Name = TBFullName.Text;
            updateAirplaneDBDetail.Age = Convert.ToInt32(TBAge.Text);
            updateAirplaneDBDetail.TakeOffDestination = TBTakeOffDestination.Text;
            updateAirplaneDBDetail.ArrivalDestination = TBArrivalDestination.Text;
            updateAirplaneDBDetail.Color = TBColor.Text;
            updateAirplaneDBDetail.NumberOfPassengers = Convert.ToInt32(TBNumberOfPassengers.Text);
            updateAirplaneDBDetail.TicketNumber = TBTicketNumber.Text;

            if (updateAirplaneDBDetail.PlaneNumbers == "" || updateAirplaneDBDetail.Age <= 1 ||
               updateAirplaneDBDetail.TakeOffDestination == "")
            {
                try
                {

                    MessageBox.Show("Error on data input, Kindly input correct data!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch (Exception ex)
                {
                    ex.Source = "Error";
                }


            }
            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.Airplanes.ToList();
            MessageBox.Show("Database Successfully Updated!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
