using OOCProject.ViewModel;
using System.Windows.Controls;

namespace OOCProject.Views
{
    public partial class WholeStockListView : UserControl
    {
        public WholeStockListView() => InitializeComponent();

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e) => WholeStockListViewModel.ItemSelect(WholeStockListViewModel.CurrentItem,AllItems);
    }
}
