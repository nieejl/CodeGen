﻿using CodeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        private string _description;
        public string Description {
            get { return _description; }
            set {
                _description = value;
                OnPropertyChanged("Description");
            }
        }
        private string _content;
        public string Content {
            get { return _content; }
            set {
                _content = value;
                OnPropertyChanged("Content");
            }
        }

        private CodeTemplate CreateTemplate()
        {
            return new CodeTemplate { Id = Id, Content = Content, Description = Description };
        }

        public async Task<bool> SaveTemplate()
        {
            return await DataStore.AddItemAsync(CreateTemplate());
        }
    }
}
