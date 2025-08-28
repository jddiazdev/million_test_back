using System.ComponentModel.DataAnnotations;

namespace million.application.dto;

public class PropertyDto
{


  [Required(ErrorMessage = "El id del owner de la propiedad es obligatorio")]
  public string ownerId { get; set; } = "";

  [Required(ErrorMessage = "El nombre de la propiedad es obligatorio")]
  public string name { get; set; } = "";


  [Required(ErrorMessage = "La dirección es obligatoria")]
  public string address { get; set; } = "";

  [Required(ErrorMessage = "El precio es obligatorio")]
  public decimal price { get; set; } = 0;

  [Required(ErrorMessage = "El codeInternal es obligatorio")]
  public string codeInternal { get; set; } = "";

  [Required(ErrorMessage = "El año es obligatorio")]
  public string year { get; set; } = "";



}
