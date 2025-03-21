using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private PrintDocument printDocument;
        public Form1()
        {
            InitializeComponent();
            ToolStrip toolStrip;
            StatusStrip statusStrip;

            printDocument = new PrintDocument(); //for Printing
            txtEditor.TextChanged += TxtEditor_TextChanged; //for counting words


        }
        string sFileName;
   
        // MenuStrip
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Choose your file ...";
            openFileDialog1.Filter = "Text.File (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sFileName = openFileDialog1.FileName;

                txtEditor.Text = System.IO.File.ReadAllText(sFileName);

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sFileName = saveFileDialog1.FileName;
            if (sFileName != "")
            {
                System.IO.File.WriteAllText(sFileName, txtEditor.Text);

            }
            else
            {
                MessageBox.Show("you didn't choose a text file yet ...");
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Title = "Save your file  ...";
            saveFileDialog1.Filter = "Text file(*.txt)|*.txt|All Files(*.*)|*.*";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.OverwritePrompt = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sFileName = saveFileDialog1.FileName;

                System.IO.File.WriteAllText(sFileName, txtEditor.Text);
            }
        }

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtEditor.ForeColor = colorDialog.Color;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                txtEditor.Font = fontDialog1.Font;
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            txtEditor.Text = "";
            sFileName = "";

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //ToolStrip
        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Choose your file ...";
            openFileDialog1.Filter = "Text.File (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sFileName = openFileDialog1.FileName;

                txtEditor.Text = System.IO.File.ReadAllText(sFileName);

            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            sFileName = saveFileDialog1.FileName;
            if (sFileName != "")
            {
                System.IO.File.WriteAllText(sFileName, txtEditor.Text);

            }
            else
            {
                MessageBox.Show("you didn't choose a text file yet ...");
            }
        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Title = "Save your file bitch ...";
            saveFileDialog1.Filter = "Text file(*.txt)|*.txt|All Files(*.*)|*.*";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.OverwritePrompt = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sFileName = saveFileDialog1.FileName;

                System.IO.File.WriteAllText(sFileName, txtEditor.Text);
            }
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                txtEditor.Font = fontDialog1.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtEditor.ForeColor = colorDialog.Color;
            }
        }
        private void TxtEditor_TextChanged(object sender, EventArgs e)
        {
            int wordCount = GetWordCount(txtEditor.Text);
            lblWordCount.Text = $"Words: {wordCount}";
        }

        private int GetWordCount(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            return text.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
        // Cut , Copy , Paste
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEditor.SelectedText))
            {
                Clipboard.SetText(txtEditor.SelectedText);
                txtEditor.SelectedText = ""; // Remove selected text
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEditor.SelectedText))
            {
                Clipboard.SetText(txtEditor.SelectedText);
            }

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                txtEditor.Paste();
            }
        }
    }
}
