using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepForOnsite
{
    public class Contractor:PartTimer
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Contractor()
        {
        }

        public Contractor(string firstName, string lastName, int hourlyRate, int hours, DateTime startDate, DateTime endDate)
            :base(firstName, lastName, hourlyRate, hours) //refering to parent class constructor
        {
            HourlyRate = hourlyRate;
            Hours = hours;
        }

        public override string ToString()
        {
            return base.ToString()+" Start date:"+ StartDate+" End date:"+EndDate;
        }
    }
}
