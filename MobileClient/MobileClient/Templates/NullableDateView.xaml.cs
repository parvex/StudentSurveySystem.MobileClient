using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NullableDateView : ContentView
    {
        public DatePicker DatePicker { get; set; }

        private string _format = "dd/MM/yyyy";
        public static readonly BindableProperty NullableDateProperty =
            BindableProperty.Create("NullableDate", typeof(DateTime?), typeof(NullableDateView), null, BindingMode.TwoWay, null,
                HandleDateChanged);


        public static readonly BindableProperty IsVisibleProperty =
            BindableProperty.Create("IsVisible", typeof(bool), typeof(NullableDateView), true, BindingMode.TwoWay, null,
            HandleIsVisibleChanged);

        private static void HandleDateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((NullableDateView)bindable).NullableDate = (DateTime?)newValue;
        }


        private static void HandleIsVisibleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((NullableDateView)bindable).IsVisible = (bool)newValue;
            ((NullableDateView) bindable).Content.IsVisible = (bool) newValue;
            ((NullableDateView) bindable).IsVisible = (bool) newValue;
            ((NullableDateView) bindable).Grid.IsVisible = (bool) newValue;
        }

        public event EventHandler DateChanged;

        public NullableDateView()
        {
            InitializeComponent();
            Unfocused += Picker_Unfocused;
            Picker.Format = "dd/MM/yyyy";
            Picker.DateSelected += Picker_DateSelected;
            Picker.DateSelected += Picker_DateSelected;
            Picker.Unfocused += Picker_Unfocused;
            DatePicker = Picker;
        }

        private void Picker_DateSelected(object sender, DateChangedEventArgs e)
        {
            NullableDate = ((DatePicker) sender).Date;
            DateChanged?.Invoke(this, e);
        }

        public DateTime? NullableDate
        {
            get { return (DateTime?)GetValue(NullableDateProperty); }
            set { SetValue(NullableDateProperty, value); UpdateDate(); }
        }

        public new bool IsVisible
        {
            get => (bool)GetValue(NullableDateView.IsVisibleProperty);
            set { SetValue(NullableDateView.IsVisibleProperty, value); }
        }

        private void ClearButton_OnClicked(object sender, EventArgs e)
        {
            NullableDate = null;
        }

        private void UpdateDate()
        {
            if (NullableDate.HasValue)
            {
                if (_format != null)
                    Picker.Format = _format; Picker.Date = NullableDate.Value;
            }
            else
            {
                Picker.Format = "pick";
            }
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            UpdateDate();
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == "Date") NullableDate = Picker.Date;
            else if (propertyName == "NullableDate")
            {
                Picker.Date = NullableDate ?? Picker.Date;
                UpdateDate();
            }
        }

        void Picker_Unfocused(object sender, FocusEventArgs e)
        {
            var tmp = Picker.Date;
            Picker.Date = DateTime.MinValue;
            Picker.Date = tmp;
        }
    }
}