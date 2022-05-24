using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace OOCProject.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView() => InitializeComponent();

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) => e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e) => Process.Start(e.Uri.AbsoluteUri);
    }
}
