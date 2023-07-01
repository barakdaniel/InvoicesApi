# InvoicesApi
.Net Core Api for invoices management<br>

## Versions
.Net Core - 6.0<br>
Dapper - 2.0.143<br>
Microsoft.Extensions.Caching.Abstractions - 7.0.0<br>
Swashbuckle.AspNetCore - 6.5.0<br>
System.Data.SqlClient - 4.8.5<br>

## SQL
Invoices -<br>
    - Invoice -<br>
        - Id - int<br>
        - InvoiceId - nvarchar(50)<br>
        - Time - datetime<br>
        - StatusId - int<br>
        - Amount - int<br>
    - Status -<br>
        - StatusId - int<br>
        - StatusName - varchar(15)<br>
    - ExceptionsLogs -<br>
        - Id - int<br>
        - ProjectName - varchar(50)<br>
        - Time - datetime<br>
        - ExceptionContent - nvarchar(4000)<br>