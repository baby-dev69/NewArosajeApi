using System;
using System.Collections.Generic;

namespace NewArosajeApi.Entities;

public partial class Plantimage
{
    public int ImageId { get; set; }

    public string? Image { get; set; }

    public DateTime? ImageDate { get; set; }

    public int PlantId { get; set; }
}
