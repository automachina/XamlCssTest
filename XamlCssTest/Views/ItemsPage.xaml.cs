using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamlCSS.CssParsing;
using XamlCSS.XamarinForms;

namespace XamlCssTest
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
            
        }
    }
    
    public static class ItemCatcher
    {
        public static readonly BindableProperty IncludeProperty =
            BindableProperty.CreateAttached(
                "Include",
                typeof(bool),
                typeof(VisualTreeCell),
                false,
                propertyChanged: OnIncludeChanged);

        public static bool GetInclude(BindableObject view)
        {
            return (bool)view.GetValue(IncludeProperty);
        }

        public static void SetInclude(BindableObject view, bool value)
        {
            view.SetValue(IncludeProperty, value);
        }

        static void OnIncludeChanged(BindableObject view, object oldValue, object newValue)
        {
            var entry = view as ViewCell;
            if (entry == null)
            {
                return;
            }

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                var label = (entry.View as StackLayout).Children.First() as Label;
                if (label.Style == null)
                {
                    label.Style = App.Current.Resources["TitleLabel"] as Style;
                }
                else
                {
                    label.Style = null;
                }

                return true;
            });
        }
    }
}
