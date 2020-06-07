using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Status;
using AutoIt;
using System.Threading;
using SimpleBot.Dto;

namespace SimpleBot
{
    class ImageSearch
    {
        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr handle, ref Rectangle rect);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        //Takes screenshot of the window and saves it to .bmp, returns path to saved image
        static public string CaptureWindow(IntPtr handle)
        {
            string path = System.IO.Path.GetTempPath();

            // Get the size of the window to capture
            Rectangle rect = new Rectangle();
            GetWindowRect(handle, ref rect);

            // GetWindowRect returns Top/Left and Bottom/Right, so fix it
            rect.Width = rect.Width - rect.X;
            rect.Height = rect.Height - rect.Y;

            // Create a bitmap to draw the capture into
            using (Bitmap bitmap = new Bitmap(rect.Width, rect.Height))
            {
                // Use PrintWindow to draw the window into our bitmap
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    IntPtr hdc = g.GetHdc();
                    if (!PrintWindow(handle, hdc, 0))
                    {
                        int error = Marshal.GetLastWin32Error();
                        var exception = new System.ComponentModel.Win32Exception(error);
                        Debug.WriteLine("ERROR: " + error + ": " + exception.Message);
                    }
                    g.ReleaseHdc(hdc);
                }
                bitmap.Save(path + "CurrentScreen.bmp");

            }

            return path + "CurrentScreen.bmp";
        }


        //Searches for the location of given image in the screenshot, returns true if location is found and passes the location by reference
        public static bool Search(string imgSourcePath, Bitmap targetImage, ref Point location, double accuracy = 0.9, bool isTest = false)
        {
            //Screenshot image
            Image<Bgr, byte> source = new Image<Bgr, byte>(imgSourcePath);

            double[] minValues, maxValues;
            Point[] minLocations, maxLocations;

            //Image which location needs to be found
            Image<Bgr, byte> template = new Image<Bgr, byte>(targetImage);

            using (Image<Gray, float> result = source.MatchTemplate(template, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
            {

                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                //maxValues represent the accuracy of the found image, 1 being the most accurate and 0 least accurate
                if (maxValues[0] > accuracy)
                {
                    //Pass the location by reference and return true
                    location = maxLocations[0];                    
                    return true;
                }
                    
            }

            return false;      

        }




        //Combines the functions Takes a screenshot, searches that screenshot for image location, and clicks on it
        public static TargetImageDto Step(string windowTitle, TargetImageDto targetImage, int waitTimeBetweenClicks, int waitTimeForAds = 40000)
        {
            Point location = new Point();

            //Wait
            if (targetImage.IsAd)
                Thread.Sleep(waitTimeForAds);
            else
                Thread.Sleep(waitTimeBetweenClicks);

            //Get the pointer to the window
            IntPtr handle = FindWindow(null, windowTitle);

            //Capture screenshot of window and return path to it
            string imgSourcePath = CaptureWindow(handle);


            foreach(TargetImageDto nextNode in targetImage.Next)
            {
                if(Search(imgSourcePath, nextNode.Image, ref location))
                {
                    AutoItX.ControlClick(windowTitle, "", "", "left", 1, location.X, location.Y);
                    return nextNode;
                }
            }

            //Every scenario should be covered in the searchin logic, if it gets to here means something went wrong
            throw new ApplicationException("Not found!");
        }


        //Goes through list of target images and their nodes
        public static void Cycle(string windowTitle, List<TargetImageDto> targetImages, int waitTimeBetweenClicks, int waitTimeForAds = 40000)
        {
            //Set currentImage to HeadNode of the cycle
            TargetImageDto currentImage = targetImages[0];

            while (true)
            {
                if (currentImage.Next == null)
                    break;

                //Step returns the next image it should look for
                currentImage = Step(windowTitle, currentImage, waitTimeBetweenClicks);


            }
        }


        

    }
}
