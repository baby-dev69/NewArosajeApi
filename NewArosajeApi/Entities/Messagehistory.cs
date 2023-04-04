using System;
using System.Collections.Generic;

namespace NewArosajeApi.Entities;

public partial class Messagehistory
{
    public int MessageId { get; set; }

    public DateTime? SendDate { get; set; }

    public string? Content { get; set; }
}
