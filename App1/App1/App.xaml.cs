using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FreshMvvm;
using App1.Helpers;
using Acr.UserDialogs;
using App1.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            FreshIOC.Container.Register<IUserDialogs>(UserDialogs.Instance);
            FreshPageModelResolver.PageModelMapper = new FreshViewModelMapper();
            //MainPage = new NavigationPage(new HorizonalScrollPage());

            var page = FreshPageModelResolver.ResolvePageModel<MarketplaceFeedViewModel>();
            var stack = new FreshNavigationContainer(page, "NewStack");

            MainPage = stack;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
