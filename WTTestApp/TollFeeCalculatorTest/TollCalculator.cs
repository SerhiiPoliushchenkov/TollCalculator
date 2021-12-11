using Models;
using System;

namespace TollFeeCalculator {
    public class TollCalculator
    {
        int hourInMillies = 60 * 60 * 1000;
        /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total toll fee for that day
         */

        public int GetTollFee(Vehicle vehicle, DateTime[] dates)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException("vehicle");
            }

            if (dates.Length == 0)
            {
                throw new ArgumentNullException("dates");
            }
            
            TollFeeService tollFeeService = new TollFeeService();
            DateTime intervalStart = dates[0];
            int totalFee = 0;
            foreach (DateTime date in dates)
            {
                int nextFee = tollFeeService.GetTollFee(date, vehicle);
                int tempFee = tollFeeService.GetTollFee(intervalStart, vehicle);
                TimeSpan ts = date - intervalStart;

                if (ts.TotalMilliseconds < hourInMillies)
                {
                    if (totalFee > 0) totalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    totalFee += tempFee;
                }
                else
                {
                    totalFee += nextFee;
                }
            }
            if (totalFee > 60) totalFee = 60;
            return totalFee;
        }
    }
}