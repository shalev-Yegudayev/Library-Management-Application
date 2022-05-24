using GalaSoft.MvvmLight.Command;
using Logic.DataMembers;
using OOCProject.ViewModel.ItemManipulationViewModels;
using System;
using System.Windows;
using System.Windows.Data;
using static Logic.DataMembers.Record;

namespace OOCProject.ViewModel
{
    public class EditRecordViewModel : AddRecordViewModel
    {
        public RelayCommand EditRecordClick { get; set; }
        public EditRecordViewModel()
        {
            EditRecordClick = new RelayCommand(EditBookBtn);
        }
        private void EditBookBtn()
        {
            Record record = LogicUiManager.Manager.ItemsInStock[GetID()] as Record;

            LogicUiManager.Manager.EditRecord(record, NameStr, CreatorStr, PriceBeforeDiscountStr, SelectedDate, NumOfSongsStr, CategorySelection);

            EditBookViewModel.RefreshLists(record);

            WholeStockListViewModel.RecordWindow.Close();
        }

        private int GetID()
        {
            string idS = "";
            if (WholeStockListViewModel.CurrentItem != null) idS = WholeStockListViewModel.CurrentItem;

            else if (ReportViewModel.CurrentItem != null) idS = ReportViewModel.CurrentItem;

            idS = idS.Substring(idS.IndexOf(':') + 1, idS.IndexOf(' ') - idS.IndexOf(':') - 1);

            int.TryParse(idS, out int id);
            return id;
        }


    }
}
