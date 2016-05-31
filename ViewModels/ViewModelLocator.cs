using System;
using System.Linq;
using System.Reflection;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using MvvmLightUwpExample.Helpers.Attributes;
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
            if (!Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                SimpleIoc.Default.Register(() => this);
                SimpleIoc.Default.Register(CreateNavigationService);

                SimpleIoc.Default.Register<IItemsProvider, ItemsProvider>();
            }
            else
            {
                SimpleIoc.Default.Register<IItemsProvider, Services.Design.ItemsProvider>();
            }

            //RegisterService<IItemsProvider>();

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
        private void RegisterService<T>() where T : class
        {
            var type = typeof(T);

            var dependencyInformationAttribute = type.GetTypeInfo().GetCustomAttributes().OfType<DependencyInformationAttribute>().FirstOrDefault();

            if (dependencyInformationAttribute == null)
                throw new InvalidOperationException($"Tried to register service {type.FullName}, but it has no {nameof(DependencyInformationAttribute)}.");

            if (dependencyInformationAttribute.DesigntimeImplementation != null && Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                SimpleIoc.Default.Register(() => (T)Activator.CreateInstance(dependencyInformationAttribute.DesigntimeImplementation));
            else
                SimpleIoc.Default.Register(() => (T)Activator.CreateInstance(dependencyInformationAttribute.RuntimeImplementation));
        }
    }
}
