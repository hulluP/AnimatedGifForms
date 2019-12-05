using System;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;

namespace AnimatedGifForms
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public bool IsPlaying { get; set; }
        public string secondImageSource { get; set; }

        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            secondImageSource = Path.Combine(path, "Dimg.gif");
            OnPropertyChanged(nameof(secondImageSource));
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            IsPlaying = !IsPlaying;
            OnPropertyChanged(nameof(IsPlaying));
        }


    }
}