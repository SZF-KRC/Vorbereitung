using System.Linq;
using System.Windows.Controls;

namespace Vorbereitung.TXT
{
    public class ManagerTXT
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

        private LoadDataTXT _loadDataTXT;
        private SaveDataTXT _saveDataTXT;

        public ManagerTXT(ListBox lstFirst, ListBox lstSecond, ListBox lstThird, ListBox lstFourth, TextBlock txtbFirst, TextBlock txtbSecond, TextBlock txtbThird, TextBlock txtbFourth, TextBox txtEntryData)
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

            _loadDataTXT = new LoadDataTXT();
            _saveDataTXT = new SaveDataTXT();
        }

        public void OpenFileAndPrint()
        {
            txtbFourth.Text = "TXT dokument:";
            lstFourth.Items.Clear();
            _loadDataTXT.OpenFile();
            if (_loadDataTXT.Data != null)
            {
                foreach (var item in _loadDataTXT.Data) { lstFourth.Items.Add(item); }

            }
            AddExtraInfoAboutTXT();
        }

        public void SaveDataTXT()
        {
            if (_saveDataTXT.NewData != null)
            {
                _saveDataTXT.SaveFile();

            }
        }

        public void AddTextFromList()
        {
            if (lstFourth.SelectedItem != null)
            {
                string selectedLine = lstFourth.SelectedValue.ToString();
                txtEntryData.Text = selectedLine;
            }

        }

        public void AddTextToList()
        {
            if (txtEntryData.Text.Length > 0)
            {
                int index = lstFourth.SelectedIndex;
                lstFourth.Items.RemoveAt(index);
                lstFourth.Items.Insert(index, txtEntryData.Text);
                _saveDataTXT.NewData = lstFourth.Items.OfType<string>().ToList(); ;
                txtEntryData.Text = string.Empty;
            }
        }

        private void AddExtraInfoAboutTXT()
        {
            txtbFirst.Text = "Total lines:";
            txtbSecond.Text = "Total words:";
            txtbThird.Text = "Top 5 words:";

            lstFirst.Items.Clear();
            lstSecond.Items.Clear();
            lstThird.Items.Clear();

            if (_loadDataTXT.Lines != null && _loadDataTXT.Words != null && _loadDataTXT.Top5 != null)
            {
                lstFirst.Items.Add(_loadDataTXT.Lines);
                lstSecond.Items.Add(_loadDataTXT.Words);

                foreach (var top5word in _loadDataTXT.Top5.OrderByDescending(w => w.Value).Take(5))
                {
                    lstThird.Items.Add($"{top5word.Key} -> {top5word.Value}");
                }
            }
        }

        public bool IsOpenTXT()
        {
            if(_loadDataTXT.Data != null)
                return true;
            return false;
        }
    }
}
