namespace APBD_EX03;

public interface IAnimalDS
{
    public List<Animal> GetAnimals (string orderBy);
    void updateAnimal(string animalId, Animal animal);
    void deleteAnimal(string animalId);
    void addAnimal(Animal animal);
}
