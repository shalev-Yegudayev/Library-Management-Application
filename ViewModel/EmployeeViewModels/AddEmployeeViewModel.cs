using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace OOCProject.ViewModel
{
    public class AddEmployeeViewModel : ViewModelBase
    {
        private string firstName;
        public string FirstName { get => firstName; set => Set(ref firstName, value); }
      
        private string lastName;
        public string LastName { get => lastName; set => Set(ref lastName, value); }

        public bool[] SelectRank { get; set; } = new bool[2];

        public RelayCommand AddEmployeeClick { get; set; }

        public AddEmployeeViewModel() => AddEmployeeClick = new RelayCommand(AddEmployeeBtn);

        private void AddEmployeeBtn()
        {
            LogicUiManager.Manager.AddEmployee(firstName, lastName, SelectRank);
            FirstName = "";
            LastName = "";
        }
    }
}
