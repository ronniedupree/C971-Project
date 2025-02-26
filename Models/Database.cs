using SQLite;

namespace RonaldDuPreeJr_C971.Models
{
    public class Database
    {
        private SQLiteConnection? _db;

        public bool Initialize()
        {
            bool dbTablesCreated = false;
            if (_db == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db.db");
                _db = new SQLiteConnection(dbPath);
            }

            CreateTableResult createTerm = _db.CreateTable<Term>();
            CreateTableResult createCourse = _db.CreateTable<Course>();
            CreateTableResult createAssessment = _db.CreateTable<Assessment>();
            CreateTableResult createNote = _db.CreateTable<Note>();

            dbTablesCreated = createTerm == CreateTableResult.Created || createCourse == CreateTableResult.Created || createAssessment == CreateTableResult.Created || createNote == CreateTableResult.Created;

            return dbTablesCreated;
        }

        public void AddTerm(Term term)
        {
            _db?.Insert(term);
        }

        public List<Term>? GetAllTerms()
        {
            return _db?.Table<Term>().ToList();
        }

        public List<Course>? GetAllCourses()
        {
            return _db?.Table<Course>().ToList();
        }

        public List<Assessment>? GetAllAssessments()
        {
            return _db?.Table<Assessment>().ToList();
        }

        public void UpdateTerm(Term term)
        {
            _db?.Update(term);
        }

        public void DeleteTerm(Term term)
        {
            _db?.Delete(term);
        }

        public void AddCourse(Course course)
        {
            _db?.Insert(course);
        }

        public List<Course>? GetCoursesByTermId(int id)
        {
            var query = $"SELECT * FROM Course WHERE TermId={id}";
            return _db?.Query<Course>(query);
        }

        public void UpdateCourse(Course course)
        {
            _db?.Update(course);
        }

        public void DeleteCourse(Course course)
        {
            _db?.Delete(course);
        }

        public void AddAssessment(Assessment assessment)
        {
            _db?.Insert(assessment);
        }

        public List<Assessment>? GetAssessmentsByCourseId(int id)
        {
            var query = $"SELECT * FROM Assessment WHERE CourseId={id}";
            return _db?.Query<Assessment>(query);
        }

        public void UpdateAssessment(Assessment assessment)
        {
            _db?.Update(assessment);
        }

        public void DeleteAssessment(Assessment assessment)
        {
            _db?.Delete(assessment);
        }

        public void AddNote(Note note)
        {
            _db?.Insert(note);
        }

        public List<Note>? GetNotesByCourseId(int courseId)
        {
            var query = $"SELECT * FROM Note WHERE CourseId={courseId}";
            return _db?.Query<Note>(query);
        }

        public int UpdateNote(Note note)
        {
            return _db!.Update(note);
        }

        public int DeleteNote(Note note)
        {
            return _db!.Delete(note);
        }

        public void ClearDatabase()
        {
            _db?.DeleteAll<Term>();
            _db?.DeleteAll<Course>();
            _db?.DeleteAll<Assessment>();
            _db?.DeleteAll<Note>();
        }

        public void Close()
        {
            _db?.Close();
        }
    }
}
