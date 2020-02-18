using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrimeAssault.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrimeAssaultPage : ContentPage
    {
        public PrimeAssaultPage()
        {
            InitializeComponent();

        }
        async void PrimeAssaultButton_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("SU", "Go RedHawks", "OK");
        }
    }

}
    