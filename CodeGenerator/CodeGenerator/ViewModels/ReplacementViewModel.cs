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
        private string _varName;
        public string VarName {
            get {
                return _varName;
            }
            set {
                _varName = value;
                OnPropertyChanged("VarName");
            }
        }
        private string _varValue;


        public string VarValue {
            get {
                return _varValue;
            }
            set {
                _varValue = value;
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
