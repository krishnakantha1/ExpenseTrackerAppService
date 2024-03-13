using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAppService.Core.Utils
{
    public class DateTimeUtils
    {
        //receives year and month where month is one based i.e 1->Jan, 2->Feb etc.
        public static (int month, int year) AddMonth(int year, int month, int extraMonth)
        {
            //make month 0 based i.e 0->Jan, 1->Feb etc.
            month -= 1;


            year += (month + extraMonth) / 12;
            month = (month + extraMonth) % 12;

            //reset the month from earlier
            month += 1;

            return (month, year);
        }
    }
}
