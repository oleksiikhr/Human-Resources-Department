using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human_Resources_Department
{
    class Employee
    {
        private string fName;
        private string mName;
        private string lName;
        private string job;
        private string city;
        private string email;
        private string tel;
        private string family;

        private int salary;
        
        private bool is_active;
        private bool is_fulltime;

        private DateTime birthday;
        private DateTime join;
        private DateTime leave;

        public Employee()
        {

        }

        public bool add()
        {
            return true;
        }

        public object get()
        {
            return "";
        }

        public bool del()
        {
            return true;
        }
    }
}
