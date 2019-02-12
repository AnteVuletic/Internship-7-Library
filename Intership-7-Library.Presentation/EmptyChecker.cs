using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Internship_7_Library.Infrastructure.Extension;

namespace Intership_7_Library.Presentation
{
    public static class EmptyChecker
    {
        public static bool TryTextFieldsEmpty(Control.ControlCollection controls)
        {
            var ifAnyAmpty = false;
            foreach (var control in controls)
            {
                if ((!(control is TextBox textBox))) continue;
                if (textBox.Text == "")
                    ifAnyAmpty = true;
            }
            return ifAnyAmpty;
        }
    }
}
