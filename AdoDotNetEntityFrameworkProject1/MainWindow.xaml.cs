using AdoDotNetEntityFrameworkProject1.DataEntity;
using AdoDotNetEntityFrameworkProject1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdoDotNetEntityFrameworkProject1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// calling and initialize our database 
        /// </summary>
        AdoNetEntityFrameWorkProjectEntities _db = new AdoNetEntityFrameWorkProjectEntities();

        public static DataGrid datagrid;
        public MainWindow()
        {
            InitializeComponent();
            LoadDataElement();
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddDataPage addDataWin = new AddDataPage();
            addDataWin.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int ID = (DGridAirplane.SelectedItem as Airplane).id;
            var deleteAirplane = _db.Airplanes.Where(m => m.id == ID).Single();
            _db.Airplanes.Remove(deleteAirplane);
            _db.SaveChanges();
            DGridAirplane.ItemsSource = _db.Airplanes.ToList();
            MessageBox.Show("Data Successfully Deleted!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            int ID = (DGridAirplane.SelectedItem as Airplane).id;
            EditPages editDataPage = new EditPages(ID);
            editDataPage.ShowDialog();
        }  

        private void TboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var result = _db.Airplanes.Where(x => x.PlaneNumbers.Contains(TboxSearch.Text) || x.Full_Name.Contains(TboxSearch.Text) || x.Age.ToString().Contains(TboxSearch.Text)
            || x.TakeOffDestination.Contains(TboxSearch.Text) || x.ArrivalDestination.Contains(TboxSearch.Text)
            || x.Color.Contains(TboxSearch.Text) || x.NumberOfPassengers.ToString().Contains(TboxSearch.Text)
            || x.TicketNumber.Contains(TboxSearch.Text)).ToList();
            DGridAirplane.ItemsSource = result;
        }

        public void LoadDataElement()
        {
           DGridAirplane.ItemsSource = _db.Airplanes.ToList();
            datagrid = DGridAirplane;
        }
    }
}
