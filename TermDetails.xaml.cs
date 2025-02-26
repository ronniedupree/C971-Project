using System.Collections.ObjectModel;
using RonaldDuPreeJr_C971.Models;
using RonaldDuPreeJr_C971.Services;

namespace RonaldDuPreeJr_C971;

public partial class TermDetails : ContentPage
{
    public Term Term { get; set; }
    public ObservableCollection<Course> Courses { get; set; }
    private Database _db;

    public TermDetails(Term term, Database database)
    {
        InitializeComponent();
        _db = database;
        Term = term;
        Courses = new ObservableCollection<Course>(_db.GetCoursesByTermId(term.Id));
        BindingContext = this;
    }

    private void OnAddCourseClicked(object sender, EventArgs e)
    {
        // add new course to the list
        var c = new Course { TermId = Term.Id };
        Courses.Add(c);
        DataHelper.AddCourse(c);

        InitializeComponent();
    }

    private void ViewCourseClicked(object sender, EventArgs e)
    {
        var c = (sender as Button)?.CommandParameter as Course;
        // open course details page
        Navigation.PushAsync(new CourseDetails(c, _db));
    }

    private void DeleteCourseClicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.CommandParameter is not Course c) return;
        _db.DeleteCourse(c);
        Courses.Remove(c);
    }
}