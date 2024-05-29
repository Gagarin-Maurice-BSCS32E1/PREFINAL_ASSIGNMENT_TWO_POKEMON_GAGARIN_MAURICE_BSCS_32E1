using Microsoft.AspNetCore.Mvc;
using PREFINAL_ASSIGNMENT_TWO.Models;
using System.Diagnostics;

namespace PREFINAL_ASSIGNMENT_TWO.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonApiClient _pokemonApiClient;

        public PokemonController()
        {
            _pokemonApiClient = new PokemonApiClient();
        }

        public async Task<ActionResult> Index(int id)
        {
            var pokemon = await _pokemonApiClient.GetPokemonAsync(id);
            return View(pokemon);
        }
    }
}
