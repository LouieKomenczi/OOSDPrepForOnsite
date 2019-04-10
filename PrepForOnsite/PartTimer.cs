using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepForOnsite
{
    public class PartTimer:Employee //extending employee class
    {
        public int HourlyRate { get; set; }
        public int Hours { get; set; }

        public PartTimer(string firstName, string lastName, int hourlyRate, int hours) : base(firstName, lastName) //refering to parent class constructor
        {
            HourlyRate = hourlyRate;
            Hours = hours;
        }

        public PartTimer()
        {

        }

        public override string ToString()
        {
            return "["+this.GetType().Name+"] "+FirstName+" "+LastName+" Weekly wages: "+HourlyRate*Hours;
        }
    }
}
