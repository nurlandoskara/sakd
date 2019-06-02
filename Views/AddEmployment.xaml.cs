using SAKD.Models;
using SAKD.ViewModels;
using System.Windows;

namespace SAKD.Views
{
    /// <summary>
    /// Interaction logic for AddAddress.xaml
    /// </summary>
    public partial class AddEmployment
    {
        public AddEmploymentViewModel ViewModel { get; }
        public AddEmployment(Employment employment)
        {
            InitializeComponent();
            DataContext = ViewModel = new AddEmploymentViewModel(this, employment);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
