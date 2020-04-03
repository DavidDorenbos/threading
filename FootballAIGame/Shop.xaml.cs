using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FootballAIGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Shop : Page
    {
        Vector2 playerDims;
        List<FootballPlayer> transferList;
        Currency currency = new Currency();
        public Shop()
        {
            this.InitializeComponent();
            LoadTransfers();
            money_bar.Text = currency.getCurrency().ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Main_menu));
        }

        private void setShop()
        {
            playerDims = new Vector2(48, 48);
            transferList = new List<FootballPlayer>();
            transferList.Add(new FootballPlayer(playerDims, new Vector2(0, 0),
                "Tinus", 20, 20, 50, "2d/sprite", "human"));
            transferList.Add(new FootballPlayer(playerDims, new Vector2(200, 60),
                "Henkie", 20, 20, 50, "2d/sprite", "midfielder"));
            transferList.Add(new FootballPlayer(playerDims, new Vector2(200, 500),
                "Mitchie", 20, 20, 50, "2d/sprite", "midfielder"));
            transferList.Add(new FootballPlayer(playerDims, new Vector2(360, 60),
                "Sjaak", 20, 20, 50, "2d/sprite", "attacker"));
        }

        public void LoadTransfers()
        {
            setShop();
            List<FootballPlayer> transfers = transferList;
            ObservableCollection<FootballPlayer> observableScoreBoards = new ObservableCollection<FootballPlayer>();
            foreach (FootballPlayer transfer in transfers)
            {
                observableScoreBoards.Add(transfer);
            }
            TransList.ItemsSource = observableScoreBoards;
        }
    }
}
