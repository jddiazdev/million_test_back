using System.ComponentModel.DataAnnotations;

namespace million.application.dto;

public class PropertyTraceDto
{
  [Required(ErrorMessage = "El id de la  de la propiedad es obligatorio")]
  public string propertyId { get; set; } = "";


  [Required(ErrorMessage = "El dateSale de la  de la propiedad es obligatorio")]
  public DateTime dateSale { get; set; }


  [Required(ErrorMessage = "El name de la  de la propiedad es obligatorio")]
  public string name { get; set; } = "";


  [Required(ErrorMessage = "El value de la  de la propiedad es obligatorio")]
  public string value { get; set; } = "";

  [Required(ErrorMessage = "El tax de la  de la propiedad es obligatorio")]
  public decimal tax { get; set; } = 0;




}
