using GalaSoft.MvvmLight;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCProject.ViewModel
{
    public class WelcomeViewModel : ViewModelBase
    {
        private string employeeType;
        public string EmployeeType { get => employeeType; set => Set(ref employeeType, value); }

        private string employeeMessage;
        public string EmployeeMessage { get => employeeMessage; set => Set(ref employeeMessage, value); }

        public WelcomeViewModel() 
        {
            EmployeeDetermination();
        }



        private void EmployeeDetermination()
        {
            int.TryParse(LoginViewModel.WelcomePin, out int pin);
            string message = "This is our library's management program,\nIn this program you can do various activities like,\nadding various items to the library,\n" +
                "Filter our stock through various categories and generate reports.";

            if (LogicUiManager.Manager.Login(pin, out string nameW) == 0)
            {
                employeeType = $"Welcome Worker, {nameW}";
                employeeMessage = message;
            }
        
            if (LogicUiManager.Manager.Login(pin ,out string nameM) == 1)
            {
                employeeType = $"Welcome Manager, {nameM}";
                employeeMessage = message + "\nOn top of all of that you will be able to \nget a detailed log about the actions done in your library\n" +
                    "and delete items by their id.";
            }
        }

    }
}
