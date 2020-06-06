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

namespace SimpleBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
            //databaseHelpers.WriteTargetImageToDatabase("C:\\Users\\Tino\\Desktop\\SimpleBot1\\DailyAds\\1.bmp", "American Dad", "DailyAds","1");
            //databaseHelpers.WriteTargetImageToDatabase("C:\\Users\\Tino\\Desktop\\SimpleBot1\\DailyAds\\2.bmp", "American Dad", "DailyAds", "2");
            //databaseHelpers.WriteTargetImageToDatabase("C:\\Users\\Tino\\Desktop\\SimpleBot1\\DailyAds\\3.0.bmp", "American Dad", "DailyAds", "3");
            //databaseHelpers.WriteTargetImageToDatabase("C:\\Users\\Tino\\Desktop\\SimpleBot1\\DailyAds\\3.1.bmp", "American Dad", "DailyAds", "3");
            //databaseHelpers.WriteTargetImageToDatabase("C:\\Users\\Tino\\Desktop\\SimpleBot1\\DailyAds\\4.bmp", "American Dad", "DailyAds", "4");
            //databaseHelpers.WriteTargetImageToDatabase("C:\\Users\\Tino\\Desktop\\SimpleBot1\\DailyAds\\5.bmp", "American Dad", "DailyAds", "5", true);
            //databaseHelpers.WriteTargetImageToDatabase("C:\\Users\\Tino\\Desktop\\SimpleBot1\\DailyAds\\6.bmp", "American Dad", "DailyAds", "6");
            //databaseHelpers.WriteTargetImageToDatabase("C:\\Users\\Tino\\Desktop\\SimpleBot1\\DailyAds\\7.bmp", "American Dad", "DailyAds", "7");



            List<TargetImageDto> images = databaseHelpers.GetTargetImagesFromDatabase(gameName, cycle);
                       
            ImageSearch.Cycle(windowTitle, images, waitTimeBetweenClicks, waitTimeForAds);


        }
    }
}
