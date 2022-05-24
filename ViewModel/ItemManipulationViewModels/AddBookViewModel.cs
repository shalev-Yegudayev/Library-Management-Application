using GalaSoft.MvvmLight.Command;
using Logic.DataMembers;
using OOCProject.Classes;
using System;
using static Logic.DataMembers.Book;

namespace OOCProject.ViewModel
{
    public class AddBookViewModel : BaseItemProps
    {
        private bool[] genreSelection = new bool[9];
        public bool[] GenreSelection { get => genreSelection; set => Set(ref genreSelection, value); }

        public RelayCommand AddBookClick { get; set; }

        public AddBookViewModel() => AddBookClick = new RelayCommand(AddBookCLK);

        void AddBookCLK() => AddBook(IdStr, NameStr, CreatorStr, PriceBeforeDiscountStr, SelectedDate, genreSelection);

        void AddBook(string isbnS, string name, string author, string priceS, DateTime date, bool[] selection)
        {
            if(!LogicUiManager.Manager.InputValidation(isbnS,name,author,priceS,date,selection)) return;

            Genres genres = LogicUiManager.Manager.CreateCategoryEnum<Genres>(selection);

            int.TryParse(isbnS, out int isbn);
            double.TryParse(priceS, out double price);

            Book book = new Book(name, author, price, isbn, date, genres);

            if (LogicUiManager.Manager.AddItem(book))
            {
                ManagersLogViewModel.Log.Add(book.ManagerLogMessage("Added"));
            }

            ResetFields();
        }

        private void ResetFields()
        {
            IdStr = "";
            NameStr = "";
            CreatorStr = "";
            PriceBeforeDiscountStr = "";
            SelectedDate = DateTime.Now;

            for (int i = 0; i < GenreSelection.Length; i++)
            {
                if (GenreSelection[i]) GenreSelection[i] = false;
            }
        }
    }
}
