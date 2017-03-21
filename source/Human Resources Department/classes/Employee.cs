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
        private DateTime set;
        private DateTime update_at;

        public void Add(
            string fName, string mName, string lName, string job,
            string city, string email, string tel, string family,
            int salary, bool is_active, bool is_fulltime,
            DateTime birthday, DateTime set, DateTime update_at
        ) {
            this.fName = fName;
            this.mName = mName;
            this.lName = lName;
            this.job = job;
            this.city = city;
            this.email = email;
            this.tel = tel;
            this.family = family;

            this.salary = salary;

            this.is_active = is_active;
            this.is_fulltime = is_fulltime;

            this.birthday = birthday;
            this.set = set;
            this.update_at = update_at;
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
