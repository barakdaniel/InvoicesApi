# InvoicesApi
.Net Core Api for invoices management__

## Versions
.Net Core - 6.0__
Dapper - 2.0.143__
Microsoft.Extensions.Caching.Abstractions - 7.0.0__
Swashbuckle.AspNetCore - 6.5.0__
System.Data.SqlClient - 4.8.5__

## SQL
Invoices -__
    Invoice -__
        Id - int__
        InvoiceId - nvarchar(50)__
        Time - datetime__
        StatusId - int__
        Amount - int__
    Status -__
        StatusId - int__
        StatusName - varchar(15)__
    ExceptionsLogs -__
        Id - int__
        ProjectName - varchar(50)__
        Time - datetime__
        ExceptionContent - nvarchar(4000)__