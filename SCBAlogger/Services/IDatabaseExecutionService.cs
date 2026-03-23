using System.Data.Common;
using Microsoft.Data.SqlClient;

public interface IDatabaseExecutionService
{
    Task<List<T>> ExecScalarListAsync<T>(
        string storedProcedureName,
        params SqlParameter[] parameters);

    Task<int> ExecNonQueryAsync(
        string storedProcedureName,
        params SqlParameter[] parameters);

    Task<List<T>> ExecMappedListAsync<T>(
        string storedProcedureName,
        Func<DbDataReader, T> map,
        params SqlParameter[] parameters);
}
