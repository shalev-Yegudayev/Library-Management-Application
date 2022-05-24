using DataStructures;
using Logic.DataMembers;
using System.Collections.Generic;

namespace Logic
{
    internal class AddItemManager
    {
        internal static bool AddItem(ObservableDictionary<int, AbstractItem> itemsInStock, INotify notify, List<string> ManagerLog, AbstractItem item)
        {
            try
            {
                itemsInStock.Add(item.Id, item);

                ManagerLog.Add(item.ManagerLogMessage("Added"));
            }
            catch
            {
                notify.IsError("Item is already exist in the stock");
                return false;
            }
            return true;

        }
    }
}
