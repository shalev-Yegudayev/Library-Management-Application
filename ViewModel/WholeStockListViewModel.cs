using DataStructures;
using GalaSoft.MvvmLight;
using Logic.DataMembers;
using System;
using System.Windows.Forms;

namespace OOCProject.ViewModel
{
    public class WholeStockListViewModel : ViewModelBase
    {
       internal static EditRecordWindow RecordWindow = new EditRecordWindow();
       internal static EditBookWindow BookWindow = new EditBookWindow();


        static public Action<string, System.Windows.Controls.ListView> ItemSelect { get; set; }

        private static string currentItem;
        public static string CurrentItem { get => currentItem; set => currentItem = value; }

        public ObservableDictionary<int, AbstractItem> AllItems { get; set; }

        public WholeStockListViewModel()
        {

            AllItems = LogicUiManager.Manager.ItemsInStock;
            ItemSelect = new Action<string, System.Windows.Controls.ListView>(ListView_SelectionChanged);

        }
        private void ListView_SelectionChanged(string currentItem,System.Windows.Controls.ListView listView)
        {
            try
            {
                if (currentItem != null)
                {
                    string keyStr = currentItem.Substring(currentItem.IndexOf(':') + 1, currentItem.IndexOf('.') - currentItem.IndexOf(':') - 1);
                    int.TryParse(keyStr, out int key);
                    AbstractItem item = LogicUiManager.Manager.ItemsInStock[key];

                    DialogResult dialogResult = ItemDetailsMessageBox(item);

                    Result(dialogResult, item);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static DialogResult ItemDetailsMessageBox(AbstractItem item)
        {
            DialogResult dialogResult = default;
            int.TryParse(LoginViewModel.WelcomePin, out int pin);
            if (LogicUiManager.Manager.Login(pin, out _) == 1)
            {
                MessageBoxManager.Yes = "Edit";
                MessageBoxManager.No = "Delete";
                MessageBoxManager.Cancel = "Ok";
                MessageBoxManager.Register();
                dialogResult = MessageBox.Show(item.ShowItemDetails(), "Item Details", MessageBoxButtons.YesNoCancel);
                MessageBoxManager.Unregister();
            }
            else if (LogicUiManager.Manager.Login(pin, out _) == 0)
            {
                MessageBoxManager.OK = "Edit";
                MessageBoxManager.Register();
                dialogResult = MessageBox.Show(item.ShowItemDetails(), "Item Details", MessageBoxButtons.OKCancel);
                MessageBoxManager.Unregister();

            }
            return dialogResult;
        }

        private void Result(DialogResult dialogResult, AbstractItem abstractItem)
        {

            if (dialogResult == DialogResult.Yes || dialogResult == DialogResult.OK)
            {
                if (abstractItem.GetType() == typeof(Book)) BookWindow.Show();

                else if (abstractItem.GetType() == typeof(Record)) RecordWindow.Show();

                ManagersLogViewModel.Log.Add(abstractItem.ManagerLogMessage("Edited"));
            }
            else if (dialogResult == DialogResult.No)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to delete the selected item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (res == DialogResult.Yes)
                {
                    if (ReportViewModel.FilteredItems.Contains(abstractItem)) ReportViewModel.FilteredItems.Remove(abstractItem);

                    if (LogicUiManager.Manager.DeleteItem(abstractItem))
                    {
                        ManagersLogViewModel.Log.Add(abstractItem.ManagerLogMessage("Deleted"));
                        MessageBox.Show("Item Deleted Successfuly");
                    }
                }
            }
        }

    }
}
