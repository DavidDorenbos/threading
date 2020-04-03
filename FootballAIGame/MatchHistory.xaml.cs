using FootballAIGame.Source;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FootballAIGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MatchHistory : Page
    {
        private string money = "50";
        private int number = 0;
        public MatchHistory()
        {
            this.InitializeComponent();
            LoadMatchHistory();
            money_bar.Text = money;
        }
        public async void LoadMatchHistory()
        {
            var item = await ApplicationData.Current.LocalFolder.TryGetItemAsync("ScoreBoard.json");

            ObservableCollection<ScoreBoard> observableScoreBoards = new ObservableCollection<ScoreBoard>();
            if (item != null)
            {
                String JSONtxt = File.ReadAllText(ApplicationData.Current.LocalFolder.Path + "/ScoreBoard.json");
                List<ScoreBoard> boards = JsonConvert.DeserializeObject<List<ScoreBoard>>(JSONtxt);

                foreach (ScoreBoard board in boards)
                {
                    observableScoreBoards.Add(board);
                }
                // Create a new ListView (or GridView) for the UI, add content by setting ItemsSource
                ListView ContactsLV = new ListView();
                MatchHistoryList.ItemsSource = observableScoreBoards;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Main_menu));
        }
    }
}
