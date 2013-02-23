using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace VochtBalans.Utils
{
    public static class ApplicationBarHelper
    {
        public static void UpdateBindingOnFocussedControl()
        {
            object focusedElement = FocusManager.GetFocusedElement();
            if (focusedElement != null && focusedElement is TextBox)
            {
                var binding = (focusedElement as TextBox).GetBindingExpression(TextBox.TextProperty);
                if (binding != null)
                    binding.UpdateSource();
            }
        }
    }
}
