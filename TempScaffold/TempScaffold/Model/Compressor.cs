using System;
using System.Collections.Generic;

namespace SCBALogger;

public partial class Compressor
{
    public int Id { get; set; }

    public string Compressor1 { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
