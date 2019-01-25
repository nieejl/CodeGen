using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGenerator.ViewModels
{
    public class AddTemplateViewModel : BaseViewModel
    {
        private string _id;

        public string Id {
            get { return _id; }
            set {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
    }
}
