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
        ApplicationDbContext _context;

        public MainWindow()
        {
            //InitializeComponent();
            byte[] data;

            _context = new ApplicationDbContext();

            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                var image = Image.FromFile("C:\\Users\\Tino\\Desktop\\SimpleBot1\\test.bmp");
                
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                data = stream.ToArray();

                byte[] data2 = _context.TargetImages.Single(o => o.Name == "test").Data;

                Image image2 = Image.FromStream(new System.IO.MemoryStream(data2));
                image2.Save("C:\\Users\\Tino\\Desktop\\SimpleBot1\\test2.bmp");
                
                //_context.TargetImages.Add(image3);
                //_context.SaveChanges();
            }
        }
    }
}
