using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic.DataMembers;
using OOCProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logic.DataMembers.Record;

namespace OOCProject.ViewModel
{
    public class AddRecordViewModel : BaseItemProps
    {
        private string numOfSongsStr;
        public string NumOfSongsStr { get => numOfSongsStr; set => Set(ref numOfSongsStr, value); }

        private bool[] categorySelection = new bool[6];
        public bool[] CategorySelection { get => categorySelection; set => categorySelection = value; }

        public RelayCommand AddRecordClick { get; set; }

        public AddRecordViewModel()
        {
            AddRecordClick = new RelayCommand(AddRecordCLK);
        }

        void AddRecordCLK() => AddRecord(IdStr, NameStr, CreatorStr, PriceBeforeDiscountStr, numOfSongsStr, SelectedDate, categorySelection);

        void AddRecord(string isbnS, string name, string creator, string priceS, string numOfSongsS, DateTime date, bool[] selection)
        {
            if(!LogicUiManager.Manager.InputValidation(isbnS,name,creator,priceS,date,selection)) return;

            Categories genres = LogicUiManager.Manager.CreateCategoryEnum<Categories>(selection);

            ConvertToInts(isbnS, priceS, numOfSongsS, out int isbn, out double price, out int numOfSongs);

            Record record = new Record(name, creator, price, isbn, numOfSongs, date, genres);

            if (LogicUiManager.Manager.AddItem(record))
            {
                ManagersLogViewModel.Log.Add(record.ManagerLogMessage("Added"));
            }
            ResetFields();
        }
        void ConvertToInts(string recordIdS, string priceStr, string numOfSongsStr,
                   out int recordId, out double price, out int numOfSongs)
        {
            int.TryParse(recordIdS, out recordId);
            double.TryParse(priceStr, out price);
            int.TryParse(numOfSongsStr, out numOfSongs);
        }


        private void ResetFields()
        {
            IdStr = "";
            NameStr = "";
            CreatorStr = "";
            PriceBeforeDiscountStr = "";
            NumOfSongsStr = "";
            SelectedDate = DateTime.Now;
        }

    }
}
