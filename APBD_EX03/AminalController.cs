using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace APBD_EX03;

[ApiController]
[Route("/api/animals")]
public class AnimalController : Controller
{
    private readonly IAnimalDS _animalDS;

    public AnimalController(IAnimalDS animalDS)
    {
        _animalDS = animalDS;
    }

    [HttpGet]
    public IActionResult GetAnimals(string? orderBy)
    {
        return Ok(_animalDS.GetAnimals(orderBy));
    }

    [HttpPost]
    public IActionResult UpdateAnimal([FromBody] Animal animal)
    {
        _animalDS.addAnimal(animal);
        return Ok();
    }

    [HttpPut("{idAnimal}")]
    public IActionResult PutAnimalById([FromRoute]string idAnimal, [FromBody] Animal animal)
    {
        _animalDS.updateAnimal(idAnimal, animal);
        return Ok();
    }

    [HttpDelete("{idAnimal}")]
    public IActionResult DeleteAnimal([FromRoute]string idAnimal)
    {
        _animalDS.deleteAnimal(idAnimal);
        return Ok();
    }

}
