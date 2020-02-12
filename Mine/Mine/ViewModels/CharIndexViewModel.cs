using PrimeAssault.Services;
using PrimeAssault.Models;
using PrimeAssault.Views;
using System.Diagnostics;
using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;

namespace PrimeAssault.ViewModels
{
    public class CharIndexViewModel : BaseViewModel
    {


        public CharIndexViewModel()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
            };
        }
    }
}