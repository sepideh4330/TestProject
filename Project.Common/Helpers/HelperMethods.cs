using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Project.Common.Helpers
{
    public static class HelperMethods
    {
        public static Image MergeMultipleImages(Image[] images)
        {
            var width = 0;
            var height = 0;
            foreach (var image in images)
            {
                width += image.Width;
                height = image.Height > height ? image.Height : height;
            }
            var finalImage = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(finalImage))
            {
                graphics.Clear(Color.White);
                var offset = 0;
                foreach (var image in images)
                {
                    graphics.DrawImage(image, new Rectangle(offset, 0, image.Width, image.Height));
                    offset += image.Width;
                }
            }
            return finalImage;
        }

        public static string NumberToMonthName(int month)
        {
            switch (month)
            {
                case 1:
                    return "فروردین";
                case 2:
                    return "اردیبهشت";
                case 3:
                    return "خرداد";
                case 4:
                    return "تیر";
                case 5:
                    return "مرداد";
                case 6:
                    return "شهریور";
                case 7:
                    return "مهر";
                case 8:
                    return "آبان";
                case 9:
                    return "آذر";
                case 10:
                    return "دی";
                case 11:
                    return "بهمن";
                case 12:
                    return "اسفند";
            }
            return "";
        }

        public static string HtmlDecode(string text)
        {
            return HttpUtility.HtmlDecode(text)?.Trim();
        }
    }
}
