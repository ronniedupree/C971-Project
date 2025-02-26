using SQLite;

namespace RonaldDuPreeJr_C971.Models
{
    [Table("Assessment")]
    public class Assessment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }
        public bool StartDateNotification { get; set; }
        public bool EndDateNotification { get; set; }

        public Assessment()
        {

        }
    }
}