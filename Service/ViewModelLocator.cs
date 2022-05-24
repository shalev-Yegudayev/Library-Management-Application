using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using Logic;
using OOCProject.ViewModel.ItemManipulationViewModels;

namespace OOCProject.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<SearchViewModel>();
            SimpleIoc.Default.Register<AddBookViewModel>();
            SimpleIoc.Default.Register<AddRecordViewModel>();
            SimpleIoc.Default.Register<ReportViewModel>();
            SimpleIoc.Default.Register<ManagersLogViewModel>();
            SimpleIoc.Default.Register<WelcomeViewModel>();
            SimpleIoc.Default.Register<AddEmployeeViewModel>();
            SimpleIoc.Default.Register<EditBookViewModel>();
            SimpleIoc.Default.Register<EditRecordViewModel>();
            SimpleIoc.Default.Register<WholeStockListViewModel>();


            SimpleIoc.Default.Register<INotify>(() => new Notifyer());
            SimpleIoc.Default.Register<Manager>();
            SimpleIoc.Default.Register<LogicUiManager>();
        }

        public LoginViewModel           Login       =>    ServiceLocator.Current.GetInstance<LoginViewModel>();
        public SearchViewModel          Worker      =>    ServiceLocator.Current.GetInstance<SearchViewModel>();
        public AddBookViewModel         AddBook     =>    ServiceLocator.Current.GetInstance<AddBookViewModel>();
        public AddRecordViewModel       AddRecord   =>    ServiceLocator.Current.GetInstance<AddRecordViewModel>();
        public ReportViewModel          Report      =>    ServiceLocator.Current.GetInstance<ReportViewModel>();
        public ManagersLogViewModel     ManagersLog =>    ServiceLocator.Current.GetInstance<ManagersLogViewModel>();
        public WelcomeViewModel         Welcome     =>    ServiceLocator.Current.GetInstance<WelcomeViewModel>();
        public AddEmployeeViewModel     AddEmployee =>    ServiceLocator.Current.GetInstance<AddEmployeeViewModel>();
        public EditBookViewModel        EditBook    =>    ServiceLocator.Current.GetInstance<EditBookViewModel>();
        public EditRecordViewModel      EditRecord  =>    ServiceLocator.Current.GetInstance<EditRecordViewModel>();
        public WholeStockListViewModel  WholeStock  =>    ServiceLocator.Current.GetInstance<WholeStockListViewModel>();
    }
}