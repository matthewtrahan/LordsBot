using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;

namespace LordsBot
{
   public class ImageProcessing
    {
       


        public static List<Point> LocateImageMultiple(int handl , Bitmap bmpImage, double threshold) {

            Image<Bgr, byte> source = new Image<Bgr, byte>(ScreenshotWindow(handl));
            Image<Bgr, byte> template = new Image<Bgr, byte>(bmpImage);

            Image<Gray, float> result = source.MatchTemplate(template, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed);


            List<Point> pointList = new List<Point>();

            for (int y = 0; y < result.Data.GetLength(0); y++)
            {
                for (int x = 0; x < result.Data.GetLength(1); x++)
                {
                    if (result.Data[y, x, 0] >= threshold) //Check if its a valid match
                    {

                        //Point loc = new Point(x, y);               
                        //Image2 found within Image1
                        
                        pointList.Add(new Point(x,y));

                    }
                }
            }


            
            return pointList;
        }


        public static Point LocateImageSingle(int handl, Bitmap bmpImage, double threshold)
        {

            Image<Bgr, byte> source = new Image<Bgr, byte>(ScreenshotWindow(handl));
            Image<Bgr, byte> template = new Image<Bgr, byte>(bmpImage);

            Image<Gray, float> result = source.MatchTemplate(template, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed);

            double[] minValues, maxValues;
            Point[] minLocations, maxLocations;
            result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

            // value of threshold determinds how accurate the image match should be.
            if (maxValues[0] > threshold)
            {
                // If there is a match. Returns the location of the match.

                return maxLocations[0];

            }

           

            
            //if there is no match, returns empty point
            return Point.Empty;
        }






    





        public static Bitmap ScreenshotWindow(int handl) {
            RECT rc; //creates a rectangle 
            Win32.GetWindowRect(handl, out rc); //gets dimensions of the window
            // Bitmap bmp = new Bitmap(rc.Width, rc.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb); //creates a empty bitmap with the dimensions of the window
            Bitmap bmp = new Bitmap(rc.Width, rc.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics memoryGraphics = Graphics.FromImage(bmp);
            IntPtr dc = memoryGraphics.GetHdc();
            Win32.PrintWindow(handl, dc, 0);
            memoryGraphics.ReleaseHdc(dc);
            memoryGraphics.Dispose();
            return bmp;
        }





  

    }
}
