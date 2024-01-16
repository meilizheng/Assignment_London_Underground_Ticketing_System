using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Collections.Specialized.BitVector32;

namespace Assignment_London_Underground_Ticketing_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Replace "WillsList" with your Custom List name in 2 places.
        // 1. Replace here
        // Example YourList<Ride> Riders
        public MeilisList<Rider> Riders;
        public MeilisList<Rider> NewRiders;

        int numberOfRiders = 100; // Changes this to something higher than 100 to check your list is working

        public MainWindow()
        {
            InitializeComponent();
            InitializeRiders();

            cmbSearchStation.ItemsSource = Enum.GetValues(typeof(Station));

            lvRiders.ItemsSource = Riders;

            NewRiders = new MeilisList<Rider>();
        } // MainWindow

        private void OnSearchStation(object sender, RoutedEventArgs e)
        {
            var searchStation = (Station)cmbSearchStation.SelectedItem;
            // Clear previous results
            NewRiders = new MeilisList<Rider>();
            // Enter code here to show all riders who started there ride from the selected station
            foreach (var rider in Riders)
            {   //if the rider's stationOn equals the selected Station, add the rider to the NewRiders list
                if (rider.StationOn == searchStation)
                {
                    NewRiders.Add(rider);
                }
            }
            //Display NewRiders List in listview box.
            lvFilteredRiders.ItemsSource = NewRiders;
        } // OnSearchStation

        private void OnShowActive(object sender, RoutedEventArgs e)
        {
            // Clear previous results
            NewRiders = new MeilisList<Rider>();
            // Enter code here to display all riders currently riding the underground
            foreach (var rider in Riders)
            {   //if rider StationOf is active 
                if (rider.IsActive)
                {
                    //Add the rider to the NewRiders List
                    NewRiders.Add(rider);
                }
            }
            //Display the NewRiders list in FilteradRiders 
            lvFilteredRiders.ItemsSource = NewRiders;
        } // OnShowActive

        private void OnClearList(object sender, RoutedEventArgs e)
        {
            //Clear previous results
            NewRiders = new MeilisList<Rider>();
            //Clear FilteredRiders list.
            lvFilteredRiders.ItemsSource = null;
        }

        private void InitializeRiders()
        {
            // 2. And here
            // Ex Riders = new YourList<Rider>();
            Riders = new MeilisList<Rider>();
            Random rnd = new Random();
            HashSet<int> usedNumbers = new HashSet<int>();

            for (int i = 0; i < numberOfRiders; i++)
            {
                int uniqueNumber;
                do
                {
                    uniqueNumber = rnd.Next(100000000, 1000000000);
                }
                while (usedNumbers.Contains(uniqueNumber));

                usedNumbers.Add(uniqueNumber);

                Station stationOn = (Station)rnd.Next(Enum.GetNames(typeof(Station)).Length);
                Station stationOff = rnd.Next(100) < 30 ? Station.Active : (Station)rnd.Next(1, Enum.GetNames(typeof(Station)).Length);

                Riders.Add(new Rider(uniqueNumber, stationOn, stationOff));
            }
        } // Initialize Rider

    } //class

} // namespace