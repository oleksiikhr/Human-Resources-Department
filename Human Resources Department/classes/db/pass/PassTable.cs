using SQLite;

namespace Human_Resources_Department.classes.db.pass
{
    class PassTable
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }

        [Unique]
        public string Series { get; set; }
    }
}
