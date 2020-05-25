using System;
using Xamarin.Forms;

namespace MobileClient.Controllers
{
    public class NullableDatePicker : DatePicker
    {
        private string _format = null;
        public static readonly BindableProperty NullableDateProperty = BindableProperty.Create<NullableDatePicker, DateTime?>(p => p.NullableDate, null);

        public NullableDatePicker()
        {
            Format = "dd/MM/yyyy";
        }

        public DateTime? NullableDate
        {
            get { return (DateTime?)GetValue(NullableDateProperty); }
            set { SetValue(NullableDateProperty, value); UpdateDate(); }
        }

        private void UpdateDate()
        {
            if (NullableDate.HasValue) { if (null != _format) Format = _format; Date = NullableDate.Value; }
            else { _format = Format; Format = "pick"; }
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            UpdateDate();
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == "Date") NullableDate = Date;
        }
    }
}