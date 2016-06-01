using System.ComponentModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using MvvmLightUwpExample.Helpers.Extensions;
using MvvmLightUwpExample.Models;
using MvvmLightUwpExample.Views;

namespace MvvmLightUwpExample.ViewModels
{
    public class EditItemPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private TaskCompletionSource<bool> _modalTaskCompletionSource;

        private Item _item = new Item();

        public Item Item
        {
            get { return _item; }
            set
            {
                if (Item == value) return;

                _item = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand OkCommand { get; }

        public RelayCommand CancelCommand { get; }

        public RelayCommand NotifyNavigatedFrom { get; }

        public EditItemPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            OkCommand = new RelayCommand(() => SetModalResultAndNavigateBack(true));
            CancelCommand = new RelayCommand(() => SetModalResultAndNavigateBack(false));
            NotifyNavigatedFrom = new RelayCommand(NavigatedFrom);
        }

        private void SetModalResultAndNavigateBack(bool result)
        {
            _modalTaskCompletionSource?.TrySetResult(result);

            _navigationService.GoBack();
        }

        private void NavigatedFrom()
        {
            _modalTaskCompletionSource?.TrySetResult(false);
        }

        public Task<bool> ShowAsModal()
        {
            _modalTaskCompletionSource = new TaskCompletionSource<bool>();
            
            _navigationService.NavigateTo(typeof(EditItemPage));
            
            return _modalTaskCompletionSource.Task;
        }
    }
}
