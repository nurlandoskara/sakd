using SAKD.Models;
using SAKD.ViewModels;
using System.Windows;

namespace SAKD.Views
{
    /// <summary>
    /// Interaction logic for AddAddress.xaml
    /// </summary>
    public partial class AddAddress
    {
        public AddAddressViewModel ViewModel { get; }
        public AddAddress(Address address)
        {
            InitializeComponent();
            DataContext = ViewModel = new AddAddressViewModel(this, address);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
