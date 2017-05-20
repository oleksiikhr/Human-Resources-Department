using System;
using SQLite;

namespace Human_Resources_Department.classes.employees.db
{
    class MainTable
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }
        
        [NotNull]
        public string FName { get; set; }

        public string LName { get; set; }

        public string MName { get; set; }
        
        public string Job { get; set; }
        
        public string Email { get; set; }
        
        public string TelWork { get; set; }

        public string TelHome { get; set; }

        public string About { get; set; } // Описание

        public bool Sex { get; set; }

        public bool IsActivity { get; set; }
        
        public DateTime EmploymentDate { get; set; } // Дата приёма на работу
        
        public DateTime UpdateAt { get; set; }

        public int IndividualTaxNum { get; set; } // ИНН

        public int TimeTableNum { get; set; } // Табельный №

        public int JobsId { get; set; } // Должность с таб. Jobs
    }
}
