using System;
using System.Collections.Generic;

namespace NewArosajeApi.Entities;

public partial class Plant
{
    public int PlantId { get; set; }

    public string? Name { get; set; }

    public string? Species { get; set; }

    public string? PlantDescription { get; set; }

    public string? PlantAddress { get; set; }

    public int UserId { get; set; }
}
