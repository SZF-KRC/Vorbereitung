using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Vorbereitung.CSV.Model;

namespace Vorbereitung.CSV
{
    public class LoadDataCSV
    {
        private List<Customer> _customerList;
        private List<Phone> _phoneList;

        public List<Customer> CustomerList { get => _customerList;  }
        public List<Phone> PhoneList { get => _phoneList;}

        public void OpenFolder()
        {
            using(FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                folderBrowser.SelectedPath = "C:\\Users\\16358\\Desktop\\SZF2\\C#\\Kompetenzcheck1\\Dokuments";
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = folderBrowser.SelectedPath;
                    LoadData(folderPath);
                }
            }
        }

        private void LoadData(string folderPath)
        {
            try
            {
                _customerList = new List<Customer>();
                string customerPath = Path.Combine(folderPath, "customers.csv");
                using (StreamReader reader = new StreamReader(customerPath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        _customerList.Add(new Customer { Id = parts[0], Name = parts[1] });
                    }
                }

                _phoneList = new List<Phone>();
                string phonePath = Path.Combine(folderPath, "contacts.csv");
                using(StreamReader reader = new StreamReader(phonePath))
                {
                    string line;
                    while((line = reader.ReadLine()) != null) 
                    {
                        string[] parts = line.Split(',');
                        _phoneList.Add(new Phone {Id = parts[0], PhoneNumber = parts[1] });
                    }
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message); }
           
        } 
    }
}
