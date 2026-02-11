namespace SCBAlogger.Model

;

public partial class Jurisdiction
{
    public int Id { get; set; }

    public string Jurisdiction1 { get; set; } = null!;

    public virtual ICollection<Scan> Scans { get; set; } = new List<Scan>();
}
