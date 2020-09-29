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

namespace Text_editor
{
    public partial class Form1 : Form
    {
        Form1 _form1;
        OpenFileDialog _file;
        Color _changedTextColor;
        Color _savedTextColor;

        public Form1()
        {
            InitializeComponent();
            _form1 = this;
            timer1.Start();
            _changedTextColor = Color.Gray;
            _savedTextColor = Color.Black;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = _changedTextColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_file == null)
            {
                MessageBox.Show("Alege un file.");
            }

            SaveFile();
        }

        private void SaveFile()
        {
            if (_file == null)
                return;

            textBox1.ForeColor = _savedTextColor;
            File.WriteAllText(_file.FileName, textBox1.Text);
        }

        private void OpenFile()
        {
            var lastFile = _file;
            _file = new OpenFileDialog();
            _file.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            _file.ShowDialog();

            if (_file.FileName == "")
            {
                _file = lastFile;
                return;
            }

            textBox1.Text = File.ReadAllText(_file.FileName);
            _form1.Text = _file.SafeFileName;
            textBox1.ForeColor = _savedTextColor;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
                SaveFile();

            if (e.KeyCode == Keys.O && Control.ModifierKeys == Keys.Control)
                OpenFile();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                _changedTextColor = colorDialog.Color;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _savedTextColor = colorDialog.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog.Font;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
