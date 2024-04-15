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
    /// Interaction logic for AddDataPage.xaml
    /// </summary>
    public partial class AddDataPage : Window
    {
        AdoNetEntityFrameWorkProjectEntities _db = new AdoNetEntityFrameWorkProjectEntities();

        public AddDataPage()
        {
            InitializeComponent();
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
            Airplane newPassenger = new Airplane()
            {
                PlaneNumbers = TBPlaneNumbers.Text,
                Full_Name = TBFullName.Text,
                Age = Convert.ToInt32(TBAge.Text),
                TakeOffDestination = TBTakeOffDestination.Text,
                ArrivalDestination = TBArrivalDestination.Text,
                Color = TBColor.Text,
                NumberOfPassengers = Convert.ToInt32(TBNumberOfPassengers.Text),
                TicketNumber = TBTicketNumber.Text
            };
            if(newPassenger.PlaneNumbers == "" || newPassenger.Age <= 0 ||
                newPassenger.TakeOffDestination == "")
            {
                try
                {

                    MessageBox.Show("Error on data input, Kindly input correct data!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch(Exception ex)
                {
                    ex.Source = "Error";
                }
                
                        
            }
                
            _db.Airplanes.Add(newPassenger);
            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.Airplanes.ToList();
            MessageBox.Show("Data Added Successfully!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
