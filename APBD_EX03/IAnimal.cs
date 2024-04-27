namespace APBD_EX03;

public interface IAnimalRepo
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    void AddAnimal(Animal animal);
    void UpdateAnimal(Animal animal);
    void DeleteAnimal(int idAnimal);
}
