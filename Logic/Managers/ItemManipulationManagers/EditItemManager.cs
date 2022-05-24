using Logic.DataMembers;
using System;
using static Logic.DataMembers.Book;
using static Logic.DataMembers.Record;

namespace Logic.Managers
{
    internal class EditItemManager
    {
        internal static void EditBook(Book book,string nameS, string creatorS,string priceBeforeDiscountS, DateTime selectedDate, bool [] genreSelection)
        {
            EditAbstractItem(book, nameS, creatorS, priceBeforeDiscountS, selectedDate);

            if (InputValidationManager.CheckCategories(genreSelection))
            {
                book.genres = CreateEnumManager.CreateCategoryEnum<Genres>(genreSelection);
            }
        }


        internal static void EditRecord(Record record,string nameS, string creatorS,string priceBeforeDiscountS, DateTime selectedDate,string numOfSongsS ,bool [] categorySelection)
        {
            EditAbstractItem(record, nameS, creatorS, priceBeforeDiscountS, selectedDate);

            if (selectedDate < DateTime.Now) record.PublishDate = selectedDate;

            if (numOfSongsS != default)
            {
                int.TryParse(numOfSongsS, out int numOfSongs);
                record.NumOfSongs = numOfSongs;
            }

            if (InputValidationManager.CheckCategories(categorySelection))
            {
                record.categories = CreateEnumManager.CreateCategoryEnum<Categories>(categorySelection);
            }


        }
        private static void EditAbstractItem(AbstractItem item, string nameS, string creatorS, string priceBeforeDiscountS, DateTime selectedDate)
        {
            if (nameS != null && nameS != "") item.Name = nameS;

            if (creatorS != null && creatorS != "") item.Creator = creatorS;

            if (priceBeforeDiscountS != default)
            {
                int.TryParse(priceBeforeDiscountS, out int priceBeforeDiscount);
                item.Price = priceBeforeDiscount;
            }

            if (selectedDate < DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0))) item.PublishDate = selectedDate;

            item.ManagerLogMessage("Edited");
        }
    }
}
