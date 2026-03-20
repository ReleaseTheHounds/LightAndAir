using System;
using System.Collections.Generic;

namespace SCBALogger;

public partial class Event
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ExcelFileName { get; set; }

    public DateTime? DateEmailed { get; set; }

    public DateTime EventDate { get; set; }

    public int? Compressor { get; set; }

    public virtual Compressor? CompressorNavigation { get; set; }

    public virtual ICollection<Scan> Scans { get; set; } = new List<Scan>();
}
