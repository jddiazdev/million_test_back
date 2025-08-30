using System;
using System.ComponentModel.DataAnnotations;

namespace million.application.dto;

public class PropertyDetailDto
{

  [Required(ErrorMessage = "El id de la propiedad es obligatorio")]
  public string propertyId { get; set; } = "";

  [Required(ErrorMessage = "El campo bedrooms de la de la propiedad es obligatorio")]
  public int bedrooms { get; set; } = 0;

  [Required(ErrorMessage = "El campo bathrooms de la de la propiedad es obligatorio")]
  public int bathrooms { get; set; } = 0;

  [Required(ErrorMessage = "El campo areaM2 de la de la propiedad es obligatorio")]
  public int areaM2 { get; set; } = 0;

  [Required(ErrorMessage = "El campo garage de la de la propiedad es obligatorio")]
  public bool garage { get; set; } = false;

  [Required(ErrorMessage = "El campo yearBuilt de la de la propiedad es obligatorio")]
  public int yearBuilt { get; set; } = 0;

  [Required(ErrorMessage = "El campo description de la de la propiedad es obligatorio")]
  public string description { get; set; } = "";

}
