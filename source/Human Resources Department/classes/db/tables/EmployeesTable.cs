using SQLite;
using System;

namespace Human_Resources_Department.classes.db.tables
{
    class EmployeesTable
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }
        
        [NotNull]
        public string FName { get; set; }
        
        public string MName { get; set; }
        
        public string LName { get; set; }
        
        public string Job { get; set; }
        
        public string City { get; set; }
        
        public string Email { get; set; }
        
        public string Tel { get; set; }
        
        public string Family { get; set; }
        
        public int Salary { get; set; }
        
        public bool IsActivity { get; set; }
        
        public bool IsFulltime { get; set; }
        
        public DateTime Birthday { get; set; }
        
        public DateTime SetCompany { get; set; }
        
        public DateTime UpdateAt { get; set; }
    }
}
