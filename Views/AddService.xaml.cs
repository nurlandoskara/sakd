using System.Collections.ObjectModel;
using System.Windows;
using SAKD.Models;
using SAKD.ViewModels;

namespace SAKD.Views
{
    /// <summary>
    /// Interaction logic for AddService.xaml
    /// </summary>
    public partial class AddService
    {
        public AddService(ObservableCollection<AdditionalService> additionalServices,
            AdditionalService additionalService = null)
        {
            InitializeComponent();
            DataContext = new AddServiceViewModel(this, additionalServices, additionalService);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
