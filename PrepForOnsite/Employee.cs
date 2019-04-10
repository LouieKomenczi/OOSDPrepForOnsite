using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepForOnsite
{
    public class Employee:IComparable//implemnting IComparable interface
    {
        protected string FirstName { get; set; } //visible in this class and extending employee
        public string LastName { get; set; }
        private int Salary { get; set; }//visible onlyin this class


        //readonly modifier
        //private readonly int idNumber;
        //public int IdNumber { get; }

        public Employee()
        {

        }

        public Employee(string firstName, string lastName, int salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }

        public Employee(string firstName, string lastName) : this(firstName, lastName, 0) // link to constructor
        {

        }



        public override string ToString()
        {
            return "[Employee]"+FirstName+" "+ LastName+"Salary:€"+Salary;
        }

        public int CompareTo(object obj)//
        {
            Employee temp = obj as Employee;
            return string.Compare(this.LastName, temp.LastName);
            
        }
    }
}
