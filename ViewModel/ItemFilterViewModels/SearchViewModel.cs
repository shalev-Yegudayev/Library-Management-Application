using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace OOCProject.ViewModel
{
    public class SearchViewModel : ViewModelBase
    {
        private string idStr;
        public string IdStr { get => idStr; set => Set(ref idStr, value); }

        private string nameToCheck;
        public string NameToCheck { get => nameToCheck; set => Set(ref nameToCheck, value); }

        public RelayCommand CheckIdClick { get; set; }
        public RelayCommand CheckNameClick { get; set; }

        public SearchViewModel()
        {
            CheckIdClick = new RelayCommand(SearchById);
            CheckNameClick = new RelayCommand(SearchByName);
        }

        void SearchById()
        {
            LogicUiManager.Manager.CheckById(idStr);
            IdStr = "";
        }

        void SearchByName()
        {
            LogicUiManager.Manager.CheckByName(nameToCheck);
            NameToCheck = "";
        }
    }
}
