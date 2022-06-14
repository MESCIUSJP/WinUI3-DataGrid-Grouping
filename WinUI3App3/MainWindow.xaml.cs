using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3App3
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private CustomerViewModel customerViewModel = new CustomerViewModel();

        public MainWindow()
        {
            this.InitializeComponent();

            ExtendsContentIntoTitleBar = true;  // enable custom titlebar
            SetTitleBar(AppTitleBar);      // set user ui element as titlebar

            WinUI3DataGrid.ItemsSource = customerViewModel.GroupedCustomers().View;
        }

        private void MainWindow_Activated(object sender, WindowActivatedEventArgs args)
        {
            if (args.WindowActivationState == WindowActivationState.Deactivated)
            {
                AppTitleTextBlock.Foreground =
                    (SolidColorBrush)App.Current.Resources["WindowCaptionForegroundDisabled"];
            }
            else
            {
                AppTitleTextBlock.Foreground =
                    (SolidColorBrush)App.Current.Resources["WindowCaptionForeground"];
            }
        }

        private void WinUI3DataGrid_LoadingRowGroup(object sender, DataGridRowGroupHeaderEventArgs e)
        {
            ICollectionViewGroup group = e.RowGroupHeader.CollectionViewGroup;
            Customer item = group.GroupItems[0] as Customer;
            e.RowGroupHeader.PropertyValue = item.CompanyName;
        }
    }
}
