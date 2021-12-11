using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TollFeeCalculator
{
    class TollFeeService
    {
        private string[] Holidays = new string[]
        {
            "01/01/2021",
            "28/03/2021",
            "29/03/2021",
            "01/04/2021",
            "30/04/2021",
            "01/05/2021",
            "08/05/2021",
            "09/05/2021",
            "05/06/2021",
            "06/06/2021",
            "21/06/2021",
            "01/11/2021",
            "24/12/2021",
            "25/12/2021",
            "26/12/2021",
            "31/12/2021"
        };

        private int[] VacationMonths = new int[]
        {
            7
        };

        private bool IsTollFreeDate(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || VacationMonths.Contains(date.Month)) return true;

            foreach (string holiday in Holidays)
            {
                if (DateTime.ParseExact(holiday, "dd/MM/yyyy", null).Date == date.Date)
                {
                    return true;
                }
            }

            return false;
        }

        public int GetTollFee(DateTime date, Vehicle vehicle)
        {
            if (IsTollFreeDate(date) || vehicle.IsTollFree) return 0;

            int result = 0;
            TimeSpan timeOfDay = date.TimeOfDay;

            Dictionary<TimeSpan, int> periodFees = new Dictionary<TimeSpan, int>();

            periodFees.Add(new TimeSpan(6, 0, 0), 9);
            periodFees.Add(new TimeSpan(6, 30, 0), 16);
            periodFees.Add(new TimeSpan(7, 00, 0), 22);
            periodFees.Add(new TimeSpan(8, 00, 0), 16);
            periodFees.Add(new TimeSpan(8, 30, 0), 9);
            periodFees.Add(new TimeSpan(15, 00, 0), 16);
            periodFees.Add(new TimeSpan(15, 30, 0), 22);
            periodFees.Add(new TimeSpan(17, 00, 0), 16);
            periodFees.Add(new TimeSpan(18, 00, 0), 9);
            periodFees.Add(new TimeSpan(18, 30, 0), 0);

            for (int index = 0; index < periodFees.Count; index++)
            {
                var item = periodFees.ElementAt(index);
                bool isTimeBeforePeriodFee = TimeSpan.Compare(timeOfDay, item.Key) >= 0;
                bool isLastPeriodFee = index < periodFees.Count - 1;
                bool isTimeAfterPeriodFee = isLastPeriodFee && TimeSpan.Compare(periodFees.ElementAt(index + 1).Key, timeOfDay) > 0;

                if (isTimeBeforePeriodFee && isTimeAfterPeriodFee)
                {
                    result = item.Value;
                }
            }

            return result;
        }
    }
}
