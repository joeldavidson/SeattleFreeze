using System;
using System.Collections.Generic;
using System.Text;
using PrimeAssault.Models;

namespace PrimeAssault.ViewModels
{
    public class PlayerCharacterViewModel : BaseViewModel
    {
        public PlayerCharacterModel Data { get; set; }

        public PlayerCharacterViewModel(PlayerCharacterModel data = null)
        {
            Title = data?.Name;
            Data = data;
        }
    }
}
