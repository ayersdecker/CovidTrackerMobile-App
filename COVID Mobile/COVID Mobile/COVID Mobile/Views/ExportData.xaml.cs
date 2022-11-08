using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COVID_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExportData : ContentPage
    {  
        IDownloader downloader = DependencyService.Get<IDownloader>();
        public ExportData()
        {
           
            InitializeComponent();
            //downloader.OnFileDownloaded += OnFileDownloaded;
        }
        private void OnFileDownloaded(object sender, DownloadEventArgs e)
        {
            if (e.FileSaved)
            {
                DisplayAlert("XF Downloader", "File Saved Successfully", "Close");
            }
            else
            {
                DisplayAlert("XF Downloader", "Error while saving the file", "Close");
            }
        }

        //private void DownloadClicked(object sender, EventArgs e)
        //{
        //    downloader.DownloadFile("http://www.dada-data.net/uploads/image/hausmann_abcd.jpg", "XF_Downloads");
        //}

        private void CSV_Export_Clicked(object sender, EventArgs e)
        {
            //TODO <- Export Data to CSV

            Navigation.PopAsync();
        }

        private void Report_Export_Clicked(object sender, EventArgs e)
        {
           // IDownloader downloader = DependencyService.Get<IDownloader>();
            //TODO <- Export Data within a Generated Report
           // downloader.DownloadFile("http://www.dada-data.net/uploads/image/hausmann_abcd.jpg", "XF_Downloads");
            Navigation.PopAsync();
        }
    }
}