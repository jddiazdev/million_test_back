using System;
using System.ComponentModel.DataAnnotations;

namespace million.application.dto;

public class PropertyImgDto
{

  [Required(ErrorMessage = "El id de la  de la propiedad es obligatorio")]
  public string propertyId { get; set; } = "";

  [Required(ErrorMessage = "El archivo de la propiedad es obligatorio")]
  public string file { get; set; } = "";

  public string? enabled { get; set; } = "";

}
