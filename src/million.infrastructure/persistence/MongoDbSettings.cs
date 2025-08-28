using System;

namespace million.infrastructure.persistence;

public class MongoDbSettings
{
  public string ConnectionString { get; set; } = null!;
  public string DatabaseName { get; set; } = null!;

}
