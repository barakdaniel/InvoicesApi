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
&nbsp;&nbsp;&nbsp;&nbsp;Invoice -<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Id - int<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InvoiceId - nvarchar(50)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Time - datetime<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StatusId - int<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Amount - int<br>
&nbsp;&nbsp;&nbsp;&nbsp;Status -<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StatusId - int<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StatusName - varchar(15)<br>
&nbsp;&nbsp;&nbsp;&nbsp;ExceptionsLogs -<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Id - int<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProjectName - varchar(50)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Time - datetime<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ExceptionContent - nvarchar(4000)<br>