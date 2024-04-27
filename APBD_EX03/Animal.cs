using System.ComponentModel.DataAnnotations;

namespace APBD_EX03;

public class Animal
{
    [Required(ErrorMessage = "Animal id required")]
    public int IdAnimal { get; set; }

    [Required(ErrorMessage ="Animal name is required")]
    [MaxLength(200, ErrorMessage ="Max length is 200")]
    public string Name { get; set; }

    [MaxLength(200,ErrorMessage ="Max length is 200")]
    public string Description { get; set; }

    [Required(ErrorMessage ="Category required")]
    [MaxLength(200, ErrorMessage = "Max length is 200")]
    public string Category { get; set; }

    [Required(ErrorMessage = "Area required")]
    [MaxLength(200, ErrorMessage = "Max length is 200")]
    public string Area { get; set; }
}