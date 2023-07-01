using Dapper;
using Invoices.Model.Status;
using System.Data;

namespace Invoices.Data.StatusesData
{
    public class StatusData
    {
        public async Task<List<Status>> ReadAll()
        {
            //query
            string sql = $" SELECT * FROM {dbdef.TStatus.Cn}";
            //dapper
            using (IDbConnection conn = dbdef.NewConnection())
            {
                return (await conn.QueryAsync<Status>(sql)).ToList();
            }
        }
    }
}
