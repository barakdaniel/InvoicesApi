using System.Data.SqlClient;

namespace Invoices.Data
{
    public class dbdef
    {
        public static string ConnectionString;
        public static SqlConnection NewConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public static Invoice TInvoice = new Invoice();
        public static Status TStatus = new Status();
        public static ExceptionLog TExceptionLog = new ExceptionLog();

        public class Invoice
        {
            public static implicit operator string(Invoice table_name)
            { return "Invoice"; }



            public string Cn
            {
                get { return "Invoices.dbo.Invoice"; }
            }

            // Invoice fields
            public Id FId = new Id();

            public InvoiceId FInvoiceId = new InvoiceId();

            public Time FTime = new Time();

            public StatusId FStatusId = new StatusId();

            public Amount FAmount = new Amount();

            public class Id
            {
                public static implicit operator string(Id field_name)
                {
                    return "Invoice.Id";
                }

                public string Cn
                {
                    get { return "Invoices.dbo.Invoice.Id"; }
                }

                public string OnlyColumnName
                {
                    get { return "Id"; }
                }
            }

            public class InvoiceId
            {
                public static implicit operator string(InvoiceId field_name)
                {
                    return "Invoice.InvoiceId";
                }

                public string Cn
                {
                    get { return "Invoices.dbo.Invoice.InvoiceId"; }
                }

                public string OnlyColumnName
                {
                    get { return "InvoiceId"; }
                }
            }

            public class Time
            {
                public static implicit operator string(Time field_name)
                {
                    return "Invoice.Time";
                }

                public string Cn
                {
                    get { return "Invoices.dbo.Invoice.Time"; }
                }

                public string OnlyColumnName
                {
                    get { return "Time"; }
                }
            }

            public class StatusId
            {
                public static implicit operator string(StatusId field_name)
                {
                    return "Invoice.StatusId";
                }

                public string Cn
                {
                    get { return "Invoices.dbo.Invoice.StatusId"; }
                }

                public string OnlyColumnName
                {
                    get { return "StatusId"; }
                }
            }

            public class Amount
            {
                public static implicit operator string(Amount field_name)
                {
                    return "Invoice.Amount";
                }

                public string Cn
                {
                    get { return "Invoices.dbo.Invoice.Amount"; }
                }

                public string OnlyColumnName
                {
                    get { return "Amount"; }
                }
            }
        }

        public class Status
        {
            public static implicit operator string(Status table_name)
            { return "Status"; }

            public string Cn
            {
                get { return "Invoices.dbo.Status"; }
            }

            // Status fields
            public StatusId FStatusId = new StatusId();

            public StatusName FStatusName = new StatusName();

            public class StatusId
            {
                public static implicit operator string(StatusId field_name)
                {
                    return "Status.StatusId";
                }

                public string Cn
                {
                    get { return "Invoices.dbo.Status.StatusId"; }
                }

                public string OnlyColumnName
                {
                    get { return "StatusId"; }
                }
            }

            public class StatusName
            {
                public static implicit operator string(StatusName field_name)
                {
                    return "Status.StatusName";
                }

                public string Cn
                {
                    get { return "Invoices.dbo.Status.StatusName"; }
                }

                public string OnlyColumnName
                {
                    get { return "StatusName"; }
                }
            }
        }

        public class ExceptionLog
        {
            public static implicit operator string(ExceptionLog table_name)
            { return "ExceptionLog"; }

            public string Cn
            {
                get { return "Invoices.dbo.ExceptionsLogs"; }
            }

            // Invoice fields
            public Id FId = new Id();
            public Time FTime = new Time();
            public ProjectName FProjectName = new ProjectName();
            public ExceptionContent FExceptionContent = new ExceptionContent();

            public class Id
            {
                public static implicit operator string(Id field_name)
                {
                    return "ExceptionsLogs.Id";
                }

                public string Cn
                {
                    get { return "Invoices.dbo.ExceptionsLogs.Id"; }
                }

                public string OnlyColumnName
                {
                    get { return "Id"; }
                }
            }

            public class Time
            {
                public static implicit operator string(Time field_name)
                {
                    return "ExceptionsLogs.Time";
                }

                public string Cn
                {
                    get { return "Invoices.dbo.ExceptionsLogs.Time"; }
                }

                public string OnlyColumnName
                {
                    get { return "Time"; }
                }
            }

            public class ProjectName
            {
                public static implicit operator string(ProjectName field_name)
                {
                    return "ExceptionsLogs.ProjectName";
                }

                public string Cn
                {
                    get { return "Invoices.dbo.ExceptionsLogs.ProjectName"; }
                }

                public string OnlyColumnName
                {
                    get { return "ProjectName"; }
                }
            }

            public class ExceptionContent
            {
                public static implicit operator string(ExceptionContent field_name)
                {
                    return "ExceptionsLogs.ExceptionContent";
                }

                public string Cn
                {
                    get { return "Invoices.dbo.ExceptionsLogs.ExceptionContent"; }
                }

                public string OnlyColumnName
                {
                    get { return "ExceptionContent"; }
                }
            }
        }
    }
}
