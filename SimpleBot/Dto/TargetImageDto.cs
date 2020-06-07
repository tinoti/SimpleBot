using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleBot.Dto
{
    class TargetImageDto
    {
     
        public TargetImageDto()
        {
            Next = new List<TargetImageDto>();
        }

        public string Name { get; set; }

        public Bitmap Image { get; set; }

        public bool IsAd { get; set; }

        public List<TargetImageDto> Next { get; set; }

        public static void SetNextNode(List<TargetImageDto> images, string targetNodeName, string nextNodeName)
        {
            TargetImageDto targetImage = images.Single(o => o.Name == targetNodeName);

            TargetImageDto nextImage = images.Single(o => o.Name == nextNodeName);

            targetImage.Next.Add(nextImage);

        }

    }
}
