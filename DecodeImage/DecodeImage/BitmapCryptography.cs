using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace DecodeImage
{
    class BitmapCryptography : Form1
    {
        //creating visible bitmaps for use throughout the class
        public Bitmap originalMap{get; private set;}
        public Bitmap alteredMap{get; private set;}

        //protected secret message...because...its a secret...
        private string secretMessage;
        private string path;

        //constructor
        public BitmapCryptography(Bitmap origin, string message = null){
            originalMap = origin;
            secretMessage = message;
            alteredMap = new Bitmap(originalMap.Width, originalMap.Height);
        }

        public BitmapCryptography(string file_path){
            path = file_path;
        }

        //encode method that uses the original bitmap and the secret message
        //then returns another bitmap (alteredMap) with the message embedded within
        public Bitmap encode(decimal startLocation, bool red){
            //creating location variables
            int x = 0;
            int y = 0;
            //counter to loop through secret message
            int message_counter = 0;

            //total pixels to loop through
            int total_pixels = originalMap.Width * originalMap.Height;

            //looping through every pixel
            for (int i = 0; i < total_pixels; i++){
                //pulling the current pixel out of the original bitmap
                Color tempC = originalMap.GetPixel(x, y);

                //if the color values are within the desired ranges then alter the
                //red channel value to the ascii value of the next char in the secret message
                if (i == startLocation && red){
                    Color newC = Color.FromArgb(secretMessage.Length, tempC.G, tempC.B);
                    alteredMap.SetPixel(x, y, newC);
                }else if (i == startLocation && !red){
                    Color newC = Color.FromArgb(tempC.R, tempC.G, secretMessage.Length);
                    alteredMap.SetPixel(x, y, newC);
                }else if (i > startLocation && message_counter < secretMessage.Length && red){
                    //create new color with message embedded
                    Color newC = Color.FromArgb(secretMessage[message_counter], tempC.G, tempC.B);
                    //set message pixel to the altered map
                    alteredMap.SetPixel(x, y, newC);
                    //increment message counter to get next char in secret message
                    message_counter++;
                }else if (i > startLocation && message_counter < secretMessage.Length && !red){
                    //create new color with message embedded
                    Color newC = Color.FromArgb(tempC.R, tempC.G, secretMessage[message_counter]);
                    //set message pixel to the altered map
                    alteredMap.SetPixel(x, y, newC);
                    //increment message counter to get next char in secret message
                    message_counter++;
                }else{ //else keep the old pixel values in the new altered map
                    alteredMap.SetPixel(x, y, tempC);
                }
                //increment the x position
                x++;
                //if x is at the end of the row then move to the next row
                if (x == originalMap.Width){
                    x = 0;
                    y++;
                }
            }
            //return encoded map
            return alteredMap;
        }



        //method that extracts a secret message from the .ppm file and returns the message (string)
        public string decode(decimal startLocation, bool red){
            StreamReader read_file = new StreamReader(path);

            //checking to make sure the file is an ASCII format .ppm file
            string type = read_file.ReadLine().ToLower();
            
            if (type == "p3"){
                secretMessage = decodeP3(startLocation, red, read_file);
            }else if (type == "p6"){
                secretMessage = decodeP6(startLocation, red);
            }else{
                MessageBox.Show("This is not a valid '.ppm' file. Please try opening a new file.");
            }


            return secretMessage;
        }


        //decodeP3 (ASCII) .ppm file that accepts a decimal startlocation, a bool, and a streamreader
        //startloaction tells the method where the secret message begins
        //the bool tells the method which channel the message is hidden in (red or blue)
        //the streamreader is the same as the one that determined if the file was p3 or p6
        //this is more efficient because we do not have to create another streamreader and re-read the first line
        private string decodeP3(decimal startLocation, bool red, StreamReader read_file){
            read_file.ReadLine(); //disregarding comment line
            string currentLine = read_file.ReadLine(); //reading the size of the picture file
            string[] temp = currentLine.Split(); //splitting the size values into a string array
            int width = int.Parse(temp[0]); //parsing the width into an integer
            int height = int.Parse(temp[1]); //parsing the height into an integer
            currentLine = read_file.ReadLine(); //reading the scale line in the header
            //initializing secret message to "" so it can be built apon
            secretMessage = "";
            //temp current pixel value variables
            int currentR;
            int currentG;
            int currentB;
            //looping through three lines of the file at a time pulling each pixel value from the file
            int i = 0;
            int msgLength = -1;
            while (msgLength != 0){
                //getting each pixel value
                currentR = int.Parse(read_file.ReadLine());
                currentG = int.Parse(read_file.ReadLine());
                currentB = int.Parse(read_file.ReadLine());
                //if the pixel matches the altered pixel parameters then pull red channel for char value
                if (i == startLocation && red){
                    msgLength = currentR;
                }else if (i == startLocation && !red){
                    msgLength = currentB;
                }else if (i >= startLocation && red){
                    //build secret message with each char value
                    secretMessage += (char)currentR;
                    msgLength--;
                }else if (i >= startLocation && !red){
                    secretMessage += (char)currentB;
                    msgLength--;
                }
                i++;
            }
            
            //return secret message
            return secretMessage;
        }
        

        //decodeP6  (raw) .ppm file accepts a startlocation and a bool to determine where and which channel to check
        //returns the secret message that has been pulled out of the .ppm file
        //this method does not ever build a bitmap, it only reads the data and returns the imbedded message
        private string decodeP6(decimal startLocation, bool red){

            //gettting all bytes from the file
            byte[] byteMap = File.ReadAllBytes(path);

            //incrementer to read all bytes in byteMap
            int z = 0;

            //header int that is incremented whenever a newLine byte is read
            //this makes sure the header is passed before the pixels start getting read
            int header = 0;

            //checking for the newLine bytes
            //this program is limited to one line comments though
            //multiline comments will result in the header being read as pixels
            while (header < 4){
                if (byteMap[z] == 10){
                    header++;
                }

                z++;
            }

            secretMessage = "";
            //temp current pixel value variables
            int currentR;
            int currentG;
            int currentB;
            //looping through three lines of the file at a time pulling each pixel value from the file
            int i = 0;
            int msgLength = -1;
            while (msgLength != 0){
                //getting each pixel value
                currentR = byteMap[z];
                currentG = byteMap[z + 1];
                currentB = byteMap[z + 2];
                //if the pixel matches the altered pixel parameters then pull red channel for char value
                if (i == startLocation && red){
                    msgLength = currentR;
                }else if (i == startLocation && !red){
                    msgLength = currentB;
                }else if (i >= startLocation && red){
                    //build secret message with each char value
                    secretMessage += (char)currentR;
                    msgLength--;
                }else if (i >= startLocation && !red){
                    secretMessage += (char)currentB;
                    msgLength--;
                }
                //increment pixel location
                i++;

                //increment byte[] location by 3 (one for r one for g and one for b)
                z += 3;
            }
            //return the built secret message
            return secretMessage;

        }
    }
}
