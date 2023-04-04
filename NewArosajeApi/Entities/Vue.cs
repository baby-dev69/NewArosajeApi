using System;
using System.Collections.Generic;

namespace NewArosajeApi.Entities;

public partial class Vue
{
    public int UserId { get; set; }

    public int MessageId { get; set; }

    public DateTime? MessageDate { get; set; }
}
