using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using MvvmLightUwpExample.Helpers.Extensions;
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
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                RegisterDesignTimeServices();
            }
            else
            {
                RegisterRuntimeServices();
            }

            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<EditItemPageViewModel>();
        }

        private static void RegisterDesignTimeServices()
        {
            SimpleIoc.Default.Register<ViewModelLocator>();

            SimpleIoc.Default.Register<IItemsProvider, Services.Design.ItemsProvider>();
        }

        private void RegisterRuntimeServices()
        {
            SimpleIoc.Default.Register(() => this);
            SimpleIoc.Default.Register(CreateNavigationService);

            SimpleIoc.Default.Register<IItemsProvider, ItemsProvider>();
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
