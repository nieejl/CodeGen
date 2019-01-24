using CodeGenerator.Extensions;
using CodeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace CodeGenerator.ViewModels
{
    public class TemplateViewModel : BaseViewModel
    {
        private CodeTemplate _template;
        public CodeTemplate Template {
            get { return _template; }
            set {
                _template = value;
                OnPropertyChanged("Template");
            }
        }
        public bool IsFromGeneration { get; set; }
        private string _generatedContent;
        public string GeneratedContent {
            get {
                return _generatedContent;
            }
            set {
                if (!IsFromGeneration)
                {
                    return;
                }
                _generatedContent = value;
                OnPropertyChanged("GeneratedContent");
            }
        }
        public Command CopyButtonCommand => new Command(async () =>
        {
            await Clipboard.SetTextAsync(GeneratedContent);
        });

        public ObservableCollection<ReplacementViewModel> Replacements { get; set; }
        public TemplateViewModel(CodeTemplate template)
        {
            IsFromGeneration = true;
            Template = template;

            var replacements = template.FindReplacements();
            GeneratedContent = template.GenerateContent(replacements);
            var rvms = replacements.Select(r => new ReplacementViewModel(r));
            Replacements = rvms.AsObservableCollection();
            AddReplacementChangedEventHandler();

            IsFromGeneration = false;
        }

        public void AddReplacementChangedEventHandler()
        {
            foreach (object item in Replacements)
            {
                if (item is INotifyPropertyChanged observable)
                {
                    observable.PropertyChanged +=
                        new PropertyChangedEventHandler(ReplacementChanged);
                }
            }
        }

        private void ReplacementChanged(object sender, PropertyChangedEventArgs e)
        {
            var send = (ReplacementViewModel)sender;
            IsFromGeneration = true;
            GeneratedContent = Template.GenerateContent(Replacements.Select(rvm => rvm.Replacement));
            IsFromGeneration = false;
        }


    }
}
