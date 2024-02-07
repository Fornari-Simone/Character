using Character.ClientHTTP.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Character.ClientHTTP
{
    public class ClientHTTP : IClientHTTP
    {
        private readonly HttpClient _httpClient;
        public ClientHTTP(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult?> Ascend(int ID, CancellationToken cancellation = default)
        {
            var response = await _httpClient.PatchAsync($"/Character/Ascend", JsonContent.Create(new { ID }), cancellation);
            return await response.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>(cancellationToken: cancellation);
        }

        public async Task<IActionResult?> LevelUP(int ID, int level, CancellationToken cancellation = default)
        {
            var response = await _httpClient.PatchAsync($"/Character/LevelUP", JsonContent.Create(new { ID, level }), cancellation);
            return await response.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<IActionResult>(cancellationToken: cancellation);
        }
    }
}
