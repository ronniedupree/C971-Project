using System.Collections.ObjectModel;
using RonaldDuPreeJr_C971.Models;

namespace RonaldDuPreeJr_C971.Services;

public static class DataHelper
{
    public static ObservableCollection<Term> Terms = [];
    public static ObservableCollection<Course> Courses = [];
    public static ObservableCollection<Assessment> Assessments = [];

    public static void Notifications()
    {
        DateTime currentDate = DateTime.Today;

        var db = new Database();
        db.Initialize();

        List<Course>? courseList = db.GetAllCourses();
        List<Assessment>? asmList = db.GetAllAssessments();

        courseList.ForEach(course =>
        {
            if (course.StartDateNotification && course.StartDate.Date == currentDate)
            {
                Notify("Reminder", $"{course.Title} starts today.");
            }
            if (course.EndDateNotification && course.EndDate.Date == currentDate)
            {
                Notify("Reminder", $"{course.Title} ends today");
            }
        });

        asmList.ForEach(assessment =>
        {
            if (assessment.StartDateNotification && assessment.StartDate.Date == currentDate)
            {
                Notify("Reminder", $"{assessment.Name} starts today");
            }
            if (assessment.EndDateNotification && assessment.EndDate.Date == currentDate)
            {
                Notify("Reminder", $"{assessment.Name} ends today");
            }
        });
        db.Close();
    }

    private static void Notify(string title, string message)
    {
        MainThread.InvokeOnMainThreadAsync(async () =>
        {
            await Launcher.TryOpenAsync("app-notifications://");
        });
    }

    public static void InitTermsList()
    {
        var db = new Database();
        db.Initialize();

        List<Term>? termsList = db.GetAllTerms();
        termsList.ForEach(term => Terms.Add(term));

        db.Close();
    }

    public static void AddTerm(Term term)
    {
        var db = new Database();
        db.Initialize();
        db.AddTerm(term);
        Terms.Add(term);

        db.Close();
    }

    public static void UpdateTerm(Term oTerm, Term nTerm)
    {
        List<Term> terms = Terms.ToList();
        Terms.Clear();

        var db = new Database();
        db.Initialize();
        db.UpdateTerm(nTerm);

        int index = terms.IndexOf(oTerm);
        terms.RemoveAt(index);
        terms.Insert(index, nTerm);
        terms.ForEach(term => Terms.Add(term));

        db.Close();
    }

    public static void DeleteTerm(Term term)
    {
        var db = new Database();
        db.Initialize();
        db.DeleteTerm(term);
        Terms.Remove(term);
        db.Close();
    }

    public static void InitCourseList(int termId)
    {
        Courses.Clear();
        var db = new Database();
        db.Initialize();

        List<Course>? courseList = db.GetCoursesByTermId(termId);
        courseList.ForEach(course => Courses.Add(course));

        db.Close();
    }

    public static void AddCourse(Course course)
    {
        var db = new Database();
        db.Initialize();
        db.AddCourse(course);
        Courses.Add(course);
        db.Close();
    }

    public static void UpdateCourse(Course oCourse, Course nCourse)
    {
        List<Course> courses = Courses.ToList();
        Courses.Clear();

        var db = new Database();
        db.Initialize();
        db.UpdateCourse(nCourse);

        int index = courses.IndexOf(oCourse);
        courses.RemoveAt(index);
        courses.Insert(index, nCourse);
        courses.ForEach(course => Courses.Add(course));

        db.Close();
    }

    public static void DeleteCourse(Course course)
    {
        var db = new Database();
        db.Initialize();
        db.DeleteCourse(course);
        Courses.Remove(course);
        db.Close();
    }

    public static void InitAssessmentList(int courseId)
    {
        Assessments.Clear();
        var db = new Database();
        db.Initialize();
        List<Assessment>? asmList = db.GetAssessmentsByCourseId(courseId);
        asmList.ForEach(assessment => Assessments.Add(assessment));
        db.Close();
    }

    public static void AddAssessment(Assessment asm)
    {
        var db = new Database();
        db.Initialize();
        db.AddAssessment(asm);
        Assessments.Add(asm);
        db.Close();
    }

    public static void UpdateAssessment(Assessment asm)
    {
        var db = new Database();
        db.Initialize();
        db.UpdateAssessment(asm);
        db.Close();

        var assessment = Assessments.FirstOrDefault(a => a.Id == asm.Id);
        if (assessment != null)
        {
            int i = Assessments.IndexOf(assessment);
            Assessments[i] = asm;
        }
    }

    public static void DeleteAssessment(Assessment asm)
    {
        var db = new Database();
        db.Initialize();
        db.DeleteAssessment(asm);
        Assessments.Remove(asm);
        db.Close();
    }
}