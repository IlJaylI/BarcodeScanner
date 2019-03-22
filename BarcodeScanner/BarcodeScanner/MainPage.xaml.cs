using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BarcodeScanner
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void TakePicture(object sender,EventArgs e)
        {
            Classes.ToUpload Data = new Classes.ToUpload();

            //Check internet connection

            string name = Guid.NewGuid().ToString();
            name += ".jpg";
            Debug.WriteLine("Filename Creted: "+name);


            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", "No Camera Avalible", "OK");
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                SaveToAlbum = true,
                Name = name
            });

            if (file == null)
                return;

            Data.Image = file.GetStream();
            Data.Client = Client.Text;
            Data.Batch = Batch.Text;

            Debug.WriteLine("Batch: " + Data.Batch +"Client: " + Data.Client);

            //add date to object?






            //Preview
            //Image1.Source = ImageSource.FromStream(() => file.GetStream());
        }

    }
}
