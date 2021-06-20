using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                sw.Write(textBox1.Text);
                sw.Close();
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files(*.*)|*.*| Text files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                textBox1.Text = sr.ReadToEnd();
                sr.Close();
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
                toolStripStatusLabel1.Text += $"Words: {wordCount}; ";
            }
            if (symbolsCountToolStripMenuItem.Checked)
            {
                toolStripStatusLabel1.Text += $"Symbols: {symbolCount}; ";
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files(*.*)|*.*| Text files (*.txt)|*.txt";
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
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
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
                    toolStripStatusLabel1.Text += $"Words: {wordCount}; ";
                }
            }
            else
            {
                symbolsCountToolStripMenuItem.Checked = true;
                if (wordsCountToolStripMenuItem.Checked)
                {
                    toolStripStatusLabel1.Text += $"Words: {wordCount}; ";
                }
                toolStripStatusLabel1.Text += $"Symbols: {symbolCount}; ";
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
                    toolStripStatusLabel1.Text += $"Symbols: {symbolCount}; ";
                }
            }
            else
            {
                toolStripStatusLabel1.Text += $"Words: {wordCount}; ";
                wordsCountToolStripMenuItem.Checked = true;
                if (symbolsCountToolStripMenuItem.Checked)
                {
                    toolStripStatusLabel1.Text += $"Symbols: {symbolCount}; ";
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
