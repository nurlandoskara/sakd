using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SAKD.Models;
using SAKD.ViewModels;

namespace SAKD.Views
{
    /// <summary>
    /// Interaction logic for WorkSpace.xaml
    /// </summary>
    public partial class WorkSpace
    {
        private readonly WorkSpaceViewModel _viewModel;
        public WorkSpace()
        {
            InitializeComponent();
            DataContext = _viewModel = new WorkSpaceViewModel();
        }


        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            _viewModel.SelectedNode = (Node) TreeView.SelectedItem;
        }
    }
}
