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

        private void InitializeDataInPage()
        {
            workers = DBConnection.airportEntities.Worker.ToList();
            positions = DBConnection.airportEntities.Position.ToList();
            aircompanies = DBConnection.airportEntities.Aircompany.ToList();
            this.DataContext = this;
            SurnameTB.Text = contextWorker.Surname;
            NameTB.Text = contextWorker.Name;
            PatronymicTB.Text = contextWorker.Patronymic;
            DateOfBirthDP.SelectedDate = contextWorker.DateOfBirth;
            PassportTB.Text = contextWorker.Passport;
            PhoneTB.Text = contextWorker.Phone;
            PositionCB.SelectedIndex = (int)contextWorker.IDPosition - 1;
            AircompanyCB.SelectedIndex = (int)contextWorker.IDAircompany - 1;
            EmailTB.Text = contextWorker.Email;
            PasswordTB.Text = contextWorker.Password;
            if (contextWorker.Photo != null)
            {
                PhotoWorker.Source = new BitmapImage(new Uri(contextWorker.Photo.ToString()));
            }
        }
        public EditWorkerPage(Worker worker)
        {
            InitializeComponent();
            contextWorker = worker;
            InitializeDataInPage();
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
                DBConnection.loginedWorker.Photo = File.ReadAllBytes(openFileDialog.FileName);
                PhotoWorker.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
        private void EditWorkerBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Worker worker = contextWorker;
                if (string.IsNullOrWhiteSpace(SurnameTB.Text) || string.IsNullOrWhiteSpace(NameTB.Text) || string.IsNullOrWhiteSpace(PatronymicTB.Text) ||
                        DateOfBirthDP.SelectedDate == null || string.IsNullOrWhiteSpace(PassportTB.Text) || string.IsNullOrWhiteSpace(PhoneTB.Text) ||
                        string.IsNullOrWhiteSpace(EmailTB.Text) || string.IsNullOrWhiteSpace(PasswordTB.Text))
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    worker.Surname = SurnameTB.Text;
                    worker.Name = NameTB.Text;
                    worker.Patronymic = PatronymicTB.Text;
                    if (DateOfBirthDP.SelectedDate != null && (DateTime.Now - (DateTime)DateOfBirthDP.SelectedDate).TotalDays < 365 * 18 + 4)
                    {
                        MessageBox.Show("Сотрудник не может быть младше 18 лет.");
                    }
                    else
                    {
                        worker.DateOfBirth = Convert.ToDateTime(DateOfBirthDP.Text);
                    }
                    worker.IDPosition = (PositionCB.SelectedItem as Position).IDPosition;
                    worker.IDAircompany = (AircompanyCB.SelectedItem as Aircompany).IDAircompany;
                    worker.Phone = PhoneTB.Text;
                    worker.Email = EmailTB.Text;
                    worker.Password = PasswordTB.Text;
                    DBConnection.airportEntities.SaveChanges();

                    SurnameTB.Text = String.Empty;
                    NameTB.Text = String.Empty;
                    PatronymicTB.Text = String.Empty;
                    DateOfBirthDP = null;
                    PositionCB.Text = String.Empty;
                    PositionCB.Text = String.Empty;
                    PhoneTB.Text = String.Empty;
                    EmailTB.Text = String.Empty;
                    PasswordTB.Text = String.Empty;

                    DBConnection.airportEntities.SaveChanges();
                    NavigationService.Navigate(new AllWorkersPage());
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }
        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllWorkersPage());
        }
    }
}
