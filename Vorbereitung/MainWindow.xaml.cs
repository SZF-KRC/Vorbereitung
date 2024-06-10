using System.Windows;
using Vorbereitung.ToDo;

namespace Vorbereitung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Manager manager;
        public MainWindow()
        {
            InitializeComponent();
            manager = new Manager(lstFirst,lstSecond,lstThird,lstFourth, txtbFirst, txtbSecond, txtbThird, txtbFourth, txtEntryData);
        }

        private void btnOpenTXT_Click(object sender, RoutedEventArgs e)
        {
            manager.OpenTXT();
        }

        private void btnSaveTXT_Click(object sender, RoutedEventArgs e)
        {
            manager.SaveTXT();
        }

        private void fourthList_selected(object sender, RoutedEventArgs e)
        {
            manager.AddTextFromListToTextBox();
        }

        private void btnAddText_Click(object sender, RoutedEventArgs e)
        {
            manager.AddTextFromTextBoxToListFourth();
        }

        private void listFirst_selected(object sender, RoutedEventArgs e)
        {
            manager.SelectedCustomer();
        }

        private void btnOpenCSV_Click(object sender, RoutedEventArgs e)
        {
            manager.OpenCSV();
        }
    }
}
