using System.Collections.ObjectModel;

namespace OOCProject.ViewModel
{
    public class ManagersLogViewModel
    {
        public static ObservableCollection<string> Log { get; set; }

        public ManagersLogViewModel() => Log = new ObservableCollection<string>();
    }
}
