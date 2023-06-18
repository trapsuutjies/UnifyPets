namespace PetSorter
{
    public class Pet
    {
        public long Id { get; set; }
        public Category? Category { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}