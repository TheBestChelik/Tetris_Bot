using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace TetrisBot
{
    public static class MainPlaying
    {
        public static string Start(System.Drawing.Rectangle Board, System.Drawing.Rectangle NextFig)
        {
            return OldProgramm.Main(Board.X, Board.Y, Board.Width, Board.Height, NextFig.X,NextFig.Y, NextFig.Width, NextFig.Height);
            
        }
    }
}
