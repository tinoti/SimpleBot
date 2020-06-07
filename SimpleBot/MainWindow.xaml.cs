using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using SimpleBot.Model;
using SimpleBot.Dto;
using IronOcr;

namespace SimpleBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            //InitializeComponent();
            string windowTitle = "BlueStacks";
            string gameName = "American Dad";
            string cycle = "DailyAds";
            int waitTimeBetweenClicks = 5000;
            int waitTimeForAds = 40000;

            var databaseHelpers = new DatabaseHelper();
            //databaseHelpers.WriteTargetImageToDatabase("c:\\users\\tino\\desktop\\simplebot1\\dailyads\\HeadNode.bmp", "american dad", "dailyads", "HeadNode");
            //databaseHelpers.WriteTargetImageToDatabase("c:\\users\\tino\\desktop\\simplebot1\\dailyads\\1.bmp", "american dad", "dailyads", "1");
            //databaseHelpers.WriteTargetImageToDatabase("c:\\users\\tino\\desktop\\simplebot1\\dailyads\\2.bmp", "american dad", "dailyads", "2");
            //databaseHelpers.WriteTargetImageToDatabase("c:\\users\\tino\\desktop\\simplebot1\\dailyads\\3.0.bmp", "american dad", "dailyads", "3.0");
            //databaseHelpers.WriteTargetImageToDatabase("c:\\users\\tino\\desktop\\simplebot1\\dailyads\\3.1.bmp", "american dad", "dailyads", "3.1");
            //databaseHelpers.WriteTargetImageToDatabase("c:\\users\\tino\\desktop\\simplebot1\\dailyads\\3.2.bmp", "american dad", "dailyads", "3.2");
            //databaseHelpers.WriteTargetImageToDatabase("c:\\users\\tino\\desktop\\simplebot1\\dailyads\\4.bmp", "american dad", "dailyads", "4", true);
            //databaseHelpers.WriteTargetImageToDatabase("c:\\users\\tino\\desktop\\simplebot1\\dailyads\\5.0.bmp", "american dad", "dailyads", "5.0");
            //databaseHelpers.WriteTargetImageToDatabase("c:\\users\\tino\\desktop\\simplebot1\\dailyads\\5.1.bmp", "american dad", "dailyads", "5.1");
            //databaseHelpers.WriteTargetImageToDatabase("c:\\users\\tino\\desktop\\simplebot1\\dailyads\\6.bmp", "american dad", "dailyads", "6");
            //databaseHelpers.WriteTargetImageToDatabase("c:\\users\\tino\\desktop\\simplebot1\\dailyads\\7.bmp", "american dad", "dailyads", "7");

            string targetPath = "C:\\Users\\Tino\\Desktop\\TargetImages\\American Dad\\DailyAds";

            databaseHelpers.WriteTargetImagesToDatabase(targetPath, gameName, cycle);

            //List<TargetImageDto> images = databaseHelpers.GetTargetImagesFromDatabase(gameName, cycle);

            //TargetImageDto.SetNextNode(images, "HeadNode", "1");
            //TargetImageDto.SetNextNode(images, "1", "2");
            //TargetImageDto.SetNextNode(images, "2", "3.0");
            //TargetImageDto.SetNextNode(images, "2", "3.1");
            //TargetImageDto.SetNextNode(images, "2", "3.2");
            //TargetImageDto.SetNextNode(images, "3.0", "4");
            //TargetImageDto.SetNextNode(images, "3.1", "4");
            //TargetImageDto.SetNextNode(images, "3.2", "6");
            //TargetImageDto.SetNextNode(images, "4", "5.0");
            //TargetImageDto.SetNextNode(images, "4", "5.1");
            //TargetImageDto.SetNextNode(images, "5.0", "6");
            //TargetImageDto.SetNextNode(images, "5.1", "6");
            //TargetImageDto.SetNextNode(images, "6", "7");
            //TargetImageDto.SetNextNode(images, "7", "1");


            //ImageSearch.Cycle(windowTitle, images, waitTimeBetweenClicks, waitTimeForAds);


        }
    }
}
