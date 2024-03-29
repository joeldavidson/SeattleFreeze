﻿using System;
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
        CharIndexViewModel viewModel;

        ItemIndexViewModel ItemViewModel;

        /// <summary>
        /// Constructor for Index Page
        /// 
        /// Get the ItemIndexView Model
        /// </summary>
        public CharIndexPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CharIndexViewModel();
            ItemViewModel = new ItemIndexViewModel();
        }
        /// <summary>
        /// The row selected from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        async void OnCharSelected(object sender, SelectedItemChangedEventArgs args)
        {
            PlayerCharacterModel Char = args.SelectedItem as PlayerCharacterModel;
            if (Char == null)
            {
                return;
            }

            // Open the Read Page
            await Navigation.PushAsync(new CharReadPage(new PlayerCharacterViewModel(Char)));

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

            await Navigation.PushModalAsync(new NavigationPage(new CharCreatePage(new PlayerCharacterViewModel())));
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

        async void Attack_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Character Attack", "The Attack stat offers blah bla blah", "Dismiss");
        }

        async void Defense_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Character Defense", "The Defense stat offers blah bla blah", "Dismiss");
        }

        async void RangedDefense_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Character Ranged Defense", "The Ranged Defense stat offers blah bla blah", "Dismiss");
        }

        async void Speed_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Character Speed", "The Speed stat offers blah bla blah", "Dismiss");
        }

        async void Head_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Character Head Item", "blah bla blah", "Dismiss");
        }

        async void Torso_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Character Torso Item", "blah bla blah", "Dismiss");
        }

        async void RightHand_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Character Right Hand Item", "blah bla blah", "Dismiss");
        }

        async void LeftHand_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Character Left Hand Item", "blah bla blah", "Dismiss");
        }
        async void Boots_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Character Boot Item", "blah bla blah", "Dismiss");
        }

        async void Ring1_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Character Ring 1 Item", "blah bla blah", "Dismiss");
        }

        async void Ring2_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ItemReadPage(new ItemViewModel())));
        }
    }
}