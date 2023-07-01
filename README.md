# InvoicesApi
.Net Core Api for invoices management

## Versions
.Net Core - 6.0
Dapper - 2.0.143
Microsoft.Extensions.Caching.Abstractions - 7.0.0
Swashbuckle.AspNetCore - 6.5.0
System.Data.SqlClient - 4.8.5

## SQL
Invoices -
    Invoice -
        Id - int
        InvoiceId - nvarchar(50)
        Time - datetime
        StatusId - int
        Amount - int
    Status -
        StatusId - int
        StatusName - varchar(15)
    ExceptionsLogs -
        Id - int
        ProjectName - varchar(50)
        Time - datetime
        ExceptionContent - nvarchar(4000)