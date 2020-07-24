using Xamarin.Forms;

namespace MobileClient.Extensions
{
    public class NumericTextBox : Entry
    {
        public NumericTextBox()
        {
            this.Keyboard = Keyboard.Numeric;
        }
    }
}