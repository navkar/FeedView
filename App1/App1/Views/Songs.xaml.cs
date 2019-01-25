using App1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Songs : ContentPage
    {
        public Songs()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            AlbumLV.ItemsSource = AlbumModel.MockAlbumData();
        }

        public async void OpenCameraSystem(object o, ItemTappedEventArgs e)
        {
            AlbumLV.SelectedItem = null;
        }
    }
}