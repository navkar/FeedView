using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FreshMvvm;
using App1.Helpers;
using Acr.UserDialogs;
using App1.ViewModels;
using App1.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1
{
    public partial class App : Application
    {
        public static string User = "Naveen";
        public App()
        {
            InitializeComponent();
            
            FreshIOC.Container.Register<IUserDialogs>(UserDialogs.Instance);
            FreshPageModelResolver.PageModelMapper = new FreshViewModelMapper();
            //MainPage = new NavigationPage(new HorizonalScrollPage());

            var page = FreshPageModelResolver.ResolvePageModel<MarketplaceFeedViewModel>();
            var stack = new FreshNavigationContainer(page, "NewStack");

            
            var chatPage = FreshPageModelResolver.ResolvePageModel<ChatPageViewModel>();
            var chat = new FreshNavigationContainer(chatPage, "ChatStack");


            MainPage = new Songs();
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
