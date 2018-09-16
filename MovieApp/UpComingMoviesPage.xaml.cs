﻿using System;
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
    public partial class UpComingMoviesPage : ContentPage
    {
        public ObservableCollection<UpComingMovie> UpComingMovies;
        private static bool First = true;

        public UpComingMoviesPage()
        {
            InitializeComponent();
            UpComingMovies = new ObservableCollection<UpComingMovie>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (First)
            {
                ApiServices apiServices = new ApiServices();
                var upComingMovies = await apiServices.GetUpComingMovies();
                foreach (var upComingMovie in upComingMovies)
                {
                    UpComingMovies.Add(upComingMovie);
                }

                LvUpComing.ItemsSource = UpComingMovies;
            }

            First = false;
        }

        private void LvUpComing_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var items = e.ItemData as UpComingMovie;
            if (items != null)
            {
                Navigation.PushAsync(new VideoPage(items.MovieTrailor));
            }
        }
    }
}
