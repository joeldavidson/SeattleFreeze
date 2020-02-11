using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeAssault.Models;
using PrimeAssault.ViewModels;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrimeAssault.Views
{
    [DesignTimeVisible(false)]

    public partial class CharCreatePage : ContentPage
	{

        // The item to create
        PlayerCharacterViewModel ViewModel { get; set; }

        public CharCreatePage ()
		{
			InitializeComponent ();


        }
	}
}