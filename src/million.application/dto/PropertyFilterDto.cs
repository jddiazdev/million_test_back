using System;

namespace million.application.dto;

public class PropertyFilterDto
{
  public string? name { get; set; }
  public string? address { get; set; }
  public decimal? minPrice { get; set; }
  public decimal? maxPrice { get; set; }
}
