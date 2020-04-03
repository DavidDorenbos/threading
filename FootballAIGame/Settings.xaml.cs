using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Main_menu));
        }

        private void PlayTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string time = e.AddedItems[0].ToString();
            string selectedtime = "0";
            switch(time)
            {
                case "3 minuten":
                    selectedtime = "3";
                    break;
                case "5 minuten":
                    selectedtime = "5";
                    break;
                case "10 minuten":
                    selectedtime = "10";
                    break;
            }
            string playtime = selectedtime;
        }
    }
}
