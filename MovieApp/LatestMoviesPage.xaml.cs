using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using MovieApp.Models;
using MovieApp.Services;

using ItemTappedEventArgs = Syncfusion.ListView.XForms.ItemTappedEventArgs;

namespace MovieApp
{
    public partial class LatestMoviesPage : ContentPage
    {
        public ObservableCollection<LatestMovie> LatestMovies;
        private static bool First = true;
        public LatestMoviesPage()
        {
            InitializeComponent();
            LatestMovies = new ObservableCollection<LatestMovie>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (First)
            {
                ApiServices apiServices = new ApiServices();
                var latestMovies = await apiServices.GetLatestMovies();
                foreach (var latestMovie in latestMovies)
                {
                    LatestMovies.Add(latestMovie);
                }

                LvLatest.ItemsSource = LatestMovies;
            }

            First = false;
        }

        private void LvLatest_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var items = e.ItemData as LatestMovie;
            if (items != null)
            {
                Navigation.PushAsync(new VideoPage(items.MovieTrailor));
            }
        }
    }
}
