using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemones.Models
{
    internal class ListPokemons
    {
        public int count { get; set; }
        public string next { get; set; }

        public string previuos { get; set; }
        public List<PokemonItem> results { get; set; }

    }
}
