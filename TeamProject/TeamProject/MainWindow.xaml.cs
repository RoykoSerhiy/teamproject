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
        #region CreatesVarible
        static string connectionString = ConfigurationManager.ConnectionStrings["TeamProjectEntities"].ConnectionString;
        static public ICountryManager countryManager = new CountryManager(connectionString);
        static public ICityManager cityManager = new CityManager(connectionString);
        static public IResidenseManager residenseManager = new ResidenseManager(connectionString);
        static public ITransportManager transportManager = new TransportManager(connectionString);
        static public IEatPlaceManager eatPlaceManager = new EatPlaceManager(connectionString);
        static public ISupermarketManager supermarketsManager = new SupermarketManager(connectionString);
        static public IEntertainmentManager entertainmentManager = new EntertainmentManager(connectionString);
        static public IActivitiesManager activitiesManager = new ActivitiesManager(connectionString);
        static public CountryViewModel countriesViewModel = new CountryViewModel(countryManager);
        static public CityViewModel citiesViewModel = new CityViewModel(cityManager);
        static public ResidenseViewModel residenseViewModel = new ResidenseViewModel(residenseManager);
        static public TransportViewModel transportViewModel = new TransportViewModel(transportManager);
        static public EatPlaceViewModel eatPlaceViewModel = new EatPlaceViewModel(eatPlaceManager);
        static public SupermarketsViewModel supermarketsViewModel = new SupermarketsViewModel(supermarketsManager);
        static public EntertainmentViewModel entertainmentViewModel = new EntertainmentViewModel(entertainmentManager);
        static public ActivitiesViewModel activitiesViewModel = new ActivitiesViewModel(activitiesManager);
        public int CountryID;
        public int CityID;
        #endregion CreatesVarible
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
                .Where(c => c.name == cbCountry.SelectedItem.ToString())
                .Select(c => c.Id).First();

           cbCity.DataContext = cmbCityItems;
           cbCity.SelectedIndex = 0;
          
        }
        public IEnumerable<string> cmbCountryItems
        {
            get
            {
                return countriesViewModel.Countries.OrderBy(c => c.name).Select(c => c.name).ToList();
            }

        }
        public IEnumerable<string> cmbCityItems
        {
            get
            {
                return citiesViewModel.Cities.Where(c => c.CountryId == CountryID).OrderBy(c => c.name)
                    .Select(c => c.name).ToList();
               
            }
        }

        private void cbCity_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                CityID = citiesViewModel.Cities
                    .Where(c => c.name == cbCity.SelectedItem.ToString())
                    .Select(c => c.Id).First();
                
                dgResidence.DataContext = residenseViewModel.Catalog.Where(r => r.CityId == CityID);
                dgTransport.DataContext = transportViewModel.Catalog.Where(t => t.CityId == CityID);
                dgEatPlase.DataContext = eatPlaceViewModel.Catalog.Where(et => et.CityId == CityID);
                dgSupermarkets.DataContext = supermarketsViewModel.Catalog.Where(s => s.CityId == CityID);
                dgEntertainment.DataContext = entertainmentViewModel.Catalog.Where(en => en.CityId == CityID);
                dgActivities.DataContext = activitiesViewModel.Catalog.Where(a => a.CityId == CityID);
            }
            catch (Exception ex)
            {}
        }
    }
}
