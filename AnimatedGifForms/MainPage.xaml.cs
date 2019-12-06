using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using Xamarin.Forms;

namespace AnimatedGifForms
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public bool IsPlaying { get; set; }
        public string secondImageSource { get; set; } = "/data/user/0/nl.versluis.animatedgifforms/files/Dimg.gif";
        WebClient _webClientBlobDownload = null;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            secondImageSource = Path.Combine(path, "Dimg.gif");
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            IsPlaying = !IsPlaying;
            OnPropertyChanged(nameof(IsPlaying));
        }
        void Download_Clicked(object sender, EventArgs e)
        {

            if (_webClientBlobDownload == null)
            {
                _webClientBlobDownload = new WebClient();
                _webClientBlobDownload.DownloadDataCompleted += new DownloadDataCompletedEventHandler(image_DownloadDataCompleted);
            }
            string nextURL = "https://blog.commlabindia.com/wp-content/uploads/2019/07/animated-gifs-corporate-training.gif";


            _webClientBlobDownload.DownloadDataAsync(new Uri(nextURL), secondImageSource);
        }

        private void image_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            try
            {


                if (e.Cancelled == true)
                {

                    return;
                }

                if (e.Error != null)
                {
                    return;
                }
                // some websides give a 200 when the image is not there and than the client downlaods the HTML
                // therefore check if the content type is a image before saving

                byte[] bytes = new byte[e.Result.Length]; // get the downloaded data

                string localPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), secondImageSource);
                File.WriteAllBytes(localPath, bytes); // writes to local storage

                OnPropertyChanged(nameof(secondImageSource));

            }
            catch (Exception ex)
            {

            }
        }
    }
}