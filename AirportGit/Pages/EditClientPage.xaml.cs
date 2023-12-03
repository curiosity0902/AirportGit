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

namespace AirportGit.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditClientPage.xaml
    /// </summary>
    //public partial class EditClientPage : Page
    //{
    //    public static List<Client> clients { get; set; }
    //    public static Client client { get; set; }
    //    public static Client loggedClient;
    //    public EditClientPage(Client client)
    //    {
    //        InitializeComponent();
    //        contextClient = client;
    //        clients = DBConnection.airportEntities.Client.ToList();
    //        this.DataContext = this;
    //        Worker w = DBConnection.selectedForEditWorker;
    //        SurnameTB.Text = w.Surname;
    //        NameTB.Text = w.Name;
    //        PatronymicTB.Text = w.Patronymic;
    //        DateOfBirthDP.SelectedDate = w.DateOfBirth;
    //        PassportTB.Text = w.Passport;
    //        PhoneTB.Text = w.Phone;
    //        EmailTB.Text = w.Email;
    //        PasswordTB.Text = w.Password;
    //    }

    //    private void BackBTN_Click(object sender, RoutedEventArgs e)
    //    {
    //        NavigationService.Navigate(new MainMenuClientPage());
    //    }

    //    private void EditClientBTN_Click(object sender, RoutedEventArgs e)
    //    {
    //        var error = string.Empty;
    //        var validationContext = new ValidationContext(contextWorker);
    //        var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
    //        if (!Validator.TryValidateObject(contextWorker, validationContext, results, true))
    //        {
    //            foreach (var result in results)
    //            {
    //                error += $"{result.ErrorMessage}\n";
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(error))
    //        {
    //            MessageBox.Show(error);
    //            return;
    //        }
    //        if (contextWorker.ID == 0)
    //            DBConnection.airportEntities.Worker.Add(contextWorker);
    //        DBConnection.airportEntities.SaveChanges();
    //        NavigationService.Navigate(new WorkerPage());
    //    }

    //}
}
