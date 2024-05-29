using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PREFINAL_ASSIGNMENT_TWO.Models
{
    public class Pokemon
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }

    public class PokemonApiClient
    {
        private readonly HttpClient _httpClient;

        public PokemonApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        }

        public async Task<Pokemon> GetPokemonAsync(int id)
        {
            var response = await _httpClient.GetAsync($"pokemon/{id}");
            if (response.IsSuccessStatusCode)
            {
                var pokemon = await response.Content.ReadAsAsync<Pokemon>();
                pokemon.ImageUrl = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{id}.png";
                return pokemon;
            }
            else
            {
                throw new Exception($"Failed to fetch Pokemon with ID: {id}");
            }
        }
    }
}
