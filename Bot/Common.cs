using System.Drawing;
using System.Threading;

namespace LordsBot.Bot
{
    public static class Common
    {
        private static double threshold = 0.8;
        private static int delay = 3000;

        public static bool hideUI(int handler)
        {
            bool UI1Hidden = SendMouseClickForTemplate(LordsBot.Properties.Resources.UI1Opened, handler);
            bool UI2Hidden = SendMouseClickForTemplate(LordsBot.Properties.Resources.UI2Opened, handler);

            if (UI1Hidden == true && UI2Hidden == true)
            {
                return true;
            }
            else
            {
                var point = ImageProcessing.LocateImageSingle(handler, LordsBot.Properties.Resources.UI1Closed, threshold);
                if (point.X != 0 && point.Y != 0)
                {
                    UI1Hidden = true;
                }
                point = ImageProcessing.LocateImageSingle(handler, LordsBot.Properties.Resources.UI2Closed, threshold);
                if (point.X != 0 && point.Y != 0)
                {
                    UI1Hidden = true;
                }
                if (UI1Hidden == true && UI2Hidden == true)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool unhideUI(int handler)
        {
            bool UI1Hidden = SendMouseClickForTemplate(LordsBot.Properties.Resources.UI1Closed, handler);
            bool UI2Hidden = SendMouseClickForTemplate(LordsBot.Properties.Resources.UI2Closed, handler);

            if (UI1Hidden == true && UI2Hidden == true)
            {
                return true;
            }
            else
            {
                var point = ImageProcessing.LocateImageSingle(handler, LordsBot.Properties.Resources.UI1Opened, threshold);
                if (point.X != 0 && point.Y != 0)
                {
                    UI1Hidden = true;
                }
                point = ImageProcessing.LocateImageSingle(handler, LordsBot.Properties.Resources.UI2Opened, threshold);
                if (point.X != 0 && point.Y != 0)
                {
                    UI1Hidden = true;
                }
                if (UI1Hidden == true && UI2Hidden == true)
                {
                    return true;
                }
            }


            return false;
        }

        public static bool SendMouseClickForTemplate(Bitmap resource, int handler, double threshold = 0.8)
        {
            var point = ImageProcessing.LocateImageSingle(handler, resource, threshold);
            if (point.X != 0 && point.Y != 0)
            {
                MouseAction.SendMouseClick(handler, point.X, point.Y);
                Thread.Sleep(delay);

                return true;
            }

            return false;
        }
    }
}
