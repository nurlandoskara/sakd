using System;
using System.Windows;
using System.Windows.Controls;

namespace SAKD.Views
{
    /// <summary>
    /// Interaction logic for WorkSpace.xaml
    /// </summary>
    public partial class WorkSpace : Window
    {
        public WorkSpace()
        {
            InitializeComponent();
        }

        private void TreeViewItem_OnSelected(object sender, RoutedEventArgs e)
        {
            var tag = (int)((TreeViewItem) sender).Tag;
            switch ((Enums.Status)tag)
            {
                case Enums.Status.All:
                    break;
                case Enums.Status.S1:
                    break;
                case Enums.Status.S2:
                    break;
                case Enums.Status.S3:
                    break;
                case Enums.Status.S4:
                    break;
                case Enums.Status.S5:
                    break;
                case Enums.Status.S6:
                    break;
                case Enums.Status.S7:
                    break;
                case Enums.Status.S8:
                    break;
                case Enums.Status.S81:
                    break;
                case Enums.Status.S9:
                    break;
                case Enums.Status.S10:
                    break;
                case Enums.Status.S11:
                    break;
                case Enums.Status.S12:
                    break;
                case Enums.Status.S13:
                    break;
                case Enums.Status.S14:
                    break;
                case Enums.Status.S15:
                    break;
                case Enums.Status.S16:
                    break;
                case Enums.Status.S17:
                    break;
                case Enums.Status.S18:
                    break;
                case Enums.Status.Error1:
                    break;
                case Enums.Status.Error2:
                    break;
                case Enums.Status.Hot:
                    break;
                case Enums.Status.Warm:
                    break;
                case Enums.Status.Cold:
                    break;
                case Enums.Status.Accepted:
                    break;
                case Enums.Status.Cancelled:
                    break;
                case Enums.Status.CancelledByClient:
                    break;
                case Enums.Status.CancelledByThird:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
