using GalaSoft.MvvmLight.Command;
using Logic.DataMembers;
using System.Windows.Data;

namespace OOCProject.ViewModel.ItemManipulationViewModels
{
    public class EditBookViewModel : AddBookViewModel
    {
        public RelayCommand EditBookClick { get; set; }
        public EditBookViewModel()
        {
            EditBookClick = new RelayCommand(EditBookBtn);
        }
        private void EditBookBtn()
        {
            string s = WholeStockListViewModel.CurrentItem;
            Book book = LogicUiManager.Manager.ItemsInStock[GetID()] as Book;

            LogicUiManager.Manager.EditBook(book, NameStr, CreatorStr, PriceBeforeDiscountStr, SelectedDate, GenreSelection);

            RefreshLists(book);

            WholeStockListViewModel.BookWindow.Close();
        }

        internal static void RefreshLists(AbstractItem item)
        {
            CollectionViewSource.GetDefaultView(ReportViewModel.FilteredItems).Refresh();
            LogicUiManager.Manager.DeleteItem(item);
            LogicUiManager.Manager.AddItem(item);

        }

        private int GetID()
        {
            string idS = "";
            if (WholeStockListViewModel.CurrentItem != null) idS = WholeStockListViewModel.CurrentItem;

            else if (ReportViewModel.CurrentItem != null) idS = ReportViewModel.CurrentItem;

            idS = idS.Substring(idS.IndexOf(':') + 1, idS.IndexOf('.') - idS.IndexOf(':') - 1);

            int.TryParse(idS, out int id);
            return id;
        }
    }
}
