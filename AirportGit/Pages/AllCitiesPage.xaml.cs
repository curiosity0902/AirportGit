﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
using AirportGit.DB;

namespace AirportGit.Pages
{
    /// <summary>
    /// Логика взаимодействия для AllCitiesPage.xaml
    /// </summary>
    public partial class AllCitiesPage : Page
    {
        public static List<City> cities = new List<City>();
        public static List<Country> countries { get; set; }
        public AllCitiesPage(Country country)
        {
            InitializeComponent();
            contextCountry = country;
            InitializeDataInPage();
            this.DataContext = this;
        }

        public void InitializeDataInPage()
        {
            cities = new List<City>(DBConnection.airportEntities.City.ToList().Where(x => x.IDCounrty == contextCountry.IDCountry));
            countries = new List<Country>(DBConnection.airportEntities.Country.ToList());
            CitiesLv.ItemsSource = new List<City>(DBConnection.airportEntities.City.ToList());
            this.DataContext = this;
        }
    }
}
