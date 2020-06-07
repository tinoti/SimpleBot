using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBot.Model
{
    class TargetImage
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Data { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public bool IsAd { get; set; }

        public string Game { get; set; }

        public string Cycle { get; set; }

        public string NextNode { get; set; }

    }
}
