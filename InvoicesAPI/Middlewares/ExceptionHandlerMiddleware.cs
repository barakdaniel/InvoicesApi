using Invoices.Data;
using Invoices.Model.ExceptionLog;
using System.Text;

namespace Invoices.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next) { _next = next; }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await LogExceptionToDB(ex);
            }
        }

        public async Task LogExceptionToDB(Exception ex)
        {
            var exceptionData = new ExceptionData();

            StringBuilder exceptionContent = new StringBuilder();
            exceptionContent.AppendLine("Message - ");
            exceptionContent.AppendLine(ex.Message).AppendLine();
            exceptionContent.AppendLine("Stack Trace - ");
            exceptionContent.AppendLine(ex.StackTrace);

            var exceptionLog = new ExceptionLog()
            {
                Time = DateTime.Now,
                ProjectName = ex.Source,
                ExceptionContent = exceptionContent.ToString(),
            };
            await exceptionData.Insert(exceptionLog);
        }
    }
}
