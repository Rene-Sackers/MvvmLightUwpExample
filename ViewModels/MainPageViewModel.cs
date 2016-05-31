using System.Collections.Generic;
using System.Collections.ObjectModel;
using MvvmLightUwpExample.Models;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmLightUwpExample.Services.Interfaces;

namespace MvvmLightUwpExample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly ViewModelLocator _viewModelLocator;

        public IList<Item> Items { get; set; } = new ObservableCollection<Item>();

        public RelayCommand AddItemCommand { get; set; }

        public MainPageViewModel(IItemsProvider itemsProvider/*, ViewModelLocator viewModelLocator*/)
        {
            //_viewModelLocator = viewModelLocator;
            itemsProvider.GetItems().ToList().ForEach(Items.Add);

            AddItemCommand = new RelayCommand(AddItem);
        }

        private async void AddItem()
        {
            _viewModelLocator.EditItemPage.Item = new Item();

            var modalResult = await _viewModelLocator.EditItemPage.ShowAsModal();
            if (modalResult)
                Items.Add(_viewModelLocator.EditItemPage.Item);
        }
    }
}
