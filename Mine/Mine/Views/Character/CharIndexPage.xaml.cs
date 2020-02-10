using System;
using System.ComponentModel;
using Xamarin.Forms;

using PrimeAssault.Models;
using PrimeAssault.ViewModels;

namespace PrimeAssault.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer

    /// <summary>
    /// Index Page
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class CharIndexPage : ContentPage
    {
        // The view model, used for data binding
        ItemIndexViewModel viewModel;

        /// <summary>
        /// Constructor for Index Page
        /// 
        /// Get the ItemIndexView Model
        /// </summary>
        public CharIndexPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemIndexViewModel();
        }
        /// <summary>
        /// The row selected from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        async void OnCharSelected(object sender, SelectedItemChangedEventArgs args)
        {
            BaseCharacterModel Char = args.SelectedItem as BaseCharacterModel;
            if (Char == null)
            {
                return;
            }

            // Open the Read Page
            //await Navigation.PushAsync(new ItemReadPage(new ItemViewModel(Char)));

            // Manually deselect item.
            CharListView.SelectedItem = null;
        }

        /// <summary>
        /// Call to Add a new record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void AddChar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ItemCreatePage(new ItemViewModel())));
        }

        /// <summary>
        /// Refresh the list on page appearing
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // If no data, then reload the data
            if (viewModel.Dataset.Count == 0)
            {
                viewModel.LoadDatasetCommand.Execute(null);
            }
        }
    }
}