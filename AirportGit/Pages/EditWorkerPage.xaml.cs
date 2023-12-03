using AirportGit.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Логика взаимодействия для EditWorkerPage.xaml
    /// </summary>
    public partial class EditWorkerPage : Page
    {
        public static List<Worker> workers { get; set; }
        public static List<Position> positions { get; set; }
        public static List<Aircompany> aircompanies { get; set; }
        Worker contextWorker;
        public EditWorkerPage(Worker worker)
        {
            InitializeComponent();
            contextWorker = worker;
            workers = DBConnection.airportEntities.Worker.ToList();
            positions = DBConnection.airportEntities.Position.ToList();
            aircompanies = DBConnection.airportEntities.Aircompany.ToList();
            this.DataContext = this;
            Worker w = DBConnection.selectedForEditWorker;
            SurnameTB.Text = w.Surname;
            NameTB.Text = w.Name;
            PatronymicTB.Text = w.Patronymic;
            DateOfBirthDP.SelectedDate = w.DateOfBirth;
            PassportTB.Text = w.Passport;
            PhoneTB.Text = w.Phone;
            PositionCB.SelectedIndex = (int)w.IDPosition - 1;
            AircompanyCB.SelectedIndex = (int)w.IDAircompany - 1;
            EmailTB.Text = w.Email;
            PasswordTB.Text = w.Password;
            if(w.Photo != null)
            {
                PhotoWorker.Source = new BitmapImage(new Uri(w.Photo.ToString()));
            }
        }

        private void AddPhotoBTN_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                DBConnection.selectedForEditWorker.Photo = File.ReadAllBytes(openFileDialog.FileName);
                PhotoWorker.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void EditWorkerBTN_Click(object sender, RoutedEventArgs e)
        {
            var error = string.Empty;
            var validationContext = new ValidationContext(contextWorker);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            if (!Validator.TryValidateObject(contextWorker, validationContext, results, true))
            {
                foreach (var result in results)
                {
                    error += $"{result.ErrorMessage}\n";
                }
            }
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error);
                return;
            }
            if (contextWorker.IDWorker == 0)
                DBConnection.airportEntities.Worker.Add(contextWorker);
            DBConnection.airportEntities.SaveChanges();
            NavigationService.Navigate(new AllWorkersPage());
            //try
            //{

            //}
            //catch
            //{
            //    MessageBox.Show("Возникла ошибка");
            //}
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllWorkersPage());
        }
    }
}
