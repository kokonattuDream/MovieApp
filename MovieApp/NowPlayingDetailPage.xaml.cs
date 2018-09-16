using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovieApp.Models;

namespace MovieApp
{
    public partial class NowPlayingDetailPage : ContentPage
    {
        private string _trailorLink;
        private string _time1;
        private string _time2;
        private string _time3;
        private string _ticketPrice;

        public NowPlayingDetailPage(NowPlayingMovie movie)
        {
            InitializeComponent();



            LblMovieName.Text = movie.MovieName;
            ImgMovieCover.Source = movie.CoverImage;
            LblDuration.Text = movie.Duration;
            LblLanguage.Text = movie.Language;
            LblMovieType.Text = movie.PlayingDate.ToShortDateString();
            LblCast.Text = movie.Cast;
            LblDescription.Text = movie.Description;
            LblRatedLevel.Text = movie.RatedLevel;

            _trailorLink = movie.TrailorLink;
            _time1 = movie.ShowTime1.ToShortTimeString();
            _time2 = movie.ShowTime2.ToShortTimeString();
            _time3 = movie.ShowTime3.ToShortTimeString();
            _ticketPrice = movie.TicketPrice;
        }

        private void PlayVideo_OnTapped(object sender, EventArgs e){
            Navigation.PushAsync(new VideoPage(_trailorLink));
        }

        private void BtnBookTicket_OnClicked(object sender, EventArgs e){
            Navigation.PushAsync(new BookTicketPage(ImgMovieCover.Source, LblMovieName.Text, LblPlayingDate.Text, _time1, _time2, _time3, _ticketPrice));
        }
    }
}

