using DataStructures;
using Logic.DataMembers;
using System;
using System.Collections.Generic;

namespace Logic.Managers
{
    internal class DeleteItemManager
    {
        internal static bool DeleteItem(ObservableDictionary<int, AbstractItem> itemsInStock,  List<string> ManagerLog, AbstractItem item)
        {
            try
            {
                itemsInStock.Remove(item.Id);
                ManagerLog.Add(item.ManagerLogMessage("Deleted"));
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
