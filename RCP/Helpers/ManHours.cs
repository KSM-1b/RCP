using System;

namespace RCP.Helpers
{
    public class ManHours
    {
        public double GetManHours(DateTime startDate, DateTime endDate)
        {
            double minutes = endDate.Subtract(startDate).TotalMinutes;
            double hours = minutes / 60;
            
            //If in database someone inserted startDate bigger than endDate
            if (hours < 0)
            {
                hours=0;
            }
            
            return hours;
        }
    }
}