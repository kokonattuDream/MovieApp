using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MovieApp
{
    public partial class VideoPage : ContentPage
    {
        public VideoPage(string trailorLink)
        {
            InitializeComponent();

            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @"<html><body>  <div style=' position: relative; padding-bottom: 56.25%; padding-top: 25px;'> <iframe style='position: absolute; top: 0; left: 0; width: 100%; height: 100%;'  src='" + trailorLink + "' frameborder='0' allowfullscreen></iframe></div> </body></html>";
            Browser.Source = htmlSource;
        }
    }
}
