using SimpleBot.Dto;
using SimpleBot.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleBot
{
    class DatabaseHelper
    {

        ApplicationDbContext _context;

        public DatabaseHelper()
        {
            _context = new ApplicationDbContext();
        }

        
        //Write all images from a directory to database, images must be named by a specific convention (image number followed by a list of next nodes in brackets, divided by
        // ',' if there are more nodes, after the brackets [] true if image is before an ad)
        public void WriteTargetImagesToDatabase(string targetImagesPath, string game, string cycle)
        {
            //Get full paths of all images in a directory
            string[] fullPaths = Directory.GetFiles(targetImagesPath);

            //Loop through each path
            foreach(string targetImagePath in fullPaths)
            {
                bool isAd = false;
                              
                string[] targetImageName = targetImagePath.Split('\\').Last().Split('[');

                //Get the content that is in the brackets [] of image name
                string nextNodes = targetImageName[1].Split(']')[0];

                if (targetImageName[1].Contains("true"))
                    isAd = true;

                //Write image to database
                WriteTargetImageToDatabase(targetImagePath, game, cycle, targetImageName[0], nextNodes, isAd);

            };
           
        }


        public void WriteTargetImageToDatabase(string imgTargetPath, string game, string cycle, string name, string nextNodes, bool isAd = false)
        {

            //Open new stream
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {

                Image image = Image.FromFile(imgTargetPath);

                //Save image data to stream variable
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);

                //Convert the data to byte[] which can be put in database
                byte [] data = stream.ToArray();

                //Create new database object
                var dataImage = new TargetImage
                {
                    Data = data,
                    Game = game,
                    Cycle = cycle,
                    Name = name,
                    IsAd = isAd,
                    NextNode = nextNodes
                    
                };

                //Add and save
                _context.TargetImages.Add(dataImage);
                _context.SaveChanges();
            }
        }


        public Bitmap GetTargetImageFromDatabase(string game, string cycle, string name)
        {
            //Get data from image with matching parameters
            byte[] data = _context.TargetImages.Single(o => (o.Game == game) && (o.Cycle == cycle) && (o.Name == name)).Data;

            //Convert to bitmap image
            Bitmap image = (Bitmap)Image.FromStream(new System.IO.MemoryStream(data));

            return image;

        }

        public List<TargetImageDto> GetTargetImagesFromDatabase(string game, string cycle)
        {

            List<TargetImageDto> targetImageDtos = new List<TargetImageDto>();

            //Get all target images objects with the given game name and cycle from the database
            List<TargetImage> targetImages =_context.TargetImages.Where(o => (o.Game == game) && (o.Cycle) == cycle ).ToList();

            //Put data of all found images in array
            foreach(TargetImage image in targetImages)
            {
                byte[] data = image.Data;
                Bitmap bitmapImage = (Bitmap)Image.FromStream(new System.IO.MemoryStream(data));

                TargetImageDto targetImageDto = new TargetImageDto
                {
                    Name = image.Name,
                    IsAd = image.IsAd,
                    Image = bitmapImage


                };                   
                targetImageDtos.Add(targetImageDto);


            }            

            return targetImageDtos;
        }
    }
}
