namespace DBTest.Model;

public partial class Event
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Scan> Scans { get; set; } = new List<Scan>();
}
