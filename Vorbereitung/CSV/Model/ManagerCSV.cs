using System.Linq;
using System.Windows.Controls;

namespace Vorbereitung.CSV.Model
{
    public class ManagerCSV
    {
        private LoadDataCSV loadData;

        private ListBox lstFirst;
        private ListBox lstSecond;
        private ListBox lstThird;
        private ListBox lstFourth;

        private TextBlock txtbFirst;
        private TextBlock txtbSecond;
        private TextBlock txtbThird;
        private TextBlock txtbFourth;

        private TextBox txtEntryData;

        public ManagerCSV(ListBox lstFirst, ListBox lstSecond, ListBox lstThird, ListBox lstFourth, TextBlock txtbFirst, TextBlock txtbSecond, TextBlock txtbThird, TextBlock txtbFourth, TextBox txtEntryData)
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
            loadData = new LoadDataCSV();
        }

        public void OpenFolderCSV()
        {
            loadData.OpenFolder();
            AddCustomerToList();
        }

        private void AddCustomerToList()
        {
            txtbFirst.Text = "Customers:";
            txtbSecond.Text = "Phone numbers:";
            lstFirst.Items.Clear();
            foreach( Customer customer in loadData.CustomerList )
            {
                lstFirst.Items.Add( customer.Name );
            }
            
        }

        public void AddPhoneToList()
        {
            lstSecond.Items.Clear();
            if(lstFirst.SelectedItem != null)
            {
                string selectedCustomerName = lstFirst.SelectedItem.ToString();
                Customer customer = loadData.CustomerList.FirstOrDefault(c => c.Name == selectedCustomerName);
                if( customer != null )
                {
                    Phone phoneNumbers = loadData.PhoneList.FirstOrDefault(p => p.Id == customer.Id);
                    lstSecond.Items.Add( phoneNumbers.PhoneNumber );
                }
            }
        }

        public bool IsOpentCSV()
        {
            if(loadData.CustomerList != null)
                return true;
            return false;
        }
    }
}
