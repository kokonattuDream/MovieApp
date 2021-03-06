﻿using System;
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
                BusyIndicator.IsRunning = false;
            }
            First = false;
        }

        private void LvNowPlaying_OnItemSelected(object sender, SelectedItemChangedEventArgs e){
            
            var movie = e.SelectedItem as NowPlayingMovie;

            if (movie != null)
            {
                Navigation.PushAsync(new NowPlayingDetailPage(movie));
            }

            ((ListView)sender).SelectedItem = null;
        }
    }
}
