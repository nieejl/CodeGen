using CodeGenerator.Models;
using CodeGenerator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CodeGenerator
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel _vm;
        public MainPage()
        {
            //_vm = DependencyService.Get<MainPageViewModel>();
            InitializeComponent();
            _vm = DependencyService.Resolve<MainPageViewModel>();
            BindingContext = _vm;
        }

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as CodeTemplate;
            if (item == null)
                return;
            var nav = (Application.Current as App).navPage;
            await nav.PushAsync(new TemplatePage(new TemplateViewModel(item)));
        }

        
    }
}
