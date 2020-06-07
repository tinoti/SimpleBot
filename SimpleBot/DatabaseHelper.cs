using SimpleBot.Dto;
using SimpleBot.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        
        public void WriteTargetImageToDatabase(string imgTargetPath, string game, string cycle, string name, bool isAd = false)
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
                    IsAd = isAd
                    
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
