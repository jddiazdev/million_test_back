using System;
using System.ComponentModel.DataAnnotations;

namespace million.application.dto;

public class OwnerDto
{
  [Required(ErrorMessage = "El nombre del owner es obligatorio")]
  public string name { get; set; } = "";

  [Required(ErrorMessage = "la direccion del  owner es obligatorio")]
  public string address { get; set; } = "";

  [Required(ErrorMessage = "la foto del owner es obligatorio")]
  public string photo { get; set; } = "";


  [Required(ErrorMessage = "la fecha de nacimiento del owner es obligatorio")]
  public DateTime birtday { get; set; }

}
