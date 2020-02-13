using System;
using System.Collections.Generic;
using System.Text;
using PrimeAssault.Models;

namespace PrimeAssault.ViewModels
{
    public class MonsterViewModel : BaseViewModel
    {
        public MonsterModel Data { get; set; }

        public MonsterViewModel(MonsterModel data = null)
        {
            Title = data?.Name;
            Data = data;
        }
    }
}
