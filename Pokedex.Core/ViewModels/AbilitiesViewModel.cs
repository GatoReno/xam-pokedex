using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Pokedex.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Core.ViewModels
{
    

    public class AbilitiesViewModel : MvxViewModel, IMvxViewModel<PokemonAbilitiesModel>
    {
        private string _description;
        private string _title;

        public PokemonAbilitiesModel PokeAbs { get; private set; }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

 
        public AbilitiesViewModel()
        {
            Title = "Abilities 👾";
        }

        public void Prepare(PokemonAbilitiesModel parameter)
        {
            PokeAbs = parameter;
            Title = "Abilities 👾";        
            Description = parameter.EffectEntries[0].Effect 
                + " " + parameter.EffectEntries[0].ShortEffect;
        }

        
    }

}
