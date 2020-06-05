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


        //Searches for the location of given image (imgTargetPath) in the screenshot
        public static Point Search(string imgSourcePath, Bitmap targetImage, double accuracy = 0.9, bool isTest = false)
        {

            //Point point = new Point();
            //IntPtr hwnd = FindWindow(null, windowTitle);
            // string imgSource = CaptureWindow(hwnd);
            //string imgSearch = imgTargetPath;

            Image<Bgr, byte> source = new Image<Bgr, byte>(imgSourcePath);
            Image<Bgr, byte> template = new Image<Bgr, byte>(targetImage);

            using (Image<Gray, float> result = source.MatchTemplate(template, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                if (maxValues[0] > accuracy)
                {
                    //result.X = minLocations[0].X+template.Size.

                    return maxLocations[0];
                }
                else
                {
                    throw new ApplicationException("Not found!");
                }
            }

        }




        //Combines the functions for searching, so takes a screenshot, searches that screenshot for image location, and clicks on it
        public static void Step(string windowTitle, Bitmap targetImage)
        {
            IntPtr handle = FindWindow(null, windowTitle);

            string imgSourcePath = CaptureWindow(handle);

            Point imgTargetLocation = Search(imgSourcePath, targetImage);

            Thread.Sleep(2000);
            AutoItX.ControlClick(windowTitle, "", "", "left", 1, imgTargetLocation.X, imgTargetLocation.Y);
        }


        //Takes in an array of images to find, and performs Step on each of them
        public static void Cycle(string windowTitle, List<Bitmap> targetImages)
        {
            foreach (Bitmap targetImage in targetImages)
            {
                Thread.Sleep(2000);
                Step(windowTitle, targetImage);
            }
        }

    }
}
