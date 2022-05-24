using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOCProject.Views
{
    public partial class EditBookView : UserControl
    {
        public EditBookView() => InitializeComponent();

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) => e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        private void NumberValidationTextBoxDouble(object sender, TextCompositionEventArgs e) => e.Handled = new Regex("[^0-9.]+").IsMatch(e.Text);
        private void NumberValidationDatePicker(object sender, TextCompositionEventArgs e) => e.Handled = new Regex("[^ ]+").IsMatch(e.Text);

    }
}
