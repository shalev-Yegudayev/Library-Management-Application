using System.Windows.Forms;

namespace Logic
{
    public interface INotify
    {
        void IsError(string message);   
        void ShowMessageBox(string message);
    }
}
