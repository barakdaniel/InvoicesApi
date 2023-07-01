using Dapper;
using Invoices.Model.Invoice;
using System.Data;

namespace Invoices.Data.InvoicesData
{
    public class InvoiceData
    {
        public async Task<List<Invoice>> ReadAll()
        {
            //query
            string sql = $" SELECT {dbdef.TInvoice.FId.Cn}, {dbdef.TInvoice.FInvoiceId.Cn}, {dbdef.TInvoice.FTime.Cn}, {dbdef.TStatus.FStatusName.Cn}, {dbdef.TInvoice.FAmount.Cn}" +
                $" FROM {dbdef.TInvoice.Cn} LEFT JOIN {dbdef.TStatus.Cn} ON {dbdef.TStatus.FStatusId.Cn} = {dbdef.TInvoice.FStatusId.Cn}";
            //dapper
            using (IDbConnection conn = dbdef.NewConnection())
            {
                return (await conn.QueryAsync<Invoice>(sql)).ToList();
            }
        }

        public async Task<Invoice> ReadById(int id)
        {
            //params
            DynamicParameters _params = new DynamicParameters();
            _params.Add("@Id", id);

            //query
            string sql = $" SELECT {dbdef.TInvoice.FId.Cn}, {dbdef.TInvoice.FInvoiceId.Cn}, {dbdef.TInvoice.FTime.Cn}, {dbdef.TStatus.FStatusName.Cn}, {dbdef.TInvoice.FAmount.Cn}" +
                $" FROM {dbdef.TInvoice.Cn} LEFT JOIN {dbdef.TStatus.Cn} ON {dbdef.TStatus.FStatusId.Cn} = {dbdef.TInvoice.FStatusId.Cn}" +
                $" WHERE {dbdef.TInvoice.FId.Cn} = @Id";

            //dapper
            using (IDbConnection conn = dbdef.NewConnection())
            {
                return (await conn.QueryAsync<Invoice>(sql, _params)).FirstOrDefault();
            }
        }

        public async Task<bool> Insert(InvoiceInsert invoice)
        {
            //params
            DynamicParameters _params = new DynamicParameters();
            _params.Add("@InvoiceId", invoice.InvoiceId);
            _params.Add("@Time", invoice.Time);
            _params.Add("@StatusId", 1);
            _params.Add("@Amount", invoice.Amount);

            //query
            string sql = $" INSERT INTO {dbdef.TInvoice.Cn} ({dbdef.TInvoice.FInvoiceId.Cn}, {dbdef.TInvoice.FTime.Cn}, {dbdef.TInvoice.FStatusId.Cn}, {dbdef.TInvoice.FAmount.Cn})" +
                $" VALUES (@InvoiceId, @Time, @StatusId, @Amount)";

            //dapper
            using (IDbConnection conn = dbdef.NewConnection())
            {
                return Convert.ToBoolean(await conn.ExecuteAsync(sql, _params));
            }
        }

        public async Task<bool> Delete(int id)
        {
            //params
            DynamicParameters _params = new DynamicParameters();
            _params.Add("@Id", id);

            //query
            string sql = $" DELETE FROM {dbdef.TInvoice.Cn}" +
                $" WHERE {dbdef.TInvoice.FId.Cn} = @Id";

            //dapper
            using (IDbConnection conn = dbdef.NewConnection())
            {
                return Convert.ToBoolean(await conn.ExecuteAsync(sql, _params));
            }
        }

        public async Task<bool> Update(InvoiceUpdate invoice)
        {
            //params
            DynamicParameters _params = new DynamicParameters();
            _params.Add("@Id", invoice.Id);
            _params.Add("@StatusId", invoice.StatusId);

            //query
            string sql = $" UPDATE {dbdef.TInvoice.Cn} SET {dbdef.TInvoice.FStatusId.Cn} = @StatusId" +
                $" WHERE {dbdef.TInvoice.FId.Cn} = @Id";

            //dapper
            using (IDbConnection conn = dbdef.NewConnection())
            {
                return Convert.ToBoolean(await conn.ExecuteAsync(sql, _params));
            }
        }
    }
}
