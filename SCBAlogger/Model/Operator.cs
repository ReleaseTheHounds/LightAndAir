namespace SCBAlogger.Model;

public partial class Operator
{
    public int Id { get; set; }

    public string OperatorName { get; set; } = null!;

    public virtual ICollection<Scan> Scans { get; set; } = new List<Scan>();
}
