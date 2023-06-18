using PetSorter;

namespace unifyPetsTests
{
    public class Tests
    {
        [Test]
        public void DescendingTest()
        {
            //Arrange
            var pets = new List<Pet>();
            var category = new Category() { Id = 1, Name = "Test category" };
            var ascendingFirstName = "AAA";
            var descendingFirstName = "ZZZ";
            pets.Add(new Pet() { Id = 2, Name = ascendingFirstName, Category = category });
            pets.Add(new Pet() { Id = 1, Name = descendingFirstName, Category = category });

            //Act
            var sortedPets = PetRepository.SortPetsByCategoryAndName(pets, descendingName: true);

            //Assert
            Assert.That(sortedPets.First().Name, Is.EqualTo(descendingFirstName));
        }
        [Test]
        public void AscendingTest()
        {
            //Arrange
            var pets = new List<Pet>();
            var category = new Category() { Id = 1, Name = "Test category" };
            var ascendingFirstName = "AAA";
            var descendingFirstName = "ZZZ";
            pets.Add(new Pet() { Id = 2, Name = ascendingFirstName, Category = category });
            pets.Add(new Pet() { Id = 1, Name = descendingFirstName, Category = category });

            //Act
            var sortedPets = PetRepository.SortPetsByCategoryAndName(pets, descendingName: false);

            //Assert
            Assert.That(sortedPets.First().Name, Is.EqualTo(ascendingFirstName));
        }
    }
}