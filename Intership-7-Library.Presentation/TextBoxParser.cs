using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Internship_7_Library.Infrastructure.Extension;

namespace Intership_7_Library.Presentation
{
    public static class TextBoxParser
    {
        public static bool TextBoxChecker(Control.ControlCollection controls)
        {
            foreach (var control in controls)
            {
                switch (control)
                {
                    case TextBox textBox:
                    {
                        var stringInTextBox = textBox.Text;
                        textBox.Text = ParseTextBoxes.ParseText(stringInTextBox);
                        break;
                    }
                }
            }
            return true;
        }
    }
}
