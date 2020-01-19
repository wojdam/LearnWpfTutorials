using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace LearnWpfTutorials
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Description text: {this.DescriptionText.Text}");

        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetWorkCentersCheckBoxes();
        }

        /// <summary>
        /// Just reset checkboxes connected to the work centers.
        /// </summary>
        private void ResetWorkCentersCheckBoxes()
        {
            this.WeldCheckBox.IsChecked = false;
            this.AssemblyCheckBox.IsChecked = false;
            this.LaserCheckBox.IsChecked = false;
            this.PurchaseCheckBox.IsChecked = false;
            this.PlasmaCheckBox.IsChecked = false;

            this.LatheCheckBox.IsChecked = false;
            this.DrillCheckBox.IsChecked = false;
            this.FoldCheckBox.IsChecked = false;
            this.RollCheckBox.IsChecked = false;
            this.SawCheckBox.IsChecked = false;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;

            this.LengthTextBox.Text += checkBox.Content;
        }

        /// <summary>
        /// Drop down finish drop down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinishDropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.NoteTextBox == null)
                return;

            var combo = sender as ComboBox;

            var item = combo.SelectedValue as ComboBoxItem;

            this.NoteTextBox.Text = (string) item.Content;
        }

        /// <summary>
        /// This event is triggered when the MainWindow is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.FinishDropdown_SelectionChanged(this.FinishDropdown, null);
        }

        /// <summary>
        /// Supplier name text changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplierNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.MassTextBox.Text = this.SupplierNameTextBox.Text;
        }
    }
}
