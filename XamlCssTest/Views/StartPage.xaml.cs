using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamlCssTest.Views
{
    public partial class StartPage : ContentPage
    {
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (PageNumber < 3)
                await Navigation.PushAsync(new StartPage { PageNumber = PageNumber + 1 });
            else
                await Navigation.PushAsync(new MainPage());
        }

        public StartPage()
        {
            InitializeComponent();
            Title = $"Page {PageNumber}";
        }

        int _pageNumber; public int PageNumber
        {
            get => _pageNumber;
            set
            {
                if (value == _pageNumber) return;

                _pageNumber = value;
                Title = $"Page {_pageNumber}";
            }
        }
    }
}
