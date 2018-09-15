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

        public NowPlayingMoviesPage()
        {
            InitializeComponent();
            NowPlayingMovies = new ObservableCollection<NowPlayingMovie>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ApiServices apiServices = new ApiServices();

            var movies = await apiServices.GetNowPlayingMovies();
            foreach(var movie in movies){
                NowPlayingMovies.Add(movie);
            }

            LvNowPlaying.ItemsSource = NowPlayingMovies;
        }
    }
}
