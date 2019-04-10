using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrepForOnsite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] firstnames = { "MARY", "PATRICIA", "LINDA", "BARBARA", "ELIZABETH", "JENNIFER", "MARIA", "SUSAN", "MARGARET", "DOROTHY", "LISA", "JAMES", "JOHN", "ROBERT", "MICHAEL", "WILLIAM", "DAVID", "RICHARD", "CHARLES", "JOSEPH", "THOMAS", };
        public string[] lastnames = { "SMITH", "JOHNSON", "WILLIAMS", "JONES", "BROWN", "DAVIS", "MILLER", "WILSON", "MOORE", "TAYLOR", "ANDERSON", "THOMAS", "JACKSON", "WHITE", "HARRIS", "MARTIN", "THOMPSON", "ROBINSON", "CLARK", "LEWIS", "LEE", };
        public ObservableCollection<Employee> staffList = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> restrictedList = new ObservableCollection<Employee>();
       
        public MainWindow()
        {
            
            InitializeComponent();
            LoadStaffList();
            SetCount();

        }

        public void LoadStaffList()
        {
            Random random = new Random();
            for(int i=0; i<10; i++)
            {
                switch (random.Next(1, 4))
                {
                    case 1:
                        Employee emp = new Employee(firstnames[random.Next(1, 21)], lastnames[random.Next(1, 21)], random.Next(20000, 40000));
                        staffList.Add(emp);
                        break;
                    case 2:
                        PartTimer ptr = new PartTimer(firstnames[random.Next(1, 21)], lastnames[random.Next(1, 21)], random.Next(10, 40), random.Next(10, 20));
                        staffList.Add(ptr);
                        break;
                    case 3:
                        Contractor ctr = new Contractor(firstnames[random.Next(1, 21)], lastnames[random.Next(1, 21)], random.Next(10, 40), random.Next(10, 20), PastDate(), FutureDate() );
                        staffList.Add(ctr);
                        break;
                }
                

                
            }

            lbxDisplay.ItemsSource = staffList;
        }

        public DateTime PastDate()
        {
            Random random = new Random();
            DateTime start = DateTime.Now.AddYears(-1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        public DateTime FutureDate()
        {
            Random random = new Random();
            DateTime start = DateTime.Now.AddYears(1);
            int range = (start - DateTime.Today).Days;
            return start.AddDays(random.Next(range));
        }

        private void RdbAll_Checked(object sender, RoutedEventArgs e)
        {
            lbxDisplay.ItemsSource = staffList;
        }

        public void SetCount()
        {
            int emp = 0, ptr = 0, ctr = 0;
            foreach (Employee e in staffList)
            {
                if (e is Contractor)
                    ctr++;
                else if (e is PartTimer)
                    ptr++;
                else if (e is Employee)
                    emp++;
            }


            txbEmployee.Text = emp.ToString();
            txbPartTime.Text = ptr.ToString();
            txbContractor.Text = ctr.ToString();
        }

        private void RdbContractor_Checked(object sender, RoutedEventArgs e)
        {
            restrictedList.Clear();
            foreach (Employee emp in staffList)
            {                
                if (emp.GetType().Name == "Contractor")
                    restrictedList.Add(emp);
                lbxDisplay.ItemsSource = restrictedList;
            }
        }

        private void RdbPartTime_Checked(object sender, RoutedEventArgs e)
        {
            restrictedList.Clear();
            foreach (Employee emp in staffList)
            {
                if (emp.GetType().Name == "PartTimer")
                    restrictedList.Add(emp);
                lbxDisplay.ItemsSource = restrictedList;
            }
        }

        private void RdbEmployee_Checked(object sender, RoutedEventArgs e)
        {
            restrictedList.Clear();
            foreach (Employee emp in staffList)
            {
                if (emp.GetType().Name == "Employee")
                    restrictedList.Add(emp);
                lbxDisplay.ItemsSource = restrictedList;
            }
        }


    }
}
