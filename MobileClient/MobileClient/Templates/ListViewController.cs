using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MobileClient.Models;
using MobileClient.Services;
using MobileClient.Views;
using StudentSurveySystem.ApiClient.Model;
using Xamarin.Forms;

namespace MobileClient.Controllers
{
    public class ListViewController<T>
    {
        public ListViewController(Func<string, int?, int?, Task<List<T>>> loadingFunction, ListView listView, SearchBar searchBar)
        {
            ListView = listView;
            LoadingFunction = loadingFunction;
            SearchBar = searchBar;
            searchBar.SearchButtonPressed += SearchBar_OnSearchButtonPressed;
            searchBar.TextChanged += SearchBar_OnTextChanged;
            LoadData();
        }

        public ListView ListView { get; set; }
        public SearchBar SearchBar { get; set; }
        public InfiniteScrollList<T> Items { get; set; }
        public int PageSize { get; set; } = 20;

        public Func<string, int?, int?, Task<List<T>>> LoadingFunction { get; set; }

        public async void ReloadData()
        {
            SearchBar.Text = "";
            LoadData();
        }

        public async void LoadData(string filter = "")
        {
            using (UserDialogs.Instance.Loading("Loading"))
            {
                Items = new InfiniteScrollList<T>(PageSize)
                {
                    OnLoadMore = async () =>
                    {
                        var page = Items.Count == 0 ? 0 : (Items.Count / PageSize) + 1;
                        var items = await LoadingFunction(filter, page, PageSize);

                        return items;
                    }
                };
                await Items.LoadMoreAsync();
                ListView.ItemsSource = Items;
            }
        }

        public void SearchBar_OnSearchButtonPressed(object sender, EventArgs e)
        {
            var searchBar = (SearchBar)sender;
            LoadData(searchBar.Text);

        }

        public void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchBar = (SearchBar)sender;
            if (searchBar.Text == "")
                LoadData(searchBar.Text);
        }
    }
}