using System.Collections.ObjectModel;
using RonaldDuPreeJr_C971.Models;

namespace RonaldDuPreeJr_C971;

public partial class MainPage
{
    public ObservableCollection<Term> Terms { get; set; }
    private Database _db;
    public ObservableCollection<string> AssType { get; } = ["Performance Assessment", "Objective Assessment"];

    public MainPage(Database db)
    {
        InitializeComponent();
        _db = db;
        SampleData();
        Terms = new ObservableCollection<Term>(_db.GetAllTerms());
        BindingContext = this;
    }

    private void SampleData()
    {
        // Initialize database
        _db.Initialize();

        // Clear database data
        _db.ClearDatabase();

        // Create new terms and add to database
        var t1 = new Term { Title = "Fall", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(4) };
        var t2 = new Term { Title = "Spring", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(4) };
        _db.AddTerm(t1);
        _db.AddTerm(t2);

        t1 = _db.GetAllTerms()!.First(t => t.Title == "Fall");
        t2 = _db.GetAllTerms()!.First(t => t.Title == "Spring");

        // Create sample courses for Fall term
        var c1 = new Course
        {
            TermId = t1.Id,
            Title = "Math 101",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            Status = "In Progress",
            InstructorName = "Anika Patel",
            InstructorPhone = "555-123-4567",
            InstructorEmail = "anika.patel@strimeuniversity.edu",
            StartDateNotification = true,
            EndDateNotification = true,
            Notes = "Notes section for math 101 course"
        };

        var c2 = new Course
        {
            TermId = t1.Id,
            Title = "Physics 201",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            Status = "Completed",
            InstructorName = "James Chen",
            InstructorPhone = "555-234-5678",
            InstructorEmail = "james.chen@strimeuniversity.edu",
            StartDateNotification = true,
            EndDateNotification = true,
            Notes = "Notes section for Physics 201 course"
        };

        var c3 = new Course
        {
            TermId = t1.Id,
            Title = "Chemistry 301",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            Status = "In Progress",
            InstructorName = "Maria Gomez",
            InstructorPhone = "555-345-6789",
            InstructorEmail = "maria.gomez@strimeuniversity.edu",
            StartDateNotification = true,
            EndDateNotification = false,
            Notes = "Notes section for Chemistry 301 course"
        };

        var c4 = new Course
        {
            TermId = t1.Id,
            Title = "Biology 401",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            Status = "In Progress",
            InstructorName = "David Lee",
            InstructorPhone = "555-456-7890",
            InstructorEmail = "david.lee@strimeuniversity.edu",
            StartDateNotification = true,
            EndDateNotification = false,
            Notes = "Notes section for Biology 401 course"
        };

        var c5 = new Course
        {
            TermId = t1.Id,
            Title = "History 101",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            Status = "Completed",
            InstructorName = "Laura Thompson",
            InstructorPhone = "555-567-8901",
            InstructorEmail = "laura.thompson@strimeuniversity.edu",
            StartDateNotification = true,
            EndDateNotification = true,
            Notes = "Notes section for History 101 course"
        };

        var c6 = new Course
        {
            TermId = t1.Id,
            Title = "Psychology 201",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            Status = "In Progress",
            InstructorName = "Michael Brown",
            InstructorPhone = "555-678-9012",
            InstructorEmail = "michael.brown@strimeuniversity.edu",
            StartDateNotification = false,
            EndDateNotification = true,
            Notes = "Notes section for Psychology 201 course"
        };


        // Create sample courses for Spring term
        var c7 = new Course
        {
            TermId = t2.Id,
            Title = "English Literature 101",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            Status = "In Progress",
            InstructorName = "Susan Harris",
            InstructorPhone = "555-789-0123",
            InstructorEmail = "susan.harris@strimeuniversity.edu",
            StartDateNotification = true,
            EndDateNotification = true,
            Notes = "Notes section for English Literature 101 course"
        };

        var c8 = new Course
        {
            TermId = t2.Id,
            Title = "Philosophy 202",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            Status = "In Progress",
            InstructorName = "Robert Green",
            InstructorPhone = "555-890-1234",
            InstructorEmail = "robert.green@strimeuniversity.edu",
            StartDateNotification = true,
            EndDateNotification = false,
            Notes = "Notes section for Philosophy 202 course"
        };

        var c9 = new Course
        {
            TermId = t2.Id,
            Title = "Computer Science 101",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            Status = "In Progress",
            InstructorName = "Emma Wilson",
            InstructorPhone = "555-901-2345",
            InstructorEmail = "emma.wilson@strimeuniversity.edu",
            StartDateNotification = true,
            EndDateNotification = true,
            Notes = "Notes section for Computer Science 101 course"
        };

        var c10 = new Course
        {
            TermId = t2.Id,
            Title = "Economics 303",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            Status = "Completed",
            InstructorName = "John White",
            InstructorPhone = "555-012-3456",
            InstructorEmail = "john.white@strimeuniversity.edu",
            StartDateNotification = false,
            EndDateNotification = true,
            Notes = "Notes section for Economics 303 course"
        };

        var c11 = new Course
        {
            TermId = t2.Id,
            Title = "Marketing 403",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            Status = "In Progress",
            InstructorName = "Lisa Black",
            InstructorPhone = "555-123-4567",
            InstructorEmail = "lisa.black@strimeuniversity.edu",
            StartDateNotification = true,
            EndDateNotification = true,
            Notes = "Notes section for Marketing 403 course"
        };

        var c12 = new Course
        {
            TermId = t2.Id,
            Title = "Art History 101",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            Status = "Completed",
            InstructorName = "Angela Brown",
            InstructorPhone = "555-234-5678",
            InstructorEmail = "angela.brown@strimeuniversity.edu",
            StartDateNotification = true,
            EndDateNotification = true,
            Notes = "Notes section for Art History 101 course"
        };

        // Add courses to database
        _db.AddCourse(c1);
        _db.AddCourse(c2);
        _db.AddCourse(c3);
        _db.AddCourse(c4);
        _db.AddCourse(c5);
        _db.AddCourse(c6);
        _db.AddCourse(c7);
        _db.AddCourse(c8);
        _db.AddCourse(c9);
        _db.AddCourse(c10);
        _db.AddCourse(c11);
        _db.AddCourse(c12);

        // Assessments for Course 1
        var pa1 = new Assessment
        {
            CourseId = c1.Id,
            Name = "Performance Assessment 1",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[0]
        };
        var oa1 = new Assessment
        {
            CourseId = c1.Id,
            Name = "Objective Assessment 1",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[1]
        };

        // Assessments for Course 2
        var pa2 = new Assessment
        {
            CourseId = c2.Id,
            Name = "Performance Assessment 2",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[0]
        };
        var oa2 = new Assessment
        {
            CourseId = c2.Id,
            Name = "Objective Assessment 2",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[1]
        };

        // Assessments for Course 3
        var pa3 = new Assessment
        {
            CourseId = c3.Id,
            Name = "Performance Assessment 1",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[0]
        };
        var oa3 = new Assessment
        {
            CourseId = c3.Id,
            Name = "Objective Assessment 1",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[1]
        };

        // Assessments for Course 4
        var pa4 = new Assessment
        {
            CourseId = c4.Id,
            Name = "Performance Assessment 2",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[0]
        };
        var oa4 = new Assessment
        {
            CourseId = c4.Id,
            Name = "Objective Assessment 2",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[1]
        };

        // Assessments for Course 5
        var pa5 = new Assessment
        {
            CourseId = c5.Id,
            Name = "Performance Assessment 1",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[0]
        };
        var oa5 = new Assessment
        {
            CourseId = c5.Id,
            Name = "Objective Assessment 1",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[1]
        };

        // Assessments for Course 6
        var pa6 = new Assessment
        {
            CourseId = c6.Id,
            Name = "Performance Assessment 2",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[0]
        };
        var oa6 = new Assessment
        {
            CourseId = c6.Id,
            Name = "Objective Assessment 2",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[1]
        };

        // Assessments for Course 7
        var pa7 = new Assessment
        {
            CourseId = c7.Id,
            Name = "Performance Assessment 1",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[0]
        };
        var oa7 = new Assessment
        {
            CourseId = c6.Id,
            Name = "Objective Assessment 1",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[1]
        };

        // Assessments for Course 8
        var pa8 = new Assessment
        {
            CourseId = c8.Id,
            Name = "Performance Assessment 2",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[0]
        };
        var oa8 = new Assessment
        {
            CourseId = c8.Id,
            Name = "Objective Assessment 2",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[1]
        };

        // Assessments for Course 9
        var pa9 = new Assessment
        {
            CourseId = c9.Id,
            Name = "Performance Assessment 1",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[0]
        };
        var oa9 = new Assessment
        {
            CourseId = c9.Id,
            Name = "Objective Assessment 1",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[1]
        };

        // Assessments for Course 10
        var pa10 = new Assessment
        {
            CourseId = c10.Id,
            Name = "Performance Assessment 2",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[0]
        };
        var oa10 = new Assessment
        {
            CourseId = c10.Id,
            Name = "Objective Assessment 2",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[1]
        };

        // Assessments for Course 11
        var pa11 = new Assessment
        {
            CourseId = c11.Id,
            Name = "Performance Assessment 1",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[0]
        };
        var oa11 = new Assessment
        {
            CourseId = c11.Id,
            Name = "Objective Assessment 1",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[1]
        };

        // Assessments for Course 12
        var pa12 = new Assessment
        {
            CourseId = c12.Id,
            Name = "Performance Assessment 2",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[0]
        };
        var oa12 = new Assessment
        {
            CourseId = c12.Id,
            Name = "Objective Assessment 2",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(4),
            StartDateNotification = false,
            EndDateNotification = true,
            Type = AssType[1]
        };

        _db.AddAssessment(pa1);
        _db.AddAssessment(oa1);
        _db.AddAssessment(pa2);
        _db.AddAssessment(oa2);
        _db.AddAssessment(pa3);
        _db.AddAssessment(oa3);
        _db.AddAssessment(pa4);
        _db.AddAssessment(oa4);
        _db.AddAssessment(pa5);
        _db.AddAssessment(oa5);
        _db.AddAssessment(pa6);
        _db.AddAssessment(oa6);
        _db.AddAssessment(pa7);
        _db.AddAssessment(oa7);
        _db.AddAssessment(pa8);
        _db.AddAssessment(oa8);
        _db.AddAssessment(pa9);
        _db.AddAssessment(oa9);
        _db.AddAssessment(pa10);
        _db.AddAssessment(oa10);
        _db.AddAssessment(pa11);
        _db.AddAssessment(oa11);
        _db.AddAssessment(pa12);
        _db.AddAssessment(oa12);
    }

    private void OnAddTermClicked(object sender, EventArgs e)
    {
        // add a new term
        var t = new Term { Title = "New Term", StartDate = DateTime.Today, EndDate = DateTime.Today.AddMonths(4) };
        _db.AddTerm(t);
        Terms.Add(t);
    }

    private void ViewTermClicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.CommandParameter is Term t)
        {
            // open term details page
            Navigation.PushAsync(new TermDetails(t, _db));
        }
    }

    private void DeleteTermClicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.CommandParameter is not Term t) return;
        _db.DeleteTerm(t);
        Terms.Remove(t);
    }

    private void TermTitleUpdated(object sender, TextChangedEventArgs e)
    {
        var ent = sender as Entry;

        if (ent?.BindingContext is not Term t || e.NewTextValue == null) return;
        t.Title = e.NewTextValue;
        _db.UpdateTerm(t);
    }

    private void TermStartDateUpdated(object sender, DateChangedEventArgs e)
    {
        var dp = sender as DatePicker;

        if (dp?.BindingContext is not Term t) return;
        t.StartDate = e.NewDate;
        _db.UpdateTerm(t);
    }

    private void TermEndDateUpdated(object sender, DateChangedEventArgs e)
    {
        var dp = sender as DatePicker;

        if (dp?.BindingContext is not Term t) return;
        t.EndDate = e.NewDate;
        _db.UpdateTerm(t);
    }
}