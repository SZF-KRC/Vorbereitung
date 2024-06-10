using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace Vorbereitung.TXT
{
    public class LoadDataTXT
    {
        private List<string> _data;
        private Dictionary<string, int> _top5;
        private int _lines;
        private int _words;

        public int Lines { get => _lines; }
        public int Words { get => _words; }
        public List<string> Data { get => _data; }
        public Dictionary<string,int> Top5 { get => _top5; }
        
        
        public void OpenFile() 
        {
            _data = new List<string>();
            _top5 = new Dictionary<string, int>();
            _lines = 0;
            _words = 0;
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.InitialDirectory = "C:\\Users\\16358\\Desktop\\SZF2\\C#\\Kompetenzcheck1\\Dokuments";
                openFile.Filter = "Text files (*.txt)|*.txt";
                if(openFile.ShowDialog() == true )
                {
                    using(StreamReader sr = new StreamReader(openFile.FileName))
                    {
                        string line;
                        while((line = sr.ReadLine()) != null)
                        {
                            string pattern = @"\b\w+\b";
                            MatchCollection matches = Regex.Matches(line, pattern);
                            _lines++;
                            _words += matches.Count;
                            _data.Add(line);

                            foreach(Match match in matches)
                            {
                                string word = match.Value.ToLower();
                                if (_top5.ContainsKey(word))
                                {
                                    _top5[word]++;
                                }
                                else
                                {
                                    _top5[word] = 1;
                                }
                            }
                        }
                    }
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }


    }
}
