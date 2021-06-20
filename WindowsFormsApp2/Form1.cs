using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        string localGlobal = "en";

        public Form1()
        {
            InitializeComponent();
            SetLocalization(localGlobal);
        }

        string GetLocal(string local)
        {
            return loc.ResourceManager.GetString(local);
        }

        void SetLocalization(string local)
        {
            newToolStripMenuItem.Text = GetLocal(local + "_new");
            saveToolStripMenuItem.Text = GetLocal(local + "_save");
            openToolStripMenuItem.Text = GetLocal(local + "_open");
            fileToolStripMenuItem.Text = GetLocal(local + "_file");
            exitToolStripMenuItem.Text = GetLocal(local + "_exit");
            infoToolStripMenuItem.Text = GetLocal(local + "_info");
            wordsCountToolStripMenuItem.Text = GetLocal(local + "_wordsCount");
            symbolsCountToolStripMenuItem.Text = GetLocal(local + "_symbolsCount");
            SaveButton.Text = saveToolStripMenuItem.Text = GetLocal(local + "_save");
            OpenButton.Text = saveToolStripMenuItem.Text = GetLocal(local + "_open");

            char[] delimiters = new char[] { ' ', '\r', '\n' };
            int wordCount = textBox1.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length
                , symbolCount = textBox1.Text.Length;
            if (wordsCountToolStripMenuItem.Checked)
            {
                if (symbolsCountToolStripMenuItem.Checked)
                {
                    toolStripStatusLabel1.Text = $"{GetLocal(local + "_words")}: {wordCount}; {GetLocal(local + "_symbols")}: {symbolCount}";
                }
                else
                {
                    toolStripStatusLabel1.Text = $"{GetLocal(local + "_words")}: {wordCount};";
                }
            }
            else
            {
                if (symbolsCountToolStripMenuItem.Checked)
                {
                    toolStripStatusLabel1.Text = $"{GetLocal(local + "_symbols")}: {symbolCount};";
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = $"{GetLocal(localGlobal + "_textFiles")} (*.txt)|*.txt";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                sw.Write(textBox1.Text);
                sw.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            int wordCount = textBox1.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length
                , symbolCount = textBox1.Text.Length;
            toolStripStatusLabel1.Text = String.Empty;
            if (wordsCountToolStripMenuItem.Checked)
            {
                toolStripStatusLabel1.Text += $"{GetLocal(localGlobal + "_words")}: {wordCount}; ";
            }
            if (symbolsCountToolStripMenuItem.Checked)
            {
                toolStripStatusLabel1.Text += $"{GetLocal(localGlobal + "_symbols")}: {symbolCount}; ";
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = $"{GetLocal(localGlobal + "_allFiles")}(*.*)|*.*| {GetLocal(localGlobal + "_textFiles")} (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                textBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = $"{GetLocal(localGlobal + "_textFiles")} (*.txt)|*.txt";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                sw.Write(textBox1.Text);
                sw.Close();
            }
        }

        private void symbolsCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            int wordCount = textBox1.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length
                , symbolCount = textBox1.Text.Length;
            toolStripStatusLabel1.Text = String.Empty;
            if (symbolsCountToolStripMenuItem.Checked)
            {
                symbolsCountToolStripMenuItem.Checked = false;
                if (wordsCountToolStripMenuItem.Checked)
                {
                    toolStripStatusLabel1.Text += $"{GetLocal(localGlobal + "_words")}: {wordCount}; ";
                }
            }
            else
            {
                symbolsCountToolStripMenuItem.Checked = true;
                if (wordsCountToolStripMenuItem.Checked)
                {
                    toolStripStatusLabel1.Text += $"{GetLocal(localGlobal + "_words")}: {wordCount}; ";
                }
                toolStripStatusLabel1.Text += $"{GetLocal(localGlobal + "_symbols")}: {symbolCount}; ";
            }
        }

        private void wordsCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            int wordCount = textBox1.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length
                , symbolCount = textBox1.Text.Length;
            toolStripStatusLabel1.Text = String.Empty;
            if (wordsCountToolStripMenuItem.Checked)
            {
                wordsCountToolStripMenuItem.Checked = false;
                if (symbolsCountToolStripMenuItem.Checked)
                {
                    toolStripStatusLabel1.Text += $"{GetLocal(localGlobal + "_symbols")}: {symbolCount}; ";
                }
            }
            else
            {
                toolStripStatusLabel1.Text += $"{GetLocal(localGlobal + "_words")}: {wordCount}; ";
                wordsCountToolStripMenuItem.Checked = true;
                if (symbolsCountToolStripMenuItem.Checked)
                {
                    toolStripStatusLabel1.Text += $"{GetLocal(localGlobal + "_symbols")}: {symbolCount}; ";
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = $"{GetLocal(localGlobal + "_allFiles")}: (*.*)|*.*| {GetLocal(localGlobal + "_textFiles")} (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                textBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void buttonLocalRU_Click(object sender, EventArgs e)
        {
            SetLocalization("ru");
            localGlobal = "ru";
        }

        private void buttonLocalEN_Click(object sender, EventArgs e)
        {
            SetLocalization("en");
            localGlobal = "en";
        }
    }
}
