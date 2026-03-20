using System;
using System.Collections.Generic;

namespace SCBALogger;

public partial class Scan
{
    public int Id { get; set; }

    public string SerialNumber { get; set; } = null!;

    public string HydrostatDate { get; set; } = null!;

    public string Condition { get; set; } = null!;

    public int Pressure { get; set; }

    public int Jurisdiction { get; set; }

    public int Operator { get; set; }

    public int Event { get; set; }

    public virtual Event EventNavigation { get; set; } = null!;

    public virtual Jurisdiction JurisdictionNavigation { get; set; } = null!;

    public virtual Operator OperatorNavigation { get; set; } = null!;
}
