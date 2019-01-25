using CodeGenerator.Models;
using CodeGenerator.Services;
using CodeGenerator.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Unity;
using Unity.Injection;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CodeGenerator
{
    public partial class App : Application
    {
        public NavigationPage navPage { get; private set; }
        public static UnityContainer Container { get; set; }

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
            Container = new UnityContainer();
            DependencyService.Register<IDirectory>();
            //Container.RegisterType<IDirectory>(new InjectionConstructor(DependencyService.Get<IDirectory>()));
            Container.RegisterType<IDataStore<CodeTemplate>, FlatFileDataStore>(
                new InjectionConstructor(DependencyService.Get<IDirectory>()));
            Container.RegisterType<MainPageViewModel>();
            //DependencyService.Register<MainPageViewModel>();
            
        }
        private void RegisterDeviceSpecificServices()
        {
            DependencyService.Register<IDirectory>();
            switch (Device.RuntimePlatform)
            {
                case Device.UWP:
                    break;
                case Device.iOS:

                    break;

                case Device.Android:

                    break;
            }
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
