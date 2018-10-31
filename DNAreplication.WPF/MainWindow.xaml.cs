using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DNAreplication.WPF
{
    /// <summary>
    /// This is the main interaction with the application. 
    /// No new libraries except the integrated ones were used.
    /// </summary>
    public partial class MainWindow : Window
    {
        string allowedBases = "ATCG";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnComplement_Click(object sender, RoutedEventArgs e)
        {
            string inputSeq = RemoveUnwantedCharacters(txtInput.Text.ToUpper(), allowedBases);
            StringBuilder sb = new StringBuilder();
            foreach (char c in inputSeq)
            {
                switch(c)
                {
                    case 'A':
                        sb.Append('T');
                        break;
                    case 'T':
                        sb.Append('A');
                        break;
                    case 'C':
                        sb.Append('G');
                        break;
                    case 'G':
                        sb.Append('C');
                        break;
                    default:
                        break;
                }
            }
            string inputSeqDisp = (inputSeq.Length == 0) ? ">> input not valid" : inputSeq.ToUpper();
            string outputSeqDisp = (sb.Length == 0) ? ">> N/A" : sb.ToString();

            tblOutput.Text = $"{inputSeqDisp}\r\n{outputSeqDisp}";
            txtInput.Clear();
        }

        private string RemoveUnwantedCharacters(string input, IEnumerable<char> allowedCharacters)
        {
            var filtered = input //no need for .ToCharArray() => string is already IEnumerable<char>
                .Where(c => allowedCharacters.Contains(c)) //where any char in input is part of allowedCharacters
                .ToArray();

            return new string(filtered);
        }
    }
}
