using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    stringPassed = stringPassed[0].ToString().ToUpper() + string.Join("", stringPassed.Skip(1));
                    return stringPassed;
            }
        }
    }
}
