using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Ioc;
using MvvmLightUwpExample.ViewModels;

namespace MvvmLightUwpExample.Views
{
    public sealed partial class EditItemPage
    {
        public EditItemPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // TODO: Are we allowed to do this?
            SimpleIoc.Default.GetInstance<ViewModelLocator>().EditItemPage.NotifyNavigatedFrom?.Execute(null);
        }
    }
}
