using FootballAIGame.Source;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class Main_menu : Page
    {
        private string money = "50";
        public Main_menu()
        {
            this.InitializeComponent();
            money_bar.Text = money;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GamePage));
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TeamManager));
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Shop));
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MatchHistory));
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Settings));
        }
    }
}
