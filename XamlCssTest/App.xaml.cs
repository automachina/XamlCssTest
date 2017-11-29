using System;

using Xamarin.Forms;
using XamlCssTest.Views;
using XamlCSS;
using XamlCSS.XamarinForms;

namespace XamlCssTest
{
    public partial class App : Application
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            MainPage = new MainPage();
        }

        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";

        public App()
        {
            InitializeComponent();
            //Css.Initialize(this);

            //var styleSheet = XamlCSS.CssParsing.CssParser.Parse(CurrentStyle);
            //Css.SetStyleSheet(this, styleSheet);

            //MainPage = new NavigationPage(new StartPage { PageNumber = 1 });
            MainPage = new MainPage();
        }

        public static string CurrentStyle = @"
.important
{
    BackgroundColor: Red;
    FontSize: 25;
    WidthRequest: 200;
}
Label
{
    TextColor: Red;
    FontSize: 25;
    &.title
    {
        TextColor: Green;
    }
}
Button
{
    TextColor: Blue;
    BackgroundColor: Black;
    FontSize: 25;
}
BoxView
{
    Color: Red;
    &.box
    {
        Opacity: .5;
    }
}
";
    }
}
