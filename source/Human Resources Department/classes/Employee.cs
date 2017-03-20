using System;

namespace Human_Resources_Department.classes
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
        private DateTime update_at;

        public bool Add(string fName = "")
        {
            this.fName = fName;
            return true;
        }

        public bool Update()
        {
            return true;
        }

        public object Get()
        {
            return "";
        }

        public bool Del()
        {
            return true;
        }
    }
}
