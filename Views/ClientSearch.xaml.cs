using SAKD.ViewModels;
using System.Windows;

namespace SAKD.Views
{
    /// <summary>
    /// Interaction logic for ClientSearch.xaml
    /// </summary>
    public partial class ClientSearch
    {
        public ClientSearchViewModel ViewModel { get; }
        public ClientSearch()
        {
            InitializeComponent();
            DataContext = ViewModel = new ClientSearchViewModel(this);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
