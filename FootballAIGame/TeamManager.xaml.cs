using FootballAIGame.Source;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Numerics;

using Windows.UI.Xaml.Controls;

using Microsoft.Xna.Framework;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FootballAIGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TeamManager : Page
    {
        TeamManagement manager;
        Currency currency = new Currency();
        public TeamManager()
        {
            this.InitializeComponent();
            manager = new TeamManagement();
            LoadMatchHistory();
            money_bar.Text = currency.getCurrency().ToString();
        }
        public void LoadMatchHistory()
        {

  
            List<FootballPlayer> boards = manager.OwnedPlayers;


            ObservableCollection<FootballPlayer> observableScoreBoards = new ObservableCollection<FootballPlayer>();

            foreach (FootballPlayer board in boards)
            {
                observableScoreBoards.Add(board);
            }

            StudentsList.ItemsSource = observableScoreBoards;
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Main_menu));
        }
    }
}
