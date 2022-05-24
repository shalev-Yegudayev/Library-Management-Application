using GalaSoft.MvvmLight.Command;
using Logic.DataMembers;
using OOCProject.Classes;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OOCProject.ViewModel
{
    public class ReportViewModel : BaseItemProps
    {
        public static string CurrentItem { get; set; }

        private List<AbstractItem> reportList;


        private string discountPercentageStr;
        public string DiscountPercentageStr { get => discountPercentageStr; set => Set(ref discountPercentageStr, value); }

        public bool[] SelectedItem { get; set; } = new bool[3];

        public RelayCommand FilterClick { get; set; }

        public RelayCommand GetReportClick { get; set; }

        public static ObservableCollection<AbstractItem> FilteredItems { get; set; }



        public ReportViewModel()
        {
            FilteredItems = new ObservableCollection<AbstractItem>();

            FilterClick = new RelayCommand(FilterBtn);
            GetReportClick = new RelayCommand(GetReportBtn);
        }

        void FilterBtn()
        {
            FilteredItems.Clear();

            ConvertToInts(PriceBeforeDiscountStr, discountPercentageStr
               , out double priceBeforeDiscount, out int discountPercentage);

            reportList = LogicUiManager.Manager.Filter(SelectedItem, CreatorStr, priceBeforeDiscount, discountPercentage, SelectedDate);

            foreach (var item in reportList) FilteredItems.Add(item);
        }

        void ConvertToInts(string priceStr, string discountPercentageStr, out double price, out int discountPercentage)
        {
            double.TryParse(priceStr, out price);
            int.TryParse(discountPercentageStr, out discountPercentage);
        }

        void GetReportBtn() => LogicUiManager.Manager.CreateReport(reportList);
    }
}
