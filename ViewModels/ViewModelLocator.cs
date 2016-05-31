using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using MvvmLightUwpExample.Extensions;
using MvvmLightUwpExample.Services;
using MvvmLightUwpExample.Services.Interfaces;
using MvvmLightUwpExample.Views;

namespace MvvmLightUwpExample.ViewModels
{
    public class ViewModelLocator
    {
        public MainPageViewModel MainPage => SimpleIoc.Default.GetInstance<MainPageViewModel>();

        public EditItemPageViewModel EditItemPage => SimpleIoc.Default.GetInstance<EditItemPageViewModel>();
        
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register(() => this);
            SimpleIoc.Default.Register<INavigationService>(CreateNavigationService);

            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                SimpleIoc.Default.Register<IItemsProvider, Services.Design.ItemsProvider>();
            }
            else
            {
                SimpleIoc.Default.Register<IItemsProvider, ItemsProvider>();
            }

            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<EditItemPageViewModel>();
        }

        private static INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();

            navigationService.Configure(typeof(MainPage));
            navigationService.Configure(typeof(EditItemPage));

            return navigationService;
        }
    }
}
