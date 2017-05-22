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
        
        public string Email { get; set; }
        
        public string TelWork { get; set; }

        public string TelHome { get; set; }

        public string About { get; set; } // Описание

        public string IndividualTaxNum { get; set; } // ИНН

        public string TimeTableNum { get; set; } // Табельный №

        public bool Sex { get; set; }
        
        public bool IsActivity { get; set; }
        
        public DateTime EmploymentDate { get; set; } // Дата приёма на работу

        public DateTime DateDismissal { get; set; } // Дата звільнення з роботи

        public DateTime UpdateAt { get; set; }

        public int JobId { get; set; } // ID должности с таб. Jobs

        public double Salary { get; set; }
    }
}
