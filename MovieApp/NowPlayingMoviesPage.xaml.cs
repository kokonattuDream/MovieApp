using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MovieApp.Models;
using MovieApp.Services;
using Xamarin.Forms;

namespace MovieApp
{
    public partial class NowPlayingMoviesPage : ContentPage
    {
        public ObservableCollection<NowPlayingMovie> NowPlayingMovies;

        private static bool First = true;

        public NowPlayingMoviesPage()
        {
            InitializeComponent();
            NowPlayingMovies = new ObservableCollection<NowPlayingMovie>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (First)
            {
                ApiServices apiServices = new ApiServices();

                var movies = await apiServices.GetNowPlayingMovies();
                foreach (var movie in movies)
                {
                    NowPlayingMovies.Add(movie);
                }

                LvNowPlaying.ItemsSource = NowPlayingMovies;
            }
            First = false;
        }

        private void onItemSelected(object sender, SelectedItemChangedEventArgs e){

            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }

            var movie = e.SelectedItem as NowPlayingMovie;

            Navigation.PushAsync(new NowPlayingDetailPage(movie));
        }
    }
}
