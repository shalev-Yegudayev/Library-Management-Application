using DataStructures;
using Logic.DataMembers;
using System.Text;

namespace Logic.Managers
{
    internal class CheckSingleItemManager
    {
        internal static bool CheckById(ObservableDictionary<int, AbstractItem> itemsInStock, INotify notify, string idToCheckS)
        {
            int.TryParse(idToCheckS, out int idToCheck);
            foreach (var item in itemsInStock)
            {
                if (item.Value.Id == idToCheck)
                {
                    notify.ShowMessageBox(item.Value.ShowItemDetails());
                    return true;
                }
            }
            notify.IsError("No item with the requested id is available in stock");
            return false;
        }

        internal static bool CheckByName(ObservableDictionary<int, AbstractItem> itemsInStock, INotify notify, string nameToCheck)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in itemsInStock)
            {
                if (item.Value.Name == nameToCheck) sb.AppendLine($"{item.Value.ShowItemDetails()}\n\n");
            }
            if (sb.Length > 0)
            {
                notify.ShowMessageBox(sb.ToString());
                return true;
            }
            notify.IsError("No item with the requested name is available in stock");
            return false;
        }

    }
}
