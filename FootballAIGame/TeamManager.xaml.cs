using FootballAIGame.Source;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FootballAIGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TeamManager : Page
    {
        TeamManagement manager;
        public TeamManager()
        {
            this.InitializeComponent();
            manager = new TeamManagement();
            LoadMatchHistory();
        }
        public void LoadMatchHistory()
        {
            List<FootballPlayer> boards = manager.OwnedPlayers;
            ObservableCollection<FootballPlayer> observableScoreBoards = new ObservableCollection<FootballPlayer>();
            foreach (FootballPlayer board in boards)
            {
                observableScoreBoards.Add(board);
            }
            TeamList.ItemsSource = observableScoreBoards;
        }
    }
}
