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
            var databaseHelpers = new DatabaseHelper();
            //databaseHelpers.WriteTargetImageToDatabase("C:\\Users\\Tino\\Desktop\\SimpleBot1\\DailyAds\\1.bmp", "American Dad", "DailyAds","1");
            //databaseHelpers.WriteTargetImageToDatabase("C:\\Users\\Tino\\Desktop\\SimpleBot1\\DailyAds\\2.bmp", "American Dad", "DailyAds", "2");
            //databaseHelpers.WriteTargetImageToDatabase("C:\\Users\\Tino\\Desktop\\SimpleBot1\\DailyAds\\3.bmp", "American Dad", "DailyAds", "3");
            //databaseHelpers.WriteTargetImageToDatabase("C:\\Users\\Tino\\Desktop\\SimpleBot1\\DailyAds\\4.bmp", "American Dad", "DailyAds", "4");
            //databaseHelpers.WriteTargetImageToDatabase("C:\\Users\\Tino\\Desktop\\SimpleBot1\\DailyAds\\5.bmp", "American Dad", "DailyAds", "5", true);
            //databaseHelpers.WriteTargetImageToDatabase("C:\\Users\\Tino\\Desktop\\SimpleBot1\\DailyAds\\6.bmp", "American Dad", "DailyAds", "6");


            Bitmap image = databaseHelpers.GetTargetImageFromDatabase("American Dad", "DailyAds", "1");
            Bitmap image2 = databaseHelpers.GetTargetImageFromDatabase("American Dad", "DailyAds", "2");
            Bitmap image3 = databaseHelpers.GetTargetImageFromDatabase("American Dad", "DailyAds", "3");
            Bitmap image4 = databaseHelpers.GetTargetImageFromDatabase("American Dad", "DailyAds", "4");

            List<Bitmap> images = new List<Bitmap>();
            images.Add(image);
            images.Add(image2);
            images.Add(image3);
            images.Add(image4);

            ImageSearch.Cycle(windowTitle, images);


        }
    }
}
