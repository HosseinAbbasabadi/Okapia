using System;
using System.Linq;

//using System.Drawing.Drawing2D;
//using HtmlAgilityPack;

namespace Framework
{
    public enum DateConvertType
    {
        Short,
        Full
    }

    public enum DateAndTimeConvertType
    {
        Date,
        Time,
        Both
    }

    public static class Tools
    {
        public static string GetJustDate(this DateTime date)
        {
            return $"{date.Year:0000}/{date.Day:00}/{date.Month:00}";
        }

        public static string ToFileName(this DateTime date)
        {
            return $"{date.Year:0000}-{date.Month:00}-{date.Day:00}-{date.Hour:00}-{date.Minute:00}-{date.Second:00}";
        }

        public static string Nums2Farsi(this string originalString)
        {
            var s = originalString;
            var rt = "";
            foreach (var t in s)
                if ("0123456789".Contains(t))
                    rt += (char) ((ushort) t - (ushort) '0' + (ushort) '۰');
                else
                    rt += t;

            return rt;
        }

        //public static Image FixedSize(Image imgPhoto, int Width, int Height, bool needToFill)
        //{
        //    int sourceWidth = imgPhoto.Width;
        //    int sourceHeight = imgPhoto.Height;
        //    if (Width >= sourceWidth || Height >= sourceHeight)
        //    {
        //        return imgPhoto;
        //    }
        //    int sourceX = 0;
        //    int sourceY = 0;
        //    int destX = 0;
        //    int destY = 0;

        //    float nPercent = 0;
        //    float nPercentW = 0;
        //    float nPercentH = 0;

        //    nPercentW = ((float)Width / (float)sourceWidth);
        //    nPercentH = ((float)Height / (float)sourceHeight);
        //    if (!needToFill)
        //    {
        //        if (nPercentH < nPercentW)
        //        {
        //            nPercent = nPercentH;
        //        }
        //        else
        //        {
        //            nPercent = nPercentW;
        //        }
        //    }
        //    else
        //    {
        //        if (nPercentH > nPercentW)
        //        {
        //            nPercent = nPercentH;
        //            destX = (int)Math.Round((Width -
        //                (sourceWidth * nPercent)) / 2);
        //        }
        //        else
        //        {
        //            nPercent = nPercentW;
        //            destY = (int)Math.Round((Height -
        //                (sourceHeight * nPercent)) / 2);
        //        }
        //    }

        //    if (nPercent > 1)
        //        nPercent = 1;

        //    int destWidth = (int)Math.Round(sourceWidth * nPercent);
        //    int destHeight = (int)Math.Round(sourceHeight * nPercent);

        //    System.Drawing.Bitmap bmPhoto = new System.Drawing.Bitmap(
        //        destWidth <= Width ? destWidth : Width,
        //        destHeight < Height ? destHeight : Height,
        //                      System.Drawing.Imaging.PixelFormat.Format32bppRgb);
        //    //bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
        //    //                 imgPhoto.VerticalResolution);

        //    System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto);
        //    grPhoto.Clear(Color.White);
        //    grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //    //InterpolationMode.HighQualityBicubic;
        //    grPhoto.CompositingQuality = CompositingQuality.HighQuality;
        //    grPhoto.SmoothingMode = SmoothingMode.HighQuality;

        //    grPhoto.DrawImage(imgPhoto,
        //        new System.Drawing.Rectangle(destX, destY, destWidth, destHeight),
        //        new System.Drawing.Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
        //        System.Drawing.GraphicsUnit.Pixel);

        //    grPhoto.Dispose();
        //    return bmPhoto;
        //}

        ////png format resize
        ////png 2
        //public static byte[] ResizeImage(Image p, int htOfImage, int maxOfWidth = 0)
        //{
        //    Image img = p;
        //    int width = Convert.ToInt32(Convert.ToDouble(img.Width) *
        //    (Convert.ToDouble(htOfImage) / Convert.ToDouble(img.Height)));
        //    if (maxOfWidth != 0)
        //    {
        //        if (width > maxOfWidth)
        //        {
        //            htOfImage = Convert.ToInt32(Convert.ToDouble(img.Height) *
        //            (Convert.ToDouble(maxOfWidth) / Convert.ToDouble(img.Width)));
        //            width = maxOfWidth;
        //        }
        //    }
        //    System.Drawing.Size s = new System.Drawing.Size(width, htOfImage);
        //    System.Drawing.Image resizedImg = Resize(img, s, true);
        //    using (System.IO.MemoryStream memStream = new System.IO.MemoryStream())
        //    {
        //        if (System.Drawing.Imaging.ImageFormat.Png.Equals(img.RawFormat))
        //        {
        //            resizedImg.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
        //        }
        //        else //of course you could check for bmp, jpg, etc depending on what you allowed
        //        {
        //            resizedImg.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        }
        //        return memStream.ToArray();
        //    }
        //}

        //public static System.Drawing.Image MakeImage(byte[] byteArrayIn)
        //{
        //    System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayIn);
        //    System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
        //    return returnImage;
        //}

        //private static System.Drawing.Image Resize(System.Drawing.Image image,
        // System.Drawing.Size size, bool preserveAspectRatio = true)
        //{
        //    int newWidth;
        //    int newHeight;
        //    if (preserveAspectRatio)
        //    {
        //        int originalWidth = image.Width;
        //        int originalHeight = image.Height;
        //        float percentWidth = (float)size.Width / (float)originalWidth;
        //        float percentHeight = (float)size.Height / (float)originalHeight;
        //        float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
        //        newWidth = (int)(originalWidth * percent);
        //        newHeight = (int)(originalHeight * percent);
        //    }
        //    else
        //    {
        //        newWidth = size.Width;
        //        newHeight = size.Height;
        //    }

        //    //grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //    ////InterpolationMode.HighQualityBicubic;
        //    //grPhoto.CompositingQuality = CompositingQuality.HighQuality;
        //    //grPhoto.SmoothingMode = SmoothingMode.HighQuality;


        //    System.Drawing.Image newImage = new System.Drawing.Bitmap(newWidth, newHeight);
        //    using (System.Drawing.Graphics graphicsHandle = System.Drawing.Graphics.FromImage(newImage))
        //    {
        //        graphicsHandle.SmoothingMode = SmoothingMode.HighQuality;
        //        graphicsHandle.InterpolationMode =
        //                   System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //        graphicsHandle.CompositingQuality = CompositingQuality.HighQuality;
        //        graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
        //    }
        //    return newImage;
        //}
        ////end png format

        //private static Image resizeImage(Image imgToResize, Size size)
        //{
        //    int sourceWidth = imgToResize.Width;
        //    int sourceHeight = imgToResize.Height;

        //    float nPercent = 0;
        //    float nPercentW = 0;
        //    float nPercentH = 0;

        //    nPercentW = ((float)size.Width / (float)sourceWidth);
        //    nPercentH = ((float)size.Height / (float)sourceHeight);

        //    if (nPercentH < nPercentW)
        //        nPercent = nPercentH;
        //    else
        //        nPercent = nPercentW;

        //    int destWidth = (int)(sourceWidth * nPercent);
        //    int destHeight = (int)(sourceHeight * nPercent);

        //    Bitmap b = new Bitmap(destWidth, destHeight);
        //    Graphics g = Graphics.FromImage((Image)b);
        //    g.InterpolationMode = InterpolationMode.HighQualityBicubic;

        //    g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
        //    g.Dispose();

        //    return (Image)b;
        //}
        //static Image cropImage(Image img, Rectangle cropArea)
        //{
        //    Bitmap bmpImage = new Bitmap(img);
        //    Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        //    return (Image)(bmpCrop);
        //}

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //public static string GenerateSlug(this string phrase)
        //{
        //    // string str = phrase.RemoveAccent().ToLower();
        //    // // invalid chars           
        //    //// Remove #
        //    // // convert multiple spaces into one space   
        //    // str = Regex.Replace(str, @"\s+", " ").Trim();
        //    // // cut and trim 
        //    // str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
        //    // str = Regex.Replace(str, @"\s", "-"); // hyphens   
        //    // return str;
        //    var randText = RandomString(5);
        //    var str = phrase; //phrase.RemoveAccent().ToLower();
        //    str = System.Text.RegularExpressions.Regex.Replace(str,
        //        @"[^a-z0-9\s-\u0600-\u06FF\uFB8A\u067E\u0686\u06AF]", ""); // Remove all non valid chars          
        //    str = System.Text.RegularExpressions.Regex.Replace(str, @"\s+", " ")
        //        .Trim(); // convert multiple spaces into one space  
        //    str = System.Text.RegularExpressions.Regex.Replace(str, @"\s", "-"); // //Replace spaces by dashes
        //    return (string.IsNullOrEmpty(str) ? randText : str);
        //}

        public static bool ValidateUrlXss(string inputParameter)
        {
            if (string.IsNullOrEmpty(inputParameter))
                return true;
            return !System.Text.RegularExpressions.Regex.IsMatch(inputParameter, @"(javascript:|<\s*script.*?\s*>)");
        }

        //public static bool ValidateAntiXSS(string inputParameter)
        //{
        //    if (string.IsNullOrEmpty(inputParameter))
        //        return true;
        //    var document = new HtmlDocument();
        //    document.LoadHtml(inputParameter);
        //    bool hasScriptTag = document.DocumentNode.Descendants("script").Any();
        //    return !hasScriptTag;

        //    //var pattren = new StringBuilder();
        //    ////check allow string  
        //    //Regex allow = new Regex(@"(<h.*?>(.*?)<\/h.*?>)|<p.*?>(.*?)<\/p>|<span.*?>(.*?)<\/span.*?>|(<pre.*?>(.*?)<\/pre.*?>)");


        //    //var findtext = allow.Matches(System.Web.HttpUtility.UrlDecode(inputParameter));
        //    //inputParameter = allow.Replace(inputParameter, "");
        //    //inputParameter = inputParameter.Trim();

        //    //if (inputParameter.StartsWith("<pre"))
        //    //    return true;
        //    ////Checks any js events i.e. onKeyUp(), onBlur(), alerts and custom js functions etc.             
        //    //pattren.Append(@"((alert|\w+|function\s+\w+)\s*\(\s*(['+\d\w](,?\s*['+\d\w]*)*)*\s*\))");

        //    ////Checks any html tags i.e. <script, <embed, <object etc.
        //    //pattren.Append(@"|(<(script|iframe|embed|frame|frameset|object|applet|body|html|style|layer|ilayer|meta|bgsound))");


        //    //return !Regex.IsMatch(System.Web.HttpUtility.UrlDecode(inputParameter), pattren.ToString(), RegexOptions.IgnoreCase | RegexOptions.Compiled);
        //}
    }

    public static class Date
    {
        public static string[] MonthNames =
            {"فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"};

        public static string[] DayNames = {"شنبه", "یکشنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه"};
        public static string[] DayNamesG = {"یکشنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه", "شنبه"};


        public static string ToFarsi(this DateTime? date)
        {
            try
            {
                return date?.ToFarsi();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string ToFarsi(this DateTime date)
        {
            if (date != new DateTime())
            {
                var pc = new System.Globalization.PersianCalendar();
                return $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
            }
            else
            {
                return "";
            }
        }

        public static string GetTime(this DateTime date)
        {
            return $"_{date.Hour:00}_{date.Minute:00}_{date.Second:00}";
        }

        public static string ToFarsiFull(this DateTime date)
        {
            var pc = new System.Globalization.PersianCalendar();
            return
                $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00} {date.Hour:00}:{date.Minute:00}:{date.Second:00}";
        }

        public static string ToFarsi(this DateTime date, DateConvertType converDate)
        {
            var pc = new System.Globalization.PersianCalendar();
            if (converDate == DateConvertType.Short)
                return $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
            return
                $"{DayNamesG[(int) pc.GetDayOfWeek(date)]} {pc.GetDayOfMonth(date)} {MonthNames[pc.GetMonth(date) - 1]} {pc.GetYear(date)}";
        }

        public static string ToFarsi(this DateTime date, DateConvertType converDate, DateAndTimeConvertType dateTime)
        {
            var pc = new System.Globalization.PersianCalendar();

            switch (dateTime)
            {
                case DateAndTimeConvertType.Date:
                    if (converDate == DateConvertType.Short)
                        return
                            $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
                    else
                        return
                            $"{DayNamesG[(int) pc.GetDayOfWeek(date)]} {pc.GetDayOfMonth(date)} {MonthNames[pc.GetMonth(date)]} {pc.GetYear(date)}";


                case DateAndTimeConvertType.Time:
                    if (converDate == DateConvertType.Short)
                        return date.TimeOfDay.ToString();
                    else
                        return string.Format("ساعت {4}:{5} {6}", date.TimeOfDay.Hours, date.TimeOfDay.Minutes,
                            date.TimeOfDay.TotalHours > 12 ? "عصر" : "صبح");
                case DateAndTimeConvertType.Both:
                    if (converDate == DateConvertType.Short)
                        return
                            $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00} {date.TimeOfDay.ToString()}";
                    else
                        return
                            $"{DayNamesG[(int) pc.GetDayOfWeek(date)]} {pc.GetDayOfMonth(date)} {MonthNames[pc.GetMonth(date)]} {pc.GetYear(date)} ساعت {date.TimeOfDay.Hours}:{date.TimeOfDay.Minutes} {(date.TimeOfDay.TotalHours > 12 ? "عصر" : "صبح")}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(dateTime), dateTime, null);
            }
        }

        private static readonly string[] pn = {"۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹"};
        private static readonly string[] en = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};

        public static string ToEnglishNumber(this string strNum)
        {
            if (string.IsNullOrEmpty(strNum)) return null;
            var chash = strNum;
            for (var i = 0; i < 10; i++)
                chash = chash.Replace(pn[i], en[i]);
            return chash;

        }

        public static string ToPersianNumber(this int intNum)
        {
            var chash = intNum.ToString();
            for (var i = 0; i < 10; i++)
                chash = chash.Replace(en[i], pn[i]);
            return chash;
        }

        public static DateTime? FromFarsiDate(this string InDate)
        {
            if (string.IsNullOrEmpty(InDate))
                return null;

            var splited = InDate.Split('/');
            if (splited.Length < 3)
                return null;

            if (!int.TryParse(splited[0].ToEnglishNumber(), out var year))
                return null;

            if (!int.TryParse(splited[1].ToEnglishNumber(), out var month))
                return null;

            if (!int.TryParse(splited[2].ToEnglishNumber(), out var day))
                return null;
            var c = new System.Globalization.PersianCalendar();
            return c.ToDateTime(year, month, day, 0, 0, 0, 0);
        }

        public static DateTime ToGeorgianDateTime(this string persianDate)
        {
            persianDate = persianDate.ToEnglishNumber();
            var year = Convert.ToInt32(persianDate.Substring(0, 4));
            var month = Convert.ToInt32(persianDate.Substring(5, 2));
            var day = Convert.ToInt32(persianDate.Substring(8, 2));
            var georgianDateTime = new DateTime(year, month, day, new System.Globalization.PersianCalendar());
            return georgianDateTime;
        }
    }
}