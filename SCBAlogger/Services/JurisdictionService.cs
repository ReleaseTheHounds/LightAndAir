using Microsoft.Data.SqlClient;

public class JurisdictionService
{
    private readonly IDatabaseExecutionService _dbExec;

    public JurisdictionService(IDatabaseExecutionService dbExec)
    {
        _dbExec = dbExec;
    }

    public Task<List<int>> GetUniqueJurisdictionsFromEventAsync(int eventId)
    {
        var idParam = new SqlParameter("@Id", eventId);
        return _dbExec.ExecScalarListAsync<int>(
            "dbo.SelectUniqueJurisdictionsFromEvent",
            idParam);
    }
}

