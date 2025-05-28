using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier
{
    public class DateModifier
    {
        private DateTime startDate;
        private DateTime endDate;

        public string StartDate
        {
            get { return startDate.ToString("yyyy MM dd"); }
            set { startDate = DateTime.ParseExact(value, "yyyy MM dd", CultureInfo.InvariantCulture); }
        }
        public string EndDate
        {
            get { return endDate.ToString("yyyy MM dd"); }
            set { endDate = DateTime.ParseExact(value, "yyyy MM dd", CultureInfo.InvariantCulture); ; }
        }
        public int CalculateDays()
        {
            int days = 0;
            TimeSpan difference = endDate - startDate;
            days = difference.Days;
            return Math.Abs(days);
        }
    }
}
