using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace EncodeImageForm
{
    public partial class Form1 : Form
    {
        public Bitmap plainImage;
        
        public Form1()
        {
            InitializeComponent();
            Form1_SizeChanged( this, new EventArgs() );
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open open file dialog when the open file button is clicked
            mainOpenFile.ShowDialog();
            saveToolStripMenuItem.Enabled = false;
        }

        private void mainOpenFile_FileOk(object sender, CancelEventArgs e)
        {
            Thread loadImage = new Thread(new ThreadStart(threadImage));
            loadImage.Start();

        }

        private void threadImage(){
            //create bitmap builder object and pass the file path
            BitmapBuilder buildMap = new BitmapBuilder(mainOpenFile.FileName);
            //call GetNewMap method that builds a bitmap from the passed .ppm file
            plainImage = buildMap.GetNewMap();
            bitmapBox.Image = plainImage;
            int total_pixels = plainImage.Height * plainImage.Width;
            messageStartBox.Maximum = total_pixels;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open save file dialog when save button is clicked
            mainSaveFile.ShowDialog();
        }

        private void mainSaveFile_FileOk(object sender, CancelEventArgs e)
        {   
            //if the user specifies that the file is a raw .ppm file then use the raw file saving method
            //otherwise if the user does not specify P6 then P3 is assumed
            if (radioButtonP6.Checked){
                //if the comment box text has been changed then pass custom comment to the writefile method
                if (ppmCommentsBox.ForeColor != System.Drawing.SystemColors.InactiveCaption){
                    writePpmFileP6((Bitmap)encodedMapBox.Image, mainSaveFile.FileName, ppmCommentsBox.Text);
                    
                }else{ //else the comment box text has not been changed so use overload method that uses default comment
                    writePpmFileP6((Bitmap)encodedMapBox.Image, mainSaveFile.FileName);
                }
            }else{
                //if the comment box text has been changed then pass custom comment to the writefile method
                if (ppmCommentsBox.ForeColor != System.Drawing.SystemColors.InactiveCaption){
                    writePpmFileP3((Bitmap)encodedMapBox.Image, mainSaveFile.FileName, ppmCommentsBox.Text);
                    
                }else{ //else the comment box text has not been changed so use overload method that uses default comment
                    writePpmFileP3((Bitmap)encodedMapBox.Image, mainSaveFile.FileName);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //close the form when the exit button has been clicked
            this.Close();
        }

        private void ppmCommentsBox_TextChanged(object sender, EventArgs e)
        {
            //if the message box color is still inactive caption and the text is changed
            //then delete all text in the text box then change color to window text
            if (ppmCommentsBox.ForeColor == System.Drawing.SystemColors.InactiveCaption){
                ppmCommentsBox.Text = null;
                ppmCommentsBox.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void messageBox_TextChanged(object sender, EventArgs e)
        {
            //if the message box color is still inactive caption and the text is changed
            //then delete all text in the text box then change color to window text
            if (messageBox.ForeColor == System.Drawing.SystemColors.InactiveCaption){
                messageBox.Text = "";
                messageBox.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            encodedMapBox.Image = null;
            if (!(plainImage == null)){
                int total_pixels = plainImage.Width * plainImage.Height;
                messageStartBox.Maximum = total_pixels - (messageBox.Text.Length + 1);
            }
        }

        //encodeBtn click event that builds a new bitmap with the altered pixels
        private void encodeBtn_Click(object sender, EventArgs e)
        {
            BitmapCryptography encodeMap;

            //if there is an image in the bitmapBox then encode map
            if(!(bitmapBox.Image == null)){
                if (messageBox.ForeColor == System.Drawing.SystemColors.InactiveCaption){
                    encodeMap = new BitmapCryptography(plainImage);
                }else{
                    encodeMap = new BitmapCryptography(plainImage, messageBox.Text);
                }
                encodedMapBox.Image = encodeMap.encode(messageStartBox.Value, redRadioButton.Checked);
                saveToolStripMenuItem.Enabled = true;
            //otherwise display an error message
            }else{
                messageBox.Text = "";
                messageBox.Text = "Please load an image from the file menu.";
                messageBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            }
        }


        //write .ppm file method that accepts an encoded bitmap, a file path and an optional comment
        //then writes the bitmap as a .ppm file at the specified location
        public void writePpmFileP3(Bitmap encodedMap, string path, string comment = "Certainly not an encoded CIA message..."){
            //initialize variables
            Color CurrentColor;
            int height = encodedMap.Height;
            int width = encodedMap.Width;

            //streamwriter
            StreamWriter write_file = new StreamWriter(path);

            //writing header
            write_file.WriteLine("P3");
            write_file.WriteLine(comment);
            write_file.WriteLine("{0} {1}", width, height);
            write_file.WriteLine("255");

            //creating location variables
            int x = 0;
            int y = 0;
            //looping once through all pixels in encodedMap
            for (int i = 0; i < (height * width); i++){
                //pulling current color
                CurrentColor = encodedMap.GetPixel(x,y);
                //writing each channel value to the file in separate lines
                write_file.WriteLine(CurrentColor.R);
                write_file.WriteLine(CurrentColor.G);
                write_file.WriteLine(CurrentColor.B);
                //increment x
                x++;

                //if x is at the end of the row then reset x and increment y
                if (x == width){
                    x = 0;
                    y++;
                }
            }
            write_file.Close();
        }

                //write .ppm file method that accepts an encoded bitmap, a file path and an optional comment
        //then writes the bitmap as a .ppm file at the specified location
        public void writePpmFileP6(Bitmap encodedMap, string path, string comment = "Certainly not an encoded CIA message..."){
            //initialize variables
            int height = encodedMap.Height;
            int width = encodedMap.Width;

            //streamwriter
            StreamWriter write_file = new StreamWriter(path);

            //writing header
            write_file.WriteLine("P6");
            write_file.WriteLine(comment);
            write_file.WriteLine("{0} {1}", width, height);
            write_file.WriteLine("255");
            write_file.Close();

            //creating location variables
            int x = 0;
            int y = 0;
            //looping once through all pixels in encodedMap
            BinaryWriter write_binary = new BinaryWriter(new FileStream(path, FileMode.Append));
            for (int i = 0; i < (height * width); i++){
                //pulling current color

                    Color color = encodedMap.GetPixel(x, y);
                    write_binary.Write(color.R);
                    write_binary.Write(color.G);
                    write_binary.Write(color.B);
                
                //increment x
                x++;

                //if x is at the end of the row then reset x and increment y
                if (x == width){
                    x = 0;
                    y++;
                }
            }
            write_binary.Close();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int border = bitmapBox.Left;
            bitmapBox.Width = (Width / 2) - (border * 2);
            encodedMapBox.Left = bitmapBox.Left + bitmapBox.Width + border;
            encodedMapBox.Size = bitmapBox.Size; 
            encodedMapBox.Width = bitmapBox.Width - (int)(border * 0.70);
            
            
            }


    }
}
