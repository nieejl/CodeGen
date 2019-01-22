using CodeGenerator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodeGenerator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TemplatePage : ContentPage
	{
        TemplateViewModel _vm;
		public TemplatePage (TemplateViewModel vm)
		{
            _vm = vm;
            BindingContext = _vm;
			InitializeComponent ();
		}
    }
}