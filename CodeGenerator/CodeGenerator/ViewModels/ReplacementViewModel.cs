using CodeGenerator.Models;
using CodeGenerator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CodeGenerator.ViewModels
{
    public class ReplacementViewModel : INotifyPropertyChanged
    {
        public ReplacementViewModel(IReplacement replacement)
        {
            Replacement = replacement;
        }

        private IReplacement _replacement;
        public IReplacement Replacement {
            get {
                return _replacement;
            }
            set {
                _replacement = value;
                OnPropertyChanged("Replacement");
                //OnPropertyChanged("VarName");
                //OnPropertyChanged("VarValue");
            }
        }
        public string VarName {
            get {
                return Replacement.VarName;
            }
            set {
                Replacement.VarName = value;
                OnPropertyChanged("VarName");
            }
        }


        public string VarValue {
            get {
                return Replacement.VarValue;
            }
            set {
                Replacement.VarValue = value;
                OnPropertyChanged("VarValue");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
