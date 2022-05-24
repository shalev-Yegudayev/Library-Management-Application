using Logic;

namespace OOCProject
{
    public class Notifyer : INotify
    {
        public void IsError(string message) => System.Windows.MessageBox.Show(message);

        public void ShowMessageBox(string message) => System.Windows.MessageBox.Show(message);
    }
}
