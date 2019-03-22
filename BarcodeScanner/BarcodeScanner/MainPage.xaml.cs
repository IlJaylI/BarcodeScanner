using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            
            //needs proper conversion checks 
            int imgAmount = Convert.ToInt32(Amount.Text);
            Stream[] ImageArray = new Stream[imgAmount];

            Data.Client = Client.Text;
            Data.Batch = Batch.Text;
            Debug.WriteLine("Batch: " + Data.Batch + "Client: " + Data.Client);

            for (int i=0; i < imgAmount; i++)
            {
                string name = Guid.NewGuid().ToString() + ".jpg";
                Debug.WriteLine("Filename Creted: " + name);

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", "No Camera Avalible", "OK");
                }


                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                });


                if (file == null)
                    return;

                Data.Image = file.GetStream();
                ImageArray[i] = file.GetStream();
                Debug.WriteLine("Array size: "+ImageArray.Length);
            }

            //Check internet connection

            //add date to object?

            //Preview
            //Image1.Source = ImageSource.FromStream(() => file.GetStream());
        }

    }
}
