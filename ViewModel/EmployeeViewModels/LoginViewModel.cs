using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic;
using System.Windows;

namespace OOCProject.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string logintxt;
        public string LoginTxt { get => logintxt; set => Set(ref logintxt, value); }

        public static string WelcomePin { get; set; } 

        public RelayCommand LoginClick { get; set; }
        public RelayCommand NewEmpClick { get; set; }

        public LoginViewModel(INotify notify)
        {
            LogicUiManager.Manager = new Manager(notify);
            LoginClick = new RelayCommand(LoginClk);
            NewEmpClick = new RelayCommand(NewEmployeeClk);   
        }


        void NewEmployeeClk()
        {
            CreateNewEmployee createNewEmployee = new CreateNewEmployee();
            createNewEmployee.Show();
        }

        void LoginClk()
        {
            int.TryParse(logintxt, out int pinToCheck);
            int windowSelector = LogicUiManager.Manager.Login(pinToCheck, out _);
            WelcomePin = logintxt;

            if (windowSelector == 0)
            {
                MainWindow mainWindow = new MainWindow();

                mainWindow.tabControl.Items.Remove(mainWindow.managersLog);

                mainWindow.Show();
                Application.Current.MainWindow.Close();
            }
            else if (windowSelector == 1)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Application.Current.MainWindow.Close();
            }
        }

    }
}
