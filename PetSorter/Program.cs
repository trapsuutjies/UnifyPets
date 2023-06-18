using PetSorter;
using System.Collections.Generic;

namespace PetSorter
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            var availablePets = PetRepository.GetPets(Status.Available);
            if (availablePets.Count > 0 ) 
            {
                PetRepository.PrintPets(PetRepository.SortPetsByCategoryAndName(availablePets, descendingName: true));
            }
            else
            {
                Console.WriteLine("No available pets found.");
            }
            Console.ReadKey();
        }
    }
}