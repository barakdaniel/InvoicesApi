using Dapper;
using Invoices.Model.ExceptionLog;
using System.Data;

namespace Invoices.Data
{
    public class ExceptionData
    {
        public async Task Insert(ExceptionLog ex)
        {
            //params
            DynamicParameters _params = new DynamicParameters();
            _params.Add("@Time", ex.Time);
            _params.Add("@ProjectName", ex.ProjectName);
            _params.Add("@ExceptionContent", ex.ExceptionContent);

            //query
            string sql = $" INSERT INTO {dbdef.TExceptionLog.Cn} ({dbdef.TExceptionLog.FTime.Cn}, {dbdef.TExceptionLog.FProjectName.Cn}, {dbdef.TExceptionLog.FExceptionContent.Cn})" +
                $" VALUES (@Time, @ProjectName, @ExceptionContent)";

            //dapper
            using (IDbConnection conn = dbdef.NewConnection())
            {
                await conn.ExecuteAsync(sql, _params);
            }
        }

    }
}
