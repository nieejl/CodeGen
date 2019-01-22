using CodeGenerator.Models;
using CodeGenerator.Services;
using CodeGenerator.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CodeGenerator
{
    public partial class App : Application
    {
        public NavigationPage navPage { get; private set; }

        public App()
        {
            InitializeComponent();
            RegisterServices();
            navPage = new NavigationPage();
            MainPage = navPage;
            navPage.PushAsync(new MainPage());
        }

        private void RegisterServices()
        {
            DependencyService.Register<IDataStore<CodeTemplate>, MockDataStore>();
            DependencyService.Register<MainPageViewModel>();
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
