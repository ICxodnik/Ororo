using Logic;
using System;
using System.Collections.Generic;

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

namespace Ororo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string BaseUrl = "https://ororo.tv/ru";
        const string FilmsUrl = "https://ororo.tv/ru/movies";
        const string VideoUrl = "https://ororo.tv/ru/movies";

        public MainWindow()
        {
            InitializeComponent();

        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Downloader load = new Downloader();
            listView.ItemsSource = load.GetAllPosterInfoBriefly(BaseUrl);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Downloader load = new Downloader();
            listView.ItemsSource = load.GetAllPosterInfoBriefly(FilmsUrl);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DownloaderVideo load = new DownloaderVideo();
            listView.ItemsSource = load.GetAllPosterInfoBriefly(VideoUrl);
        }
    }
}

