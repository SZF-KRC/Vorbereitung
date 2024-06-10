using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Vorbereitung.TXT
{
    public class SaveDataTXT
    {
        private List<string> newData;
        public List<string> NewData { set { newData = value; } get => newData; }

        public void SaveFile()
        {
            try
            {
                if (newData != null)
                {
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.InitialDirectory = "C:\\Users\\16358\\Desktop\\SZF2\\C#\\Kompetenzcheck1\\Dokuments";
                    saveFile.Filter = "Text files (*.txt)|*.txt";
                    if (saveFile.ShowDialog() == true)
                    {
                        using (StreamWriter streamWriter = new StreamWriter(saveFile.FileName))
                        {
                            foreach (string line in newData) { streamWriter.WriteLine(line); }
                        }
                    }
                    newData.Clear();
                }else { MessageBox.Show("You have to write new text or rewrite exist", "Warning message"); }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }
    }
}
