using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using MobileClient.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;
using Xamarin.Forms.Xaml;

namespace MobileClient.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MultiSelectPicker : ContentView
    {
        private List<string> _itemsSource;

        public MultiSelectObservableCollection<string> ItemList { get; set; }
        public string Text => ItemList != null && ItemList.SelectedItems.Any() ? "-" + string.Join("\n-", ItemList.SelectedItems) : "";

        public List<string> ItemsSource
        {
            get => _itemsSource;
            set
            {
                _itemsSource = value;
                ItemList = new MultiSelectObservableCollection<string>(ItemsSource);
            }
        }

        public List<string> SelectedValues => ItemList.SelectedItems.ToList();

        public MultiSelectPicker()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void Editor_OnFocused(object sender, FocusEventArgs e)
        {
            Navigation.PushAsync(new MultiSelectDialog(ItemList, new Command(() => OnPropertyChanged(nameof(Text)))));
        }
    }
}