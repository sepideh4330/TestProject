using DNTPersianUtils.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Project.Common.Helpers;

namespace Project.Common.Extensions
{
    public static class StringExtensions
    {
        public static List<string> SplitStringByIndex(this string source, int index)
        {
            var addresses = new List<string>();
            if (source.Length <= index)
            {
                addresses.Add(source);
                return addresses;
            }
            var lastSpaceIndex = source.Substring(0, index).LastIndexOf(' ');
            var firstPart = source.Substring(0, lastSpaceIndex + 1);
            var secondPart = source.Substring(lastSpaceIndex, source.Length - firstPart.Length);
            addresses.Add(firstPart);
            addresses.Add(secondPart);
            return addresses;
        }

        public static bool TimeIsValid(this string source)
        {
            return source.Length == 5 && source.Count(d => d == ':') == 1 && source[2] == ':' && char.IsDigit(source[0]) && char.IsDigit(source[1]) && char.IsDigit(source[3]) && char.IsDigit(source[4]) && int.TryParse(source.Substring(0, 2), out var validFirst) && validFirst >= 0 && validFirst <= 23 && int.TryParse(source.Substring(3, 2), out var validSecond) && validSecond >= 0 && validSecond <= 59;
        }

        public static bool TimeLowerOrEqualWith(this string source, string second)
        {
            if (!source.TimeIsValid() || !second.TimeIsValid())
            {
                return false;
            }
            int.TryParse(source.Substring(0, 2), out var firstHourTime);
            int.TryParse(source.Substring(3, 2), out var firstMinuteTime);
            int.TryParse(second.Substring(0, 2), out var secondHourTime);
            int.TryParse(second.Substring(3, 2), out var secondMinuteTime);
            return firstHourTime <= secondHourTime && (firstHourTime != secondHourTime || firstMinuteTime <= secondMinuteTime);
        }

        public static Image ToImage(this string text, string fontPath, float fontSize, Color textColor, Color backColor)
        {
            var privateFontCollection = new PrivateFontCollection();
            privateFontCollection.AddFontFile(fontPath);
            var myCustomFont = new Font(privateFontCollection.Families[0], fontSize);
            Image funalImageFromText = new Bitmap(1, 1);
            var drawing = Graphics.FromImage(funalImageFromText);
            var textSize = drawing.MeasureString(text, myCustomFont);
            funalImageFromText.Dispose();
            drawing.Dispose();
            funalImageFromText = new Bitmap((int)textSize.Width, (int)textSize.Height);
            drawing = Graphics.FromImage(funalImageFromText);
            drawing.Clear(backColor);
            Brush textBrush = new SolidBrush(textColor);
            drawing.DrawString(text, myCustomFont, textBrush, 0, 0);
            drawing.Save();
            textBrush.Dispose();
            drawing.Dispose();
            return funalImageFromText;
        }

        public static string CleanGeolocation(this string source)
        {
            var splitGeolocation = source.Split('.');
            if (splitGeolocation[1].Length <= 7)
            {
                splitGeolocation[1] = splitGeolocation[1].Insert(splitGeolocation[1].Length, "000000");
            }
            return splitGeolocation[0] + "." + splitGeolocation[1].Substring(0, 6);
        }

        public static string FixPhoneNumber(this string inputText)
        {
            return inputText.StartsWith("0") ? inputText : "0" + inputText;
        }

        public static byte[] ConvertStringToBase64String(this string inputText)
        {
            inputText = inputText.Replace("data:image/png;base64,", "")
                .Replace("data:image/gif;base64,", "")
                .Replace("data:image/jpeg;base64,", "");

            return Convert.FromBase64String(inputText);
        }

        public static Image ConvertBase64StringToImage(this string inputText)
        {
            inputText = inputText.Replace("data:image/png;base64,", "")
                .Replace("data:image/gif;base64,", "")
                .Replace("data:image/jpeg;base64,", "");
            var bytes = Convert.FromBase64String(inputText);
            Image image;
            using (var ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }
            return image;
        }

        public static bool HaveInvalidExcelColumnData(this string inputText)
        {
            return string.IsNullOrEmpty(inputText) || inputText.ToLower() == "null" || inputText.ToLower() == "empty";
        }

        public static bool HaveInvalidExcelFile(this List<string> inputTexts)
        {
            return inputTexts.Any(d => string.IsNullOrEmpty(d) || d.ToLower() == "null" || d.ToLower() == "empty");
        }
        public static string ToDashDateTime(this string inputText)
        {
            return inputText.Replace("/", "-");
        }

        public static string UnMask(this string inputText)
        {
            return inputText.Replace("-", "");
        }

        public static string RemoveBrackets(this string inputText)
        {
            return inputText.Replace("{", "").Replace("}", "");
        }

        public static bool IsEmailAddress(this string inputText)
        {
            return !string.IsNullOrWhiteSpace(inputText) && new EmailAddressAttribute().IsValid(inputText);
        }

        public static bool IsNumeric(this string inputText)
        {
            if (string.IsNullOrWhiteSpace(inputText)) return false;

            return long.TryParse(inputText.ToEnglishNumbers(), out _);
        }

        public static bool ContainsNumber(this string inputText)
        {
            return !string.IsNullOrWhiteSpace(inputText) && inputText.ToEnglishNumbers().Any(char.IsDigit);
        }

        public static bool HasConsecutiveChars(this string inputText, int sequenceLength = 3)
        {
            var charEnumerator = StringInfo.GetTextElementEnumerator(inputText);
            var currentElement = string.Empty;
            var count = 1;
            while (charEnumerator.MoveNext())
            {
                if (currentElement == charEnumerator.GetTextElement())
                {
                    if (++count >= sequenceLength)
                    {
                        return true;
                    }
                }
                else
                {
                    count = 1;
                    currentElement = charEnumerator.GetTextElement();
                }
            }
            return false;
        }

        public static bool IsGuid(this string inputText)
        {
            return Guid.TryParse(inputText, out var value);
        }

        public static Guid ToGuid(this string inputText)
        {
            return new Guid(inputText);
        }

        public static string CleanExtraSpaces(this string inputText)
        {
            return inputText
                .Replace("  ", " ")
                .Replace("   ", " ")
                .Replace("    ", " ")
                .Replace("     ", " ");
        }
        public static bool IsValidNationalCode(this string nationalCode)
        {
            //در صورتی که کد ملی وارد شده تهی باشد

            if (String.IsNullOrEmpty(nationalCode))
                throw new Exception("لطفا کد ملی را صحیح وارد نمایید");


            //در صورتی که کد ملی وارد شده طولش کمتر از 10 رقم باشد
            if (nationalCode.Length != 10)
                throw new Exception("طول کد ملی باید ده کاراکتر باشد");

            //در صورتی که کد ملی ده رقم عددی نباشد
            var regex = new Regex(@"\d{10}");
            if (!regex.IsMatch(nationalCode))
                throw new Exception("کد ملی تشکیل شده از ده رقم عددی می‌باشد؛ لطفا کد ملی را صحیح وارد نمایید");

            //در صورتی که رقم‌های کد ملی وارد شده یکسان باشد
            var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
            if (allDigitEqual.Contains(nationalCode)) return false;


            //عملیات شرح داده شده در بالا
            var chArray = nationalCode.ToCharArray();
            var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
            var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
            var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
            var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
            var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
            var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
            var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
            var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
            var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
            var a = Convert.ToInt32(chArray[9].ToString());

            var b = (((((((num0 + num2) + num3) + num4) + num5) + num6) + num7) + num8) + num9;
            var c = b % 11;

            return (((c < 2) && (a == c)) || ((c >= 2) && ((11 - c) == a)));
        }

        public static string AsciiToPersian(this string value)
        {
            if (!value.Contains(";#") && !value.Contains(";&"))
            {
                return value;
            }
            var asciiValue = value.Replace("&#", "").Replace("&amp;", "&").Replace("amp;", "&");
            var asciiCodes = asciiValue.Replace(" ", ";").Split(';');
            var text = "";
            foreach (var asciiCode in asciiCodes)
            {
                if (string.IsNullOrEmpty(asciiCode) || asciiCode == " ")
                {
                    text += " ";
                }
                else if (asciiCode.Length != 4)
                {
                    text += asciiCode;
                }
                else
                {
                    int.TryParse(asciiCode, out var unicode);
                    var character = (char)unicode;
                    text += character.ToString();
                }
            }
            return HelperMethods.HtmlDecode(text);
        }

        public static string AsciiToText(this string value)
        {
            return value
                .Replace("&#1570;", "آ")
                .Replace("&#1575;", "ا")
                .Replace("&#1576;", "ب")
                .Replace("&#1662;", "پ")
                .Replace("&#1578;", "ت")
                .Replace("&#1579;", "ث")
                .Replace("&#1580;", "ج")
                .Replace("&#1670;", "چ")
                .Replace("&#1581;", "ح")
                .Replace("&#1582;", "خ")
                .Replace("&#1583;", "د")
                .Replace("&#1584;", "ذ")
                .Replace("&#1585;", "ر")
                .Replace("&#1586;", "ز")
                .Replace("&#1688;", "ژ")
                .Replace("&#1587;", "س")
                .Replace("&#1588;", "ش")
                .Replace("&#1589;", "ص")
                .Replace("&#1590;", "ض")
                .Replace("&#1591;", "ط")
                .Replace("&#1592;", "ظ")
                .Replace("&#1593;", "ع")
                .Replace("&#1594;", "غ")
                .Replace("&#1601;", "ف")
                .Replace("&#1602;", "ق")
                .Replace("&#1705;", "ک")
                .Replace("&#1711;", "گ")
                .Replace("&#1604;", "ل")
                .Replace("&#1605;", "م")
                .Replace("&#1606;", "ن")
                .Replace("&#1608;", "و")
                .Replace("&#1607;", "ه")
                .Replace("&#1740;", "ی")
                .Replace("&#1569;", "ئ")
                .Replace("&#1574;", "ء")
                .Replace("&#1609;", "ى")
                .Replace("amp;", "")
                .Replace(";amp", "")
                .Replace("amp", "");
        }

        public static string FixPrice(this string value)
        {
            return value
                .Replace(".", "")
                .Replace("،", "")
                .Replace(",", "")
                .Replace("ريال", "");
        }
        public static string FixDot(this string value)
        {
            return value
                .Replace("&#46;", ".");
        }
        public static string FixComma(this string value)
        {
            return value
                .Replace("&#1548;", "،");
        }
        public static string FixSpaces(this string value)
        {
            return value
                .Replace("  ", " ")
                .Replace("   ", " ")
                .Replace("    ", " ")
                .Replace("     ", " ");
        }

        public static DateTimeOffset FromUnixTime(this string unixTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
            var epochDdateTimeOffset = new DateTimeOffset(epoch);
            var unixTimeLong = double.Parse(unixTime);
            epochDdateTimeOffset = epochDdateTimeOffset.AddMilliseconds(unixTimeLong);
            return epochDdateTimeOffset;
        }

        public static string JustifyPhoneNumbers(this string value)
        {
            return value
                .Replace("+98", "0");
        }

        public static int SpecifyCallType(this string value)
        {
            switch (value)
            {
                case "1":
                    return 100;
                case "2":
                    return 200;
                case "3":
                    return 300;
                case "5":
                    return 400;
                default:
                    return 500;
            }
        }
    }
}
