using System;
using System.Windows;

namespace SAKD.Views
{
    /// <summary>
    /// Interaction logic for ClientSearch.xaml
    /// </summary>
    public partial class ClientSearch
    {
        public ClientSearch()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
