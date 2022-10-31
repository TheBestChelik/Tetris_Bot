using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisBot
{
    static class MainCalibration
    {
        public static Rectangle Board = new Rectangle(658, 188, 250, 500);
        public static Rectangle NextFig = new Rectangle(462, 266, 125, 125);
        static Rectangle Get_Size_Pos(Bitmap screen, Rectangle userfield)
        {
            var rec = new Rectangle();
            int X = userfield.X;
            int Y = userfield.Y;
            int CY = userfield.Y+(int)(userfield.Height/2);
            int CX = userfield.X+(int)(userfield.Width/2);
            int EndX = userfield.X+userfield.Width;
            int EndY = userfield.Y+userfield.Height;
            for(int x = X; x< EndX; x++)
            {
                if (screen.GetPixel(x, CY).R == 0&& screen.GetPixel(x, CY).G==0&& screen.GetPixel(x, CY).B==0)
                {
                    rec.X = x;
                    break;
                }
            }
            for (int x = EndX; x >X; x--)
            {
                if (screen.GetPixel(x, CY).R == 0 && screen.GetPixel(x, CY).G == 0 && screen.GetPixel(x, CY).B == 0)
                {
                    rec.Width = x - rec.X+1;
                    break;
                }
            }
            for (int y = Y; y < EndY; y++)
            {
                if (screen.GetPixel(CX,y ).R ==0&& screen.GetPixel(CX, y).B == 0 && screen.GetPixel(CX, y).G == 0 )
                {
                    rec.Y = y;
                    break;
                }
            }
            for (int y = EndY; y > Y; y--)
            {
                if (screen.GetPixel(CX, y).R == 0 && screen.GetPixel(CX, y).B == 0 && screen.GetPixel(CX, y).G == 0)
                {
                    rec.Height = y - rec.Y+1;
                    break;
                }
            }
            return rec;

        }
        public static string main(Image BoardSample, Image NextSample)
        {

            string ToReturn = String.Empty;
            Bitmap sample = new Bitmap(BoardSample);
            Bitmap Screen = CaptureScreen();
            var location = searchBitmap(sample, Screen, 0f);
            if (location == Rectangle.Empty)
                return Properties.Settings.Default.CalibrationBoardError;
            Board = Get_Size_Pos(Screen, location);
            
            sample = new Bitmap(NextSample);
            location = searchBitmap(sample, Screen, 0);
            if (location == Rectangle.Empty)
                return Properties.Settings.Default.CalibrationNextFigureError;
            NextFig = Get_Size_Pos(Screen, location);


            Properties.Settings.Default.BoardPos = Board.Location;
            Properties.Settings.Default.BoardSize = Board.Size;
            Properties.Settings.Default.NextFigurePos = NextFig.Location;
            Properties.Settings.Default.NextFigureSize = NextFig.Size;
            Properties.Settings.Default.Save();

            return string.Format(Properties.Settings.Default.CalibrationInfo,
                   Environment.NewLine,
                   Board.Location.ToString(),
                   Board.Size.ToString(),
                   NextFig.Location.ToString(),
                   NextFig.Size.ToString());


        }



        private static Bitmap CaptureScreen()
        {
            var image = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            var gfx = Graphics.FromImage(image);
            gfx.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            return image;
        }


        private static Rectangle searchBitmap(Bitmap smallBmp, Bitmap bigBmp, double tolerance)
        {
            BitmapData smallData = smallBmp.LockBits(new Rectangle(0, 0, smallBmp.Width, smallBmp.Height),
               System.Drawing.Imaging.ImageLockMode.ReadOnly,
               System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            BitmapData bigData = bigBmp.LockBits(new Rectangle(0, 0, bigBmp.Width, bigBmp.Height),
               System.Drawing.Imaging.ImageLockMode.ReadOnly,
               System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int smallStride = smallData.Stride;
            int bigStride = bigData.Stride;
            int bigWidth = bigBmp.Width;
            int bigHeight = bigBmp.Height - smallBmp.Height + 1;
            int smallWidth = smallBmp.Width * 3;
            int smallHeight = smallBmp.Height;
            Rectangle location = Rectangle.Empty;
            int margin = Convert.ToInt32(255.0 * tolerance);

            unsafe
            {
                byte* pSmall = (byte*)(void*)smallData.Scan0;
                byte* pBig = (byte*)(void*)bigData.Scan0;

                int smallOffset = smallStride - smallBmp.Width * 3;
                int bigOffset = bigStride - bigBmp.Width * 3;

                bool matchFound = true;

                for (int y = 0; y < bigHeight; y++)
                {
                    for (int x = 0; x < bigWidth; x++)
                    {
                        byte* pBigBackup = pBig;
                        byte* pSmallBackup = pSmall;

                        //Look for the small picture.
                        for (int i = 0; i < smallHeight; i++)
                        {
                            int j = 0;
                            matchFound = true;
                            for (j = 0; j < smallWidth; j++)
                            {
                                //With tolerance: pSmall value should be between margins.
                                int inf = pBig[0] - margin;
                                int sup = pBig[0] + margin;
                                if (sup < pSmall[0] || inf > pSmall[0])
                                {
                                    matchFound = false;
                                    break;
                                }

                                pBig++;
                                pSmall++;
                            }

                            if (!matchFound) break;

                            //We restore the pointers.
                            pSmall = pSmallBackup;
                            pBig = pBigBackup;

                            //Next rows of the small and big pictures.
                            pSmall += smallStride * (1 + i);
                            pBig += bigStride * (1 + i);
                        }

                        //If match found, we return.
                        if (matchFound)
                        {
                            location.X = x;
                            location.Y = y;
                            location.Width = smallBmp.Width;
                            location.Height = smallBmp.Height;
                            break;
                        }
                        //If no match found, we restore the pointers and continue.
                        else
                        {
                            pBig = pBigBackup;
                            pSmall = pSmallBackup;
                            pBig += 3;
                        }
                    }

                    if (matchFound) break;

                    pBig += bigOffset;
                }
            }
            bigBmp.UnlockBits(bigData);
            smallBmp.UnlockBits(smallData);

            return location;

        }
    }
}
