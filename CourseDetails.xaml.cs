using RonaldDuPreeJr_C971.Models;
using Plugin.LocalNotification;
using System.Collections.ObjectModel;

namespace RonaldDuPreeJr_C971;

public partial class CourseDetails : ContentPage
{
    public Course Selected { get; set; }
    public Course Course { get; set; }
    public ObservableCollection<string> StatusOptions { get; set; }
    private Database _db;


    public CourseDetails(Course course, Database db)
    {
        InitializeComponent();
        _db = db;
        Course = course;
        Selected = course;
        StatusOptions = new ObservableCollection<string> { "Planned", "In Progress", "Completed", "Dropped" };
        BindingContext = this;
        InitiateData();
    }

    private void InitiateData()
    {
        courseTitle.Text = Selected.Title;
        instructorName.Text = Course.InstructorName;
        instructorEmail.Text = Course.InstructorEmail;
        instructorPhone.Text = Course.InstructorPhone;
        notes.Text = Course.Notes;
        courseStartDate.Date = Selected.StartDate;
        courseEndDate.Date = Selected.EndDate;
        startDateNotifications.IsToggled = Course.StartDateNotification;
        endDateNotifications.IsToggled = Course.EndDateNotification;

        // get selected status from picker
        if (StatusOptions.Contains(Course.Status))
        {
            statusSelection.SelectedItem = Course.Status;
        }
    }

    private async void OnAssessmentClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AssessmentDetails(Selected.Id, _db));
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        // update the course details
        Course.Title = courseTitle.Text;
        Course.InstructorName = instructorName.Text;
        Course.InstructorEmail = instructorEmail.Text;
        Course.InstructorPhone = instructorPhone.Text;
        Course.Notes = notes.Text;
        Course.StartDate = courseStartDate.Date;
        Course.EndDate = courseEndDate.Date;
        Course.Status = statusSelection.SelectedItem as string;
        Course.StartDateNotification = startDateNotifications.IsToggled;
        Course.EndDateNotification = endDateNotifications.IsToggled;

        _db.UpdateCourse(Selected);
        await DisplayAlert("Save Complete", "Course details were saved.", "OK");

        // manage the notifications
        if (Course.StartDateNotification)
        {
            var startDateNotification = new NotificationRequest
            {
                Title = "Notification",
                Description = $"Start Date reminder for Course: {Selected.Title}",
                Schedule = new NotificationRequestSchedule
                {
                    // one day warning
                    NotifyTime = Selected.StartDate.AddDays(-1)
                }
            };
            await LocalNotificationCenter.Current.Show(startDateNotification);
        }

        if (!Course.EndDateNotification) return;
        var endDateNotification = new NotificationRequest
        {
            Title = "Notification",
            Description = $"End Date reminder for Course: {Selected.Title}",
            Schedule = new NotificationRequestSchedule
            {
                // one day warning
                NotifyTime = Selected.EndDate.AddDays(-1)
            }
        };
        await LocalNotificationCenter.Current.Show(endDateNotification);
    }

    private static async Task ShareNotes(string text)
    {
        await Share.Default.RequestAsync(new ShareTextRequest
        {
            Text = text,
            Title = "Share Note"
        });
    }

    private async void OnShareNotesClicked(object sender, EventArgs e)
    {
        await ShareNotes(notes.Text);
    }

    private void StartDateNotificationsToggled(object sender, ToggledEventArgs e)
    {
        Course.StartDateNotification = e.Value;
        _db.UpdateCourse(Course);
    }

    private void EndDateNotificationsToggled(object sender, ToggledEventArgs e)
    {
        Course.EndDateNotification = e.Value;
        _db.UpdateCourse(Course);
    }

    private void StatusSelectionChanged(object sender, EventArgs e)
    {
        if (statusSelection.SelectedItem == null) return;
        Course.Status = statusSelection.SelectedItem.ToString();
        _db.UpdateCourse(Course);
    }
}