using System.Collections.Generic;
using System.Linq;
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
        public MultiSelectObservableCollection<string> PickedItems { get; set; } = new MultiSelectObservableCollection<string>();
        public string Text => string.Join(", ", PickedItems);

        public List<string> ItemsSource
        {
            get => _itemsSource;
            set
            {
                _itemsSource = value;
                ItemList = new MultiSelectObservableCollection<string>(ItemsSource);
            }
        }

        public MultiSelectPicker()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void Entry_OnFocused(object sender, FocusEventArgs e)
        {
            Navigation.PushModalAsync(new MultiSelectDialog(ItemList, PickedItems));
        }
    }
}