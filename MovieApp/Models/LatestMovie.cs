﻿using System;
namespace MovieApp.Models
{
    public class LatestMovie
    {
        public int MovieId { get; set; }

        public string MovieName { get; set; }

        public string Cast { get; set; }

        public string Director { get; set; }

        public string Description { get; set; }

        public string Language { get; set; }

        public DateTime ReleaseDate { get; set; }

        public double Rating { get; set; }

        public string Genre { get; set; }

        public string TrailorLink { get; set; }

        public string Logo { get; set; }

        public object LogoFile { get; set; }

        public string MovieTrailor
        {
            get
            {
                return TrailorLink.Replace("watch?v=", "embed/");
            }
        }

        public string CoverImage
        {
            get
            {
                return String.Format("http://colosseum.somee.com/{0}", Logo.Substring(1));
            }
        }
    }
}
