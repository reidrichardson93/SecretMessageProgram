using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecodeImage
{
    public partial class Form1 : Form
    {
        BitmapCryptography decodeFile;

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainOFD.ShowDialog();
        }

        private void mainOFD_FileOk(object sender, CancelEventArgs e)
        {
            decodeFile = new BitmapCryptography(mainOFD.FileName);
            messageDisplayBox.Text = "Image loaded, ready to decode.";

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void decodeBtn_Click(object sender, EventArgs e)
        {
            messageDisplayBox.Text = decodeFile.decode(messageStartBox.Value, redRadioButton.Checked);
        }

    }
}
