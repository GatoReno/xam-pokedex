using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Core.Models
{
   using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PokemonAbilitiesModel
    {
        [JsonProperty("effect_changes")]
        public object[] EffectChanges { get; set; }

        [JsonProperty("effect_entries")]
        public EffectEntry[] EffectEntries { get; set; }

        [JsonProperty("flavor_text_entries")]
        public FlavorTextEntry[] FlavorTextEntries { get; set; }

        [JsonProperty("generation")]
        public Generation Generation { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("is_main_series")]
        public bool IsMainSeries { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("names")]
        public Name[] Names { get; set; }


        // no se si esto esta bien o es mala practica
        [JsonProperty("pokemon")]
        public Pokemon_Prop[] Pokemon { get; set; }
    }

    public partial class EffectEntry
    {
        [JsonProperty("effect")]
        public string Effect { get; set; }

        [JsonProperty("language")]
        public Generation Language { get; set; }

        [JsonProperty("short_effect")]
        public string ShortEffect { get; set; }
    }

    public partial class Generation
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class FlavorTextEntry
    {
        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }

        [JsonProperty("language")]
        public Generation Language { get; set; }

        [JsonProperty("version_group")]
        public Generation VersionGroup { get; set; }
    }

    public partial class Name
    {
        [JsonProperty("language")]
        public Generation Language { get; set; }

        [JsonProperty("name")]
        public string NameName { get; set; }
    }

    public partial class Pokemon_Prop
    {
        [JsonProperty("is_hidden")]
        public bool IsHidden { get; set; }

        [JsonProperty("pokemon")]
        public Generation PokemonPokemon { get; set; }

        [JsonProperty("slot")]
        public long Slot { get; set; }
    }

}
