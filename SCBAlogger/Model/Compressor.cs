using System;
using System.Collections.Generic;

namespace SCBAlogger.Model;

public partial class Compressor
{
    public int Id { get; set; }

    public string Compressor1 { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
