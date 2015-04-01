using System;
using System.Collections.Generic;
using System.Configuration;
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
using TeamPrj.Buisnes.Managers.Abstract;
using TeamPrj.Buisnes.Managers.Concrete;
using TeamProject.ViewModel;

namespace TeamProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["TeamProjectEntities"].ConnectionString;
        static public ICountryManager countryManager = new CountryManager(connectionString);
        static public ICityManager cityManager = new CityManager(connectionString);
        static public IResidenseManager residenseManager = new ResidenseManager(connectionString);
        static public CountryViewModel countriesViewModel = new CountryViewModel(countryManager);
        static public CityViewModel citiesViewModel = new CityViewModel(cityManager);
        static public ResidenseViewModel residenseViewModel = new ResidenseViewModel(residenseManager);
        public int CountryID;
        public int CityID;
        public MainWindow()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
           try
           {
               cbCountry.DataContext = cmbCountryItems;
               cbCountry.SelectedIndex = 0;
              
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
        }

        private void cbCountry_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

           CountryID = countriesViewModel.Countries
                .Where(c => c.Name == cbCountry.SelectedItem.ToString())
                .Select(c => c.ID).First();

           cbCity.DataContext = cmbCityItems;
           cbCity.SelectedIndex = 0;
          // MessageBox.Show(CountryID.ToString());
        }
        public IEnumerable<string> cmbCountryItems
        {
            get
            {
                return countriesViewModel.Countries.OrderBy(c => c.Name).Select(c => c.Name).ToList();
            }

        }
        public IEnumerable<string> cmbCityItems
        {
            get
            {
                return citiesViewModel.Cities.Where(c => c.CountryId == CountryID).OrderBy(c => c.Name)
                    .Select(c => c.Name).ToList();
                //return citiesViewModel.Cities.OrderBy(c => c.Name).Select(c => c.Name).ToList();
            }
        }

        private void cbCity_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                CityID = citiesViewModel.Cities
                    .Where(c => c.Name == cbCity.SelectedItem.ToString())
                    .Select(c => c.ID).First();
                //MessageBox.Show(CityID.ToString());
                dgResidence.DataContext = residenseViewModel.Catalog.Where(r => r.CityId == CityID);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);

            }
        }
    }
}
