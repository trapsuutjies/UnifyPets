# UnifyPets

Further steps to ensure the application is ready for enterprise:
1. Expand the repository with a constructor or parameter to allow switching endpoints (for example dev, staging and live)
2. Optionally use a database lookup for URL's and keys to ensure code is dynamic, API keys are secure and updating either doesn't require updating code.
3. Expand class definitions to specify field property limitations, which attributes are required, etc.
4. Add additional methods, such as list by category.
5. Create a URL checker to ensure messages are only sent to valid URL's.
6. Implement security beyond the default API key. Certain pet data may belong to certain companies and they may wish to control visibility.
7. Implement authorization to ensure only users with appropriate access can create, edit or delete pets.

ChatGPT transcript below:

Please write a C# console application to list all available pets from the endpoint https://petstore.swagger.io/v2/pet/findByStatus using API key special-key in the header for authorization. The results must be sorted by category and displayed in reverse order by name.
ChatGPT
Sure! Here's a C# console application that fetches the list of available pets from the provided endpoint, sorts them by category, and displays them in reverse order by name. It uses the HttpClient class to make the HTTP request and Newtonsoft.Json library to deserialize the JSON response.

First, make sure to install the Newtonsoft.Json package in your project. You can do this by right-clicking on the project in Visual Studio and selecting "Manage NuGet Packages." Search for "Newtonsoft.Json" and click on "Install" to add the package.

Next, you can use the following code:

csharp
Copy code
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace PetStoreConsoleApp
{
    public class Pet
    {
        public long Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        // Add other properties as needed
    }

    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            const string apiUrl = "https://petstore.swagger.io/v2/pet/findByStatus";
            const string apiKey = "special-key";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("api_key", apiKey);

            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<Pet> pets = JsonConvert.DeserializeObject<List<Pet>>(json);

                // Sort pets by category
                var sortedPets = pets.OrderBy(pet => pet.Category.Name).ToList();

                // Display pets in reverse order by name
                for (int i = sortedPets.Count - 1; i >= 0; i--)
                {
                    Pet pet = sortedPets[i];
                    Console.WriteLine($"Pet ID: {pet.Id}, Category: {pet.Category.Name}, Name: {pet.Name}");
                }
            }
            else
            {
                Console.WriteLine($"Failed to retrieve pets. Status code: {response.StatusCode}");
            }

            Console.ReadLine();
        }
    }
}
Make sure to replace the value of apiKey with the actual API key you have. This code sends an HTTP GET request to the specified endpoint with the required API key in the header. It then deserializes the JSON response into a list of Pet objects and sorts them by category. Finally, it displays the sorted pets in reverse order by name.

Please note that this code assumes that the response from the API matches the structure defined in the Pet and Category classes. You may need to adjust the classes based on the actual response structure to ensure proper deserialization.

I hope this helps! Let me know if you have any further questions.
