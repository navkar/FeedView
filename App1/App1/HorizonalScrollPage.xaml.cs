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
	public partial class HorizonalScrollPage : ContentPage
	{
		public HorizonalScrollPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ButtonStack.ItemsSource = ListDataModel.MockUserData();

            var dataModel = new ObservableCollection<ListDataModel>();

            for (int i = 0; i < 10; i++)
            {
                dataModel.Add(new ListDataModel() { IconUri = "user.png", Text = string.Format("This is going to be a long status message. This is going to be a long status message. This is going to be a long status message. This is going to be a long status message. Hope you got it. {0} says 'OM'.", DateTime.UtcNow.Ticks) });
            }

            UserLV.ItemsSource = dataModel;
        }
    }
}