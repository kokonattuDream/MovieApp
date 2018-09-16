using System;

using Xamarin.Forms;

namespace MovieApp
{
    public class BookTicketPage : ContentPage
    {
        public BookTicketPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

