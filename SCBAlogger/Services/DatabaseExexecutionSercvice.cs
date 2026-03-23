using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SCBAlogger.Data;

public class DatabaseExecutionService : IDatabaseExecutionService
{
   
    private readonly SCBAContext _context;

    public DatabaseExecutionService(SCBAContext context)
    {
        _context = context;
    }

    public async Task<List<T>> ExecScalarListAsync<T>(
        string storedProcedureName,
        params SqlParameter[] parameters)
    {
        var results = new List<T>();

        await using var conn = _context.Database.GetDbConnection();
        await using var cmd = CreateCommand(conn, storedProcedureName, parameters);

        await conn.OpenAsync();

        await using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            results.Add(reader.GetFieldValue<T>(0));
        }

        return results;
    }

    public async Task<int> ExecNonQueryAsync(
        string storedProcedureName,
        params SqlParameter[] parameters)
    {
        await using var conn = _context.Database.GetDbConnection();
        await using var cmd = CreateCommand(conn, storedProcedureName, parameters);

        await conn.OpenAsync();
        return await cmd.ExecuteNonQueryAsync();
    }

    public async Task<List<T>> ExecMappedListAsync<T>(
        string storedProcedureName,
        Func<DbDataReader, T> map,
        params SqlParameter[] parameters)
    {
        var results = new List<T>();

        await using var conn = _context.Database.GetDbConnection();
        await using var cmd = CreateCommand(conn, storedProcedureName, parameters);

        await conn.OpenAsync();

        await using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            results.Add(map(reader));
        }

        return results;
    }

    private static DbCommand CreateCommand(
        DbConnection conn,
        string storedProcedureName,
        SqlParameter[] parameters)
    {
        var cmd = conn.CreateCommand();
        cmd.CommandText = storedProcedureName;
        cmd.CommandType = CommandType.StoredProcedure;

        if (parameters is { Length: > 0 })
        {
            foreach (var p in parameters)
            {
                cmd.Parameters.Add(p);
            }
        }

        return cmd;
    }
}
