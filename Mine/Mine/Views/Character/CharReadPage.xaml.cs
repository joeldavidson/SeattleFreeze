using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PrimeAssault.Models;
using PrimeAssault.ViewModels;

namespace PrimeAssault.Views.Character
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharReadPage : ContentPage
    {

        PlayerCharacterViewModel viewModel;
        public CharReadPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new PlayerCharacterViewModel();
        }

        async void Update_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new CharUpdatePage(new ItemViewModel(viewModel.Data))));
            //await Navigation.PopAsync();
        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new CharDeletePage(new PlayerCharacterViewModel(viewModel.Data))));
            //await Navigation.PopAsync();
        }
    }
}