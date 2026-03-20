using System;
using System.Collections.Generic;

namespace SCBALogger;

public partial class Operator
{
    public int Id { get; set; }

    public string OperatorName { get; set; } = null!;

    /// <summary>
    /// Is the operator currently active
    /// </summary>
    public bool IsActive { get; set; }

    public virtual ICollection<Scan> Scans { get; set; } = new List<Scan>();
}
