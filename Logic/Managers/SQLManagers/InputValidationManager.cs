using System;

namespace Logic.Managers
{
    internal class InputValidationManager
    {
        internal static bool InputValidation(INotify notify, string isbnS, string name, string creator, string priceS, DateTime publishDate, bool[] selection)
        {
            if (isbnS == null || isbnS == "") notify.IsError("Please Insert ID");

            else if (name == null || name == "") notify.IsError("Please Insert Item Name");

            else if (creator == null || creator == "") notify.IsError("Please Insert Creators Name");

            else if (priceS == null || priceS == "") notify.IsError("Please Insert Price");

            else if (publishDate == DateTime.Now.AddDays(1)) notify.IsError("Please Insert Publish Date");

            else if (!CheckCategories(selection)) notify.IsError("pleade Insert Categories");

            else return true;

            return false;
        }

        internal static bool CheckCategories(bool[] vs)
        {
            foreach (bool isbn in vs)
            {
                if (isbn == true) return true;
            }
            return false;
        }

    }
}
