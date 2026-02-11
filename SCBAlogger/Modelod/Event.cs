using System;
using System.Collections.Generic;

namespace SCBAlogger.Model;

public partial class Event
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ExcelFileName { get; set; }

    public DateTime? DateEmailed { get; set; }

    public DateTime EventDate { get; set; }
}
