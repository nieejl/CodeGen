using CodeGenerator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodeGenerator.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddTemplatePage : ContentPage
	{
        AddTemplateViewModel _vm;
		public AddTemplatePage ()
		{
			InitializeComponent ();
            _vm = new AddTemplateViewModel();
            BindingContext = _vm;
		}

        public async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (_vm.FilenameExist())
            {
                bool overwrite = await DisplayAlert("File exists.", "Do you want to overwrite existing file?", "Yes", "No");
                if (!overwrite)
                    return;
            }
            await _vm.SaveTemplate();
        } 
	}
}