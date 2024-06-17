using Pokemones.Models;
using Pokemones.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Pokemones
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private List<PokemonItem> _listado_pokemones;

        public List<PokemonItem> listado_pokemones
        {
            get { return _listado_pokemones; }
            set
            {
                _listado_pokemones = value;
                OnPropertyChanged();
            }
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            CargarData();
        }

        public async void CargarData()
        {
            PokemonServices poke_services = new PokemonServices();
            listado_pokemones = await poke_services.DevuelveListadoPokemones();

            Debug.WriteLine("");
            Debug.WriteLine(JsonConvert.SerializeObject(listado_pokemones));
        }

        public void VerInfoPokemon(object sender, SelectedItemChangedEventArgs e)
        {
            PokemonItem poke_info = (PokemonItem)e.SelectedItem;
            Navigation.PushAsync(new ResumenPokemon(poke_info.url));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
