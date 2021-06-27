using System;

namespace RCP.Helpers
{
    public class ManHours
    {
        public double GetManHours(DateTime startDate, DateTime endDate)
        {
            double minutes = endDate.Subtract(startDate).TotalMinutes;
            double hours = minutes / 60;
            
            return hours;
        }
    }
}