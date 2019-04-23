using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Threading;


namespace EncodeImageForm
{
    class BitmapBuilder
    {
        //setting members
        private string filePath;
        public Bitmap newMap;



        public BitmapBuilder(string path){
            filePath = path;
        }

        public Bitmap GetNewMap(){
            StreamReader read_file = new StreamReader(filePath);
            Bitmap returnMap = null;
            string type = read_file.ReadLine();
            if (type.ToLower() == "p3"){
                returnMap = buildP3(read_file);
            }else if (type.ToLower() == "p6"){
                returnMap = buildP6();
            }else{
                MessageBox.Show("This is not a valid '.ppm' file. Please try opening a new file.");
            }
            return returnMap;
        }
        
        //separated the p3 and p6 bitmap builders so if the bitmap builder detects a p3 file
        //then it will use the p3 file reading format to build the bitmap
        private Bitmap buildP3(StreamReader read_file){
            //declaring temp variables
            int[] rgbValues;

            read_file.ReadLine(); //disregarding comment line
            string currentLine = read_file.ReadLine(); //reading the size of the picture file
            string[] temp = currentLine.Split(); //splitting the size values into a string array
            int width = int.Parse(temp[0]); //parsing the width into an integer
            int height = int.Parse(temp[1]); //parsing the height into an integer
            rgbValues = new int[((width * 3) * height)];
            currentLine = read_file.ReadLine(); //reading the scale line in the header
            newMap = new Bitmap(width, height);

            //looping through three lines of the file at a time pulling each pixel value from the file
            int x = 0;
            int y = 0;
            int z = 0;
            while (!read_file.EndOfStream){

                //pulling a line(one R, G, or B value) from the file
                //then scaling the value and rounding the value and casting it to an int
                currentLine = read_file.ReadLine();
                rgbValues[z] = int.Parse(currentLine);
                z++;

                
            }
            //time to set the pixels
            for (int i = 0; i < rgbValues.Length; i += 3){
                //creating color value
                Color tempColor = Color.FromArgb(rgbValues[i], rgbValues[i+1], rgbValues[i+2]);
                //setting colors to the bitmap one pixel at a time
                newMap.SetPixel(x,y, tempColor );
                //incrementing x
                x++;
                //when x is at the end of the row reset x and increment y
                if (x == width){
                    x = 0;
                    y++;
                }
            }
            read_file.Close();
            return newMap;

        }

        //separated the p3 and p6 bitmap builders so if the bitmap builder detects a p6 file
        //then it will use the p6 file reading format to build the bitmap
        private Bitmap buildP6(){
            //declaring temp variables
            int[] rgbValues;
            byte[] byteMap = File.ReadAllBytes(filePath);
            int z = 0;
            int header = 0;
            string dimensions = "";
            while (header < 4){
                if (byteMap[z] == 10){
                    header++;
                }
                if (header == 2){
                    z++;
                    while (byteMap[z] != 10){
                        dimensions += (char)byteMap[z];
                        z++;
                    }
                    header++;
                }
                    z++;
            }
            string[] temp = dimensions.Split(); //splitting the size values into a string array
            int width = int.Parse(temp[0]); //parsing the width into an integer
            int height = int.Parse(temp[1]); //parsing the height into an integer
            rgbValues = new int[((width * 3) * height)];
            newMap = new Bitmap(width, height);
            for (int j = 0; j < (width * 3) * height; j++){
                rgbValues[j] = byteMap[z];
                z++;
            }
                
            int x = 0;
            int y = 0;

            
                        //time to set the pixels
            for (int i = 0; i < rgbValues.Length; i += 3){
                //creating color value
                Color tempColor = Color.FromArgb(rgbValues[i], rgbValues[i+1], rgbValues[i+2]);
                //setting colors to the bitmap one pixel at a time
                newMap.SetPixel(x,y, tempColor );
                //incrementing x
                x++;
                //when x is at the end of the row reset x and increment y
                if (x == width){
                    x = 0;
                    y++;
                }
            }
            return newMap;
        }
    }
}
