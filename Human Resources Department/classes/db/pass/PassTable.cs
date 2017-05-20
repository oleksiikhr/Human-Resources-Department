using System;
using SQLite;

namespace Human_Resources_Department.classes.db.pass
{
    class PassTable
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }

        [Unique]
        public int IdEmployee { get; set; }

        /* Identification [I] - Удостоверение личности */

        public string ISeries { get; set; }

        public int INumber { get; set; }

        public DateTime IBirthday { get; set; }

        public string IBirthPlace { get; set; } // Место рождения

        public string IDocumentType { get; set; }

        public DateTime IDateIssue { get; set; } // Дата выдачи

        public string IIssuedBy { get; set; } // Кем выдано

        /* Propiska [P] - Прописка */

        public int PIndex { get; set; }

        public string PLocality { get; set; }

        public string PStreet { get; set; }

        public string PHouse { get; set; }

        public string PBuilding { get; set; } // Корпус

        public string PApartment { get; set; }

        /* Actual residence [A] - Актуальное место жительства */
        
        public int AIndex { get; set; }

        public string ALocality { get; set; }

        public string AStreet { get; set; }

        public string AHouse { get; set; }

        public string ABuilding { get; set; } // Корпус

        public string AApartment { get; set; }

        public DateTime ARegister { get; set; } // Дата регистрация по месту жительства
    }
}
