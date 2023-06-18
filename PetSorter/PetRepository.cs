using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace PetSorter
{
    public static class PetRepository 
    {
        const string apiUrl = "https://petstore.swagger.io/v2/pet/findByStatus";
        const string apiKey = "special-key";
        /// <summary>
        /// List all pets that match given status on the available url.
        /// </summary>
        /// <param name="status"></param>
        /// <returns>All pets that currently match that status, or empty list if none.</returns>
        public static List<Pet> GetPets(Status status)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("api_key", apiKey);
            List<Pet> pets = new();

            HttpResponseMessage response = client.GetAsync(apiUrl + (status == Status.All ? "" 
                : "?status=" + status.ToString().ToLowerInvariant())).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                pets = JsonConvert.DeserializeObject<List<Pet>>(json) ?? pets;
            }
            return pets;
        }

        public static void PrintPets(IOrderedEnumerable<Pet> pets)
        {
            foreach (var pet in pets)
            {
                Console.WriteLine($"Category: {(pet.Category == null || pet.Category?.Id == 0 ? "Unknown" : pet.Category?.Name)}, Name: {pet.Name}, Pet ID: {pet.Id}");
            }
        }

        public static IOrderedEnumerable<Pet> SortPetsByCategoryAndName(List<Pet> pets, bool descendingName)
        {
            if (descendingName)
            {
                return pets.OrderBy(pet => pet.Category?.Name ?? "").ThenByDescending(pet => pet.Name);
            }
            else
            {
                return pets.OrderBy(pet => pet.Category?.Name ?? "").ThenBy(pet => pet.Name);
            }
        }
    }
}