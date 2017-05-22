using SQLite;

namespace Human_Resources_Department.classes.db.jobs
{
    class JobsTable
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }

        [Unique]
        public string Title { get; set; }
    }
}
