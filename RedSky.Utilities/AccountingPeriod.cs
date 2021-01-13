using System;
using System.Globalization;

namespace RedSky.Utilities
{
    public struct AccountingPeriod
    {
        public DateTime Start { get; }
        public DateTime End { get; }
        public int Month => Start.Month;
        public int Year => Start.Year;

        /// <summary>
        ///     Gets the month name and year with slash format.
        /// </summary>
        public string FullPeriod => Start.ToString("MMMM/yy", CultureInfo.GetCultureInfo("pt-BR"));

        /// <summary>
        ///     Gets the months name and year without slash format.
        /// </summary>
        public string FullPeriodWithoutSlash => Start.ToString("MMMMyy", CultureInfo.GetCultureInfo("pt-BR"));

        /// <summary>
        ///     Gets the full month name.
        /// </summary>
        public string FullMonthName => Start.ToString("MMMM", CultureInfo.GetCultureInfo("pt-BR"));

        /// <summary>
        ///     Gets the accounting period from the current date.
        /// </summary>
        public static AccountingPeriod Today => new AccountingPeriod(DateTime.Now);

        public AccountingPeriod(string competencia)
        {
            if (competencia.Length < 6 || competencia.Length > 7)
                throw new FormatException("Can only accept month and year string format.");

            if (competencia.Length == 6)
                competencia = competencia.Substring(0, 2) + "/" + competencia.Substring(2, 4);

            var data = @"01/" + competencia;
            Start = DateTime.ParseExact(data, "dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
            End = Start.AddMonths(1).AddSeconds(-1);
        }

        public AccountingPeriod(DateTime datetime)
        {
            Start = new DateTime(datetime.Year, datetime.Month, 1);
            End = Start.AddMonths(1).AddSeconds(-1);
        }

        public override bool Equals(object obj)
        {
            var p = (AccountingPeriod) obj;
            return p.Month == Month && p.Year == Year;
        }

        public static bool operator >(AccountingPeriod a, AccountingPeriod b)
        {
            return a.End > b.End;
        }

        public static bool operator <(AccountingPeriod a, AccountingPeriod b)
        {
            return a.Start < b.End;
        }

        public static bool operator ==(AccountingPeriod a, AccountingPeriod b)
        {
            return a.Start == b.Start;
        }

        public static bool operator !=(AccountingPeriod a, AccountingPeriod b)
        {
            return a.Start != b.Start;
        }

        public static bool operator >=(AccountingPeriod a, AccountingPeriod b)
        {
            return a.Start >= b.Start;
        }

        public static bool operator <=(AccountingPeriod a, AccountingPeriod b)
        {
            return a.Start <= b.Start;
        }
    }
}