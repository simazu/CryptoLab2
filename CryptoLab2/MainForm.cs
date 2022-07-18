using CryptoLab2.Lib;
using System;
using System.IO;
using System.Windows.Forms;

namespace CryptoLab2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void getButton_Click(object sender, EventArgs e)
        {
            sequenceRichTextBox.Clear();
            Registers register;
            if (comboBox1.SelectedItem == null)
                comboBox1.SelectedItem = "Random";
            if (comboBox1.SelectedItem.ToString() != "Random")
            {
                using OpenFileDialog fileDialog = new ();
                fileDialog.Title = "Key";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string startState = File.ReadAllText(fileDialog.FileName);
                    register = new (startState);
                }
                else
                    return;
            }
            else
                register = new Registers(93);
            decimal sequenceLength = sequenceLengthNumericUpDown.Value;
            if (sequenceLength == Math.Truncate(sequenceLength))
                sequenceRichTextBox.Text = register.GetKey((int)sequenceLength);
            else
                MessageBox.Show("Incorrect length error");
        }
        private void encryptButton_Click(object sender, EventArgs e)
        {
            string fileName = "";
            using OpenFileDialog fileDialog = new();
            fileDialog.Title = "File to encrypt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
                fileName = fileDialog.FileName;
            else
                return;
            

            string sequence = File.ReadAllText("key.txt");
            Encrypter.Encrypt(fileName, sequence);

            testsOutputRichTextBox.Clear();
            string path = fileName[..fileName.LastIndexOf('\\')] + "\\encrypted.txt";
            testsOutputRichTextBox.Text += $"encrypted to {path}\n";

            testsOutputRichTextBox.Text += "\ntesting text.txt\n\n\n";
            string sourceFile = Converter.BitArrrayToString(Converter.FileToBitArray(fileName));
            Test(sourceFile);
            testsOutputRichTextBox.Text += "\ntesting encrypted.txt\n\n\n";
            sourceFile = Converter.BitArrrayToString(Converter.FileToBitArray("encrypted.txt"));
            Test(sourceFile);

        }
        private void decryptButton_Click(object sender, EventArgs e)
        {
            string fileName = "";
            using OpenFileDialog fileDialog = new();
            fileDialog.Title = "File to decrypt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
                fileName = fileDialog.FileName;
            else
                return;
            
            string sequence = File.ReadAllText("key.txt");
            Encrypter.Decrypt(fileName, sequence);

            testsOutputRichTextBox.Clear();
            string path = fileName[..fileName.LastIndexOf('\\')] + "\\decrypted.txt";
            testsOutputRichTextBox.Text += $"decrypted to {path}\n\n\n";
        }
        private void testsButton_Click(object sender, EventArgs e)
        {
            testsOutputRichTextBox.Clear();
            testsOutputRichTextBox.Text += "testing sequence\n\n";
            string sequence = sequenceRichTextBox.Text;
            if (sequence.Length == 0)
            {
                testsOutputRichTextBox.Text += "Generated new sequence for 2000 bits\n\n";
                Registers register = new (93);
                sequence = register.GetKey(2000);
                sequenceRichTextBox.Text = sequence;
            }
            Test(sequence);
        }

        private void Test(string sequence)
        {
            testsOutputRichTextBox.Text += $"Serial test:\n";
            for (int i = 2; i < 5; i++)
            {
                (double, double, double) serialTestResult = MSequenceTester.SerialTest(sequence, i);
                testsOutputRichTextBox.Text += $"serial length = {i}\n{serialTestResult.Item3} - AlphaMax: {serialTestResult.Item1}, AlphaMin: {serialTestResult.Item2}" +
                    $", test {((serialTestResult.Item3 <= serialTestResult.Item1 && serialTestResult.Item3 >= serialTestResult.Item2)?"passed":"failed")}\n";
            }
            testsOutputRichTextBox.Text += "\n";

            (double, double, double) pokerTestResult = MSequenceTester.PokerTest(sequence);
            testsOutputRichTextBox.Text += $"Poker test: {pokerTestResult.Item3} - AlphaMax: {pokerTestResult.Item1}, AlphaMin: {pokerTestResult.Item2}" +
                    $", test {((pokerTestResult.Item3 <= pokerTestResult.Item1 && pokerTestResult.Item3 >= pokerTestResult.Item2) ? "passed" : "failed")}\n";
            testsOutputRichTextBox.Text += "\n";

            testsOutputRichTextBox.Text += $"Correlation Test:\n";
            foreach (int i in new[] { 1, 2, 8, 9 })
            {
                (double, double) correlationTestResult = MSequenceTester.CorrelationTest(sequence, i);
                testsOutputRichTextBox.Text += $"k = {i}, R = {correlationTestResult.Item1}, Rref = {correlationTestResult.Item2}" +
                    $", test {(correlationTestResult.Item1<correlationTestResult.Item2?"passed":"failed")}\n";
            }
        }
    }
}
