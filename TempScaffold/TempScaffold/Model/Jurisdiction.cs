using System;
using System.Collections.Generic;

namespace SCBALogger;

public partial class Jurisdiction
{
    public int Id { get; set; }

    public string Jurisdiction1 { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<Scan> Scans { get; set; } = new List<Scan>();
}
