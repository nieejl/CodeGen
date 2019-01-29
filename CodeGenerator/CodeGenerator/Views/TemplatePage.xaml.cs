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
	public partial class TemplatePage : ContentPage
	{
        TemplateViewModel _vm;
		public TemplatePage (TemplateViewModel vm)
		{
			InitializeComponent ();
            _vm = vm;
            BindingContext = _vm;
		}
    }
}