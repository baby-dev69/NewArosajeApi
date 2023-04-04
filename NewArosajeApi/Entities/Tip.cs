using System;
using System.Collections.Generic;

namespace NewArosajeApi.Entities;

public partial class Tip
{
    public int TipId { get; set; }

    public string? TipDescription { get; set; }

    public int UserId { get; set; }
}
