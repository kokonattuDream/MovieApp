using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovieApp.Models;

namespace MovieApp
{
    public partial class NowPlayingDetailPage : ContentPage
    {
        public NowPlayingDetailPage(NowPlayingMovie movie)
        {
            InitializeComponent();

            LblMovieName.Text = movie.MovieName;
            ImgMovieConver.Source = movie.CoverImage;
            LblDuration.Text = movie.Duration;
            LblLanguage.Text = movie.Language;
            LblMovieType.Text = movie.PlayingDate.ToShortDateString();
            LblCast.Text = movie.Cast;
            LblDescription.Text = movie.Description;
            LblRatedLevel.Text = movie.RatedLevel;
        }
    }
}
