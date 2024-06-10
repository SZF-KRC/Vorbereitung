using System.Windows.Controls;
using Vorbereitung.CSV.Model;
using Vorbereitung.TXT;

namespace Vorbereitung.ToDo
{
    public class Manager
    {
        private ListBox lstFirst;
        private ListBox lstSecond;
        private ListBox lstThird;
        private ListBox lstFourth;

        private TextBlock txtbFirst;
        private TextBlock txtbSecond;
        private TextBlock txtbThird;
        private TextBlock txtbFourth;

        private TextBox txtEntryData;

        private ManagerCSV _managerCSV;
        private ManagerTXT _managerTXT;

        public Manager(ListBox lstFirst, ListBox lstSecond, ListBox lstThird, ListBox lstFourth, TextBlock txtbFirst, TextBlock txtbSecond, TextBlock txtbThird, TextBlock txtbFourth, TextBox txtEntryData)
        {
            this.lstFirst = lstFirst;
            this.lstSecond = lstSecond;
            this.lstThird = lstThird;
            this.lstFourth = lstFourth;

            this.txtbFirst = txtbFirst;
            this.txtbSecond = txtbSecond;
            this.txtbThird = txtbThird;
            this.txtbFourth = txtbFourth;

            this.txtEntryData = txtEntryData;

            _managerCSV = new ManagerCSV(lstFirst,lstSecond,lstThird,lstFourth,txtbFirst,txtbSecond,txtbThird,txtbFourth,txtEntryData);
            _managerTXT = new ManagerTXT(lstFirst, lstSecond, lstThird, lstFourth, txtbFirst, txtbSecond, txtbThird, txtbFourth, txtEntryData);
        }

        public void OpenCSV()
        {
            CleanWindow();
            _managerCSV.OpenFolderCSV();
        }

        public void SelectedCustomer()
        {
            _managerCSV.AddPhoneToList();
        }

        public void OpenTXT()
        {
            CleanWindow();
            _managerTXT.OpenFileAndPrint();
        }

        public void SaveTXT()
        {
            _managerTXT.SaveDataTXT();
        }

        public void AddTextFromListToTextBox()
        {
            if(_managerTXT.IsOpenTXT())
            {
                _managerTXT.AddTextFromList();
            }else if(_managerCSV.IsOpentCSV())
            {

            }
        }

        public void AddTextFromTextBoxToListFourth()
        {
            if (_managerTXT.IsOpenTXT())
            {
                _managerTXT.AddTextToList();
            }
            else if (_managerCSV.IsOpentCSV())
            {

            }
        }

        private void CleanWindow()
        {
            lstFirst.Items.Clear();
            lstSecond.Items.Clear();
            lstThird.Items.Clear();
            lstFourth.Items.Clear();
            txtbFirst.Text = string.Empty;
            txtbSecond.Text = string.Empty;
            txtbThird.Text = string.Empty;
            txtbFourth.Text = string.Empty;
            txtEntryData.Text = string.Empty;
        }

    }
}
