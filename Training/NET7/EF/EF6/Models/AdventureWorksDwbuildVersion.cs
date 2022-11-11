using System;
using System.Collections.Generic;

namespace EF6.Models;

public partial class AdventureWorksDwbuildVersion
{
    public string? Dbversion { get; set; }
    public DateTime? VersionDate { get; set; }
}