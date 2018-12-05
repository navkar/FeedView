using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FreshListView : ContentPage
	{
        ObservableCollection<ListDataModel> dataModel = null;
		public FreshListView ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            TodaysDate.Text = DateTime.UtcNow.ToString("g");

            dataModel = new ObservableCollection<ListDataModel>();

            for (int i=0; i < 10; i++)
            {
                dataModel.Add(new ListDataModel() { IconUri = "namaste.png", Text = string.Format("{0} says 'OM'.", DateTime.UtcNow.Ticks) });
            }

            UserLV.ItemsSource = dataModel;
        }
    }
}