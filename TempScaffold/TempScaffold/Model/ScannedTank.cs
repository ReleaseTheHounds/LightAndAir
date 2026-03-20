using System;
using System.Collections.Generic;

namespace SCBALogger;

public partial class ScannedTank
{
    public string SerialNumber { get; set; } = null!;

    public string HydrostatDate { get; set; } = null!;

    public int Pressure { get; set; }

    public string Condition { get; set; } = null!;

    public string Jurisdiction { get; set; } = null!;

    public string OperatorName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Compressor { get; set; } = null!;
}
