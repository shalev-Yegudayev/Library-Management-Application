using GalaSoft.MvvmLight;
using System;

namespace OOCProject.Classes
{
    public abstract class BaseItemProps : ViewModelBase
    {
        private string isbnStr;
        public string IdStr { get => isbnStr; set => Set(ref isbnStr, value); }

        private string nameStr;
        public string NameStr { get => nameStr; set => Set(ref nameStr, value); }

        private string authorStr;
        public string CreatorStr { get => authorStr; set => Set(ref authorStr, value); }

        private string priceBeforeDiscountStr;
        public string PriceBeforeDiscountStr { get => priceBeforeDiscountStr; set => Set(ref priceBeforeDiscountStr, value); }

        private DateTime selectedDate = DateTime.Now;
        public DateTime SelectedDate { get => selectedDate; set => Set(ref selectedDate, value); }
    }
}
