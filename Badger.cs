using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityHeaders.io.badges
{
    internal class Badger
    {
        private const string BADGE_TEMPLATE = @"<svg xmlns=""http://www.w3.org/2000/svg"" width=""145"" height=""20""><linearGradient id=""a"" x2=""0"" y2=""100%""><stop offset=""0"" stop-color=""#bbb"" stop-opacity="".1""/><stop offset=""1"" stop-opacity="".1""/></linearGradient><rect rx=""3"" width=""145"" height=""20"" fill=""#555""/><rect rx=""3"" x=""112"" width=""33"" height=""20"" fill=""#{1}""/><path fill=""#{1}"" d=""M112 0h4v20h-4z""/><rect rx=""3"" width=""145"" height=""20"" fill=""url(#a)""/><g fill=""#fff"" text-anchor=""middle"" font-family=""DejaVu Sans,Verdana,Geneva,sans-serif"" font-size=""11""><text x=""55"" y=""15"" fill=""#010101"" fill-opacity="".3"">securityheaders.io</text><text x=""55"" y=""14"">securityheaders.io</text><text x=""128"" y=""15"" fill=""#010101"" fill-opacity="".3"">{0}</text><text x=""128"" y=""14"">{0}</text></g></svg>";
        private static Dictionary<string, string> ColourMap = new Dictionary<string, string>()
        {
            { "A+", "4EC83D"},
            { "A", "41A832" },
            { "B", "FFD242" },
            { "C", "FFD242" },
            { "D", "FFA500" },
            { "E", "FFA500" },
            { "F", "FF0000" },
            { "R", "808080" }
        };

        internal string Badge(string rating)
        {
            return string.Format(BADGE_TEMPLATE, rating, ColourMap[rating]);
        }
    }
}
