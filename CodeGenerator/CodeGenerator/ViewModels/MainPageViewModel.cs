using CodeGenerator.Models;
using CodeGenerator.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CodeGenerator.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<CodeTemplate> Templates { get; set; }
        public Command LoadItemsCommand { get; set; }
        
        public MainPageViewModel()
        {
            Templates = new ObservableCollection<CodeTemplate>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            var task = ExecuteLoadItemsCommand();
            Task.WaitAll(task);
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                var items = await DataStore.GetItemsAsync();
                Templates.Clear();
                foreach (var template in items)
                {
                    Templates.Add(template);
                }
            }
            // TODO: Add error message and log error on exception.
            finally
            {
                IsBusy = false;
            }
        }
    }
}
