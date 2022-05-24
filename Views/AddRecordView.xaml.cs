using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace OOCProject.Views
{
    public partial class AddRecordView : UserControl
    {
        public AddRecordView() => InitializeComponent();

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) => e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        private void NumberValidationTextBoxDouble(object sender, TextCompositionEventArgs e) => e.Handled = new Regex("[^0-9.]+").IsMatch(e.Text);
        private void NumberValidationDatePicker(object sender, TextCompositionEventArgs e) => e.Handled = new Regex("[^ ]+").IsMatch(e.Text);
    }
}
