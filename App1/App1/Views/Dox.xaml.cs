using App1.Models;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Dox : ContentPage
	{
        ObservableCollection<MarketplaceFeedModel> dataModel = null;
        public Dox ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            DoxLV.ItemsSource = MarketplaceFeedModel.MockUserData();
        }
        public async void OpenCameraSystem(object o, ItemTappedEventArgs e)
        {
            var feedModel = e.Item as MarketplaceFeedModel;

            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            //await DisplayAlert("File Location", file.Path, "OK");

            //var image = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    return stream;
            //});

            feedModel.IconUri = file.Path;


            DoxLV.SelectedItem = null;
        }
    }
}