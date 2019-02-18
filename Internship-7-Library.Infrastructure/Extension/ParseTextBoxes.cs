using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Internship_7_Library.Infrastructure.Extension
{
    public static class ParseTextBoxes
    {
        public static string ParseText(string stringPassed)
        {
            switch (stringPassed.Length)
            {
                case 0:
                    return stringPassed;
                case 1:
                    return stringPassed[0].ToString().ToUpper();
                default:

                    stringPassed = stringPassed.Trim();
                    stringPassed = stringPassed.ToLower();
                    var newString = "";
                    var regexToSpace = new Regex(@"[^\s]+");
                    var regexMatches = regexToSpace.Matches(stringPassed);
                    foreach (var match in regexMatches)
                    {
                        newString += match.ToString()[0].ToString().ToUpper() + string.Join("",match.ToString().Skip(1)) + " ";
                    }
                    newString = newString.Trim();
                    return newString;
            }
        }
    }
}
