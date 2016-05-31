using System.Collections.Generic;
using System.Collections.ObjectModel;
using MvvmLightUwpExample.Models;
using System.Linq;
using MvvmLightUwpExample.Services.Interfaces;

namespace MvvmLightUwpExample.ViewModels
{
    public class MainPageViewModel
    {
        public IList<Item> Items { get; set; } = new ObservableCollection<Item>();

        public MainPageViewModel(IItemsProvider itemsProvider)
        {
            itemsProvider.GetItems().ToList().ForEach(Items.Add);
        }
    }
}
