using System.Windows;

namespace SAKD.Views
{
    /// <summary>
    /// Interaction logic for CreditsPage.xaml
    /// </summary>
    public partial class CreditsPage : Window
    {
        public CreditsPage()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var page = new LoginPage();
            page.Show();
            this.Close();
        }
    }
}
