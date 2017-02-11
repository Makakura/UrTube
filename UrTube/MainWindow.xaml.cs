using System;
using System.Collections.Generic;
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
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace UrTube
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Page 2 var
        List<Google.Apis.YouTube.v3.Data.SearchResult> lstResult;
        //End Page 2 var
        public MainWindow()
        {
            InitializeComponent();
            ChangeState(1);
            lstResult = new List<Google.Apis.YouTube.v3.Data.SearchResult>();
        }
        //Page 2 Method
        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            await Run();
        }
        private async Task Run()
        {
            try
            {
                var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyC5IkscZNJZCEQ_Z8shR80_vi0hFkYS07o",
                    ApplicationName = this.GetType().ToString()
                });

                var searchListRequest = youtubeService.Search.List("snippet");
                searchListRequest.Q = "Makakura"; // Replace with your search term.
                searchListRequest.MaxResults = 50;

                // Call the search.list method to retrieve results matching the specified query term.
                var searchListResponse = await searchListRequest.ExecuteAsync();

                // Add each result to the appropriate list, and then display the lists of
                // matching videos, channels, and playlists.
                foreach (var searchResult in searchListResponse.Items)
                {
                    if (searchResult.Id.Kind == "youtube#video")
                        lstResult.Add(searchResult);
                }
                lvVideoResult.ItemsSource = lstResult;
            }
            catch (Exception e)
            {

            }

        }
        //End Page 2 method
        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void ChangeState(int state)
        {
            switch (state)
            {
                case 1:
                    grLogin.Visibility = Visibility.Visible;
                    grPickResource.Visibility = Visibility.Collapsed;
                    tblState1.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                    tblState2.SetValue(TextBlock.FontWeightProperty, FontWeights.Regular);
                    tblState3.SetValue(TextBlock.FontWeightProperty, FontWeights.Regular);
                    tblState4.SetValue(TextBlock.FontWeightProperty, FontWeights.Regular);
                    tblState1.SetValue(TextBlock.FontSizeProperty, 20);
                    tblState2.SetValue(TextBlock.FontSizeProperty, 16);
                    tblState3.SetValue(TextBlock.FontSizeProperty, 16);
                    tblState4.SetValue(TextBlock.FontSizeProperty, 16);
                    grStateLine1.Visibility = Visibility.Visible;
                    grStateLine2.Visibility = Visibility.Collapsed;
                    grStateLine3.Visibility = Visibility.Collapsed;
                    grStateLine4.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    grLogin.Visibility = Visibility.Collapsed;
                    grPickResource.Visibility = Visibility.Visible;
                    tblState2.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                    tblState1.SetValue(TextBlock.FontWeightProperty, FontWeights.Regular);
                    tblState3.SetValue(TextBlock.FontWeightProperty, FontWeights.Regular);
                    tblState4.SetValue(TextBlock.FontWeightProperty, FontWeights.Regular);
                    tblState2.SetValue(TextBlock.FontSizeProperty, 20);
                    tblState1.SetValue(TextBlock.FontSizeProperty, 16);
                    tblState3.SetValue(TextBlock.FontSizeProperty, 16);
                    tblState4.SetValue(TextBlock.FontSizeProperty, 16);
                    grStateLine2.Visibility = Visibility.Visible;
                    grStateLine1.Visibility = Visibility.Collapsed;
                    grStateLine3.Visibility = Visibility.Collapsed;
                    grStateLine4.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    tblState3.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                    tblState2.SetValue(TextBlock.FontWeightProperty, FontWeights.Regular);
                    tblState1.SetValue(TextBlock.FontWeightProperty, FontWeights.Regular);
                    tblState4.SetValue(TextBlock.FontWeightProperty, FontWeights.Regular);
                    tblState3.SetValue(TextBlock.FontSizeProperty, 20);
                    tblState2.SetValue(TextBlock.FontSizeProperty, 16);
                    tblState1.SetValue(TextBlock.FontSizeProperty, 16);
                    tblState4.SetValue(TextBlock.FontSizeProperty, 16);
                    grStateLine3.Visibility = Visibility.Visible;
                    grStateLine1.Visibility = Visibility.Collapsed;
                    grStateLine2.Visibility = Visibility.Collapsed;
                    grStateLine4.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    tblState4.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                    tblState1.SetValue(TextBlock.FontWeightProperty, FontWeights.Regular);
                    tblState2.SetValue(TextBlock.FontWeightProperty, FontWeights.Regular);
                    tblState3.SetValue(TextBlock.FontWeightProperty, FontWeights.Regular);
                    tblState4.SetValue(TextBlock.FontSizeProperty, 20);
                    tblState1.SetValue(TextBlock.FontSizeProperty, 16);
                    tblState2.SetValue(TextBlock.FontSizeProperty, 16);
                    tblState3.SetValue(TextBlock.FontSizeProperty, 16);
                    grStateLine4.Visibility = Visibility.Visible;
                    grStateLine1.Visibility = Visibility.Collapsed;
                    grStateLine2.Visibility = Visibility.Collapsed;
                    grStateLine3.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            ChangeState(2);
        }
    }
}
