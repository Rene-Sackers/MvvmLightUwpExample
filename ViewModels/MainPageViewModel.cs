using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MvvmLightUwpExample.Models;
using System.Linq;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using MvvmLightUwpExample.Helpers.Extensions;
using MvvmLightUwpExample.Services.Interfaces;
using MvvmLightUwpExample.Views;

namespace MvvmLightUwpExample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly EditItemPageViewModel _editPageViewModel;

        public IList<Item> Items { get; set; } = new ObservableCollection<Item>();

        private Item _selectedItem;

        public Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (SelectedItem == value) return;

                _selectedItem = value;
                RaisePropertyChanged();
                EditSelectedItemCommand.RaiseCanExecuteChanged();
                DeleteSelectedItemCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand AddItemCommand { get; set; }

        public RelayCommand EditSelectedItemCommand { get; set; }

        public RelayCommand DeleteSelectedItemCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService, IItemsProvider itemsProvider, EditItemPageViewModel editPageViewModel)
        {
            _navigationService = navigationService;
            _editPageViewModel = editPageViewModel;
            itemsProvider.GetItems().ToList().ForEach(Items.Add);

            AddItemCommand = new RelayCommand(AddItem);
            EditSelectedItemCommand = new RelayCommand(EditSelecteditem, () => SelectedItem != null);
            DeleteSelectedItemCommand = new RelayCommand(DeleteSelectedItem, () => SelectedItem != null);
        }

        private void EditSelecteditem()
        {
            _editPageViewModel.Item = SelectedItem;
            _navigationService.NavigateTo(typeof(EditItemPage));
        }

        private async void DeleteSelectedItem()
        {
            var messageDialog =
                new MessageDialog($"Are you sure you want to delete the item title \"{SelectedItem.Title}\"?", "Delete item");

            var yesCommand = new UICommand("Yes");
            var noCommand = new UICommand("No");

            messageDialog.Commands.Add(yesCommand);
            messageDialog.Commands.Add(noCommand);

            var pressedCommand = await messageDialog.ShowAsync();

            if (pressedCommand == yesCommand)
                Items.Remove(SelectedItem);
        }

        private async void AddItem()
        {
            _editPageViewModel.Item = new Item();

            var modalResult = await _editPageViewModel.ShowAsModal();
            if (modalResult)
                Items.Add(_editPageViewModel.Item);
        }
    }
}
