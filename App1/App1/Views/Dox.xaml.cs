using App1.Models;
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
    }
}