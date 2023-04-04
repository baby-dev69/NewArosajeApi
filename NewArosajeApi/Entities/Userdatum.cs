using System;
using System.Collections.Generic;

namespace NewArosajeApi.Entities;

public partial class Userdatum
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? Age { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? Status { get; set; }

    public string? UserAddress { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public int CityId { get; set; }

    public int TypeId { get; set; }
}
