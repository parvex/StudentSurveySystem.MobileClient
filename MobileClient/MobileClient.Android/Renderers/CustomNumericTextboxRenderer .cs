using Android.Content;
using Android.Widget;
using MobileClient.Droid.Renderers;
using MobileClient.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NumericTextBox), typeof(CustomNumericTextboxRenderer))]
namespace MobileClient.Droid.Renderers
{
    public class CustomNumericTextboxRenderer : EntryRenderer
    {
        public CustomNumericTextboxRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var native = Control as EditText;

            native.InputType = Android.Text.InputTypes.ClassNumber | Android.Text.InputTypes.NumberFlagSigned | Android.Text.InputTypes.NumberFlagDecimal;
        }
    }
}