using GalaSoft.MvvmLight.Ioc;
using MvvmLightUwpExample.Services;
using MvvmLightUwpExample.Services.Interfaces;

namespace MvvmLightUwpExample.ViewModels
{
    public class ViewModelLocator
    {
        public MainPageViewModel MainPage => SimpleIoc.Default.GetInstance<MainPageViewModel>();

        public ViewModelLocator()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                SimpleIoc.Default.Register<IItemsProvider, Services.Design.ItemsProvider>();
            }
            else
            {
                SimpleIoc.Default.Register<IItemsProvider, ItemsProvider>();
            }

            SimpleIoc.Default.Register<MainPageViewModel>();
        }
    }
}
