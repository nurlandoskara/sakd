using System.Windows;
using SAKD.Models;
using SAKD.ViewModels;

namespace SAKD.Views
{
    /// <summary>
    /// Interaction logic for Anketa.xaml
    /// </summary>
    public partial class Anketa
    {
        public AnketaViewModel ViewModel { get; set; }
        public Anketa(Order order, ModelContainer context)
        {
            InitializeComponent();
            DataContext = ViewModel = new AnketaViewModel(this, order, context);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private WebCam _webCam;
        private void PhotoButton_OnClick(object sender, RoutedEventArgs e)
        {
            _webCam = new WebCam();
            _webCam.InitializeWebCam(ref imgVideo);
            _webCam.Start();
        }
    }
}
