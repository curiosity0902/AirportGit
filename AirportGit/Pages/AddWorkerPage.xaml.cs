using AirportGit.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace AirportGit.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddWorkerPage.xaml
    /// </summary>
    public partial class AddWorkerPage : Page
    {
        public static List<Worker> workers { get; set; }
        public static List<Position> positions { get; set; }
        public static List<Aircompany> aircompanies { get; set; }
        public static Worker worker = new Worker();
        public AddWorkerPage()
        {
            InitializeComponent();
            workers = DBConnection.airportEntities.Worker.ToList();
            positions = DBConnection.airportEntities.Position.ToList();
            aircompanies = DBConnection.airportEntities.Aircompany.ToList();
            this.DataContext = this;
        }
        private void AddPhotoBTN_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                worker.Photo = File.ReadAllBytes(openFileDialog.FileName);
                PhotoWorker.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
        private void AddWorkerBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dcvd = SurnameTB.Text + " " + NameTB.Text + " " + PatronymicTB.Text + " " + DateOfBirthDP.Text;

                if (MessageBox.Show(dcvd, "Проверьте корректность введенных данных", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                {
                    worker.Surname = SurnameTB.Text.Trim();
                    worker.Name = NameTB.Text.Trim();
                    worker.Patronymic = PatronymicTB.Text.Trim();
                    worker.DateOfBirth = DateOfBirthDP.SelectedDate;
                    worker.Passport = PassportTB.Text.Trim();
                    worker.Email = EmailTB.Text.Trim();
                    worker.Password = PasswordTB.Text.Trim();
                    var a = PositionCB.SelectedItem as Position;
                    worker.IDPosition = a.IDPosition;

                    DBConnection.airportEntities.Worker.Add(worker);
                    DBConnection.airportEntities.SaveChanges();
                    NavigationService.Navigate(new AllWorkersPage());
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
            }
        }
        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllWorkersPage());
        }
    }
}
