namespace million.domain.entities;

public class Owner : BaseEntity
{
  public required string name { get; set; }
  public required string address { get; set; }
  public required string photo { get; set; }
  public required DateTime birtday { get; set; }

}
