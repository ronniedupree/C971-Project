using RonaldDuPreeJr_C971.Models;
using Plugin.LocalNotification;
using System.Collections.ObjectModel;

namespace RonaldDuPreeJr_C971;

public partial class AssessmentDetails : ContentPage
{
    public ObservableCollection<Assessment> Assessments { get; set; }
    private Database _db;
    public ObservableCollection<string> TypeOptions { get; set; }

    public AssessmentDetails(int courseId, Database db)
    {
        InitializeComponent();
        _db = db;
        TypeOptions = new ObservableCollection<string> { "Performance Assessment", "Objective Assessment" };
        Assessments = new ObservableCollection<Assessment>(_db.GetAssessmentsByCourseId(courseId));
        BindingContext = this;
        InitUi();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        InitUi();
    }

    // Method to initialize UI elements
    private void InitUi()
    {

        var assessmentName = this.FindByName<Entry>("assessmentNameEntry");
        var type = this.FindByName<Picker>("typePicker");
        var startDP = this.FindByName<DatePicker>("startDatePicker");
        var endDP = this.FindByName<DatePicker>("endDatePicker");
        var startDateSwitch = this.FindByName<Switch>("startDateNotificationSwitch");
        var endDateSwitch = this.FindByName<Switch>("endDateNotificationSwitch");

        // check ui elements for null
        if (assessmentName != null && type != null && startDP != null && endDP != null && startDateSwitch != null && endDateSwitch != null) { }
    }

    private void AddAssessmentClicked(object sender, EventArgs e)
    {
        // add a new assessment to the ist
        var assessment = new Assessment
        {
            Name = "",
            StartDateNotification = true,
            EndDateNotification = true,
            Type = TypeOptions[0],
            StartDate = DateTime.Today,
            EndDate = DateTime.Today.AddMonths(1)
        };

        _db.AddAssessment(assessment);
        Assessments.Add(assessment);
    }

    private void DeleteAssessmentClicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        if (btn != null)
        {
            var asm = btn.BindingContext as Assessment;
            if (asm != null)
            {
                _db.DeleteAssessment(asm);
                Assessments.Remove(asm);
            }
        }
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {

    }

    private void AssessmentNameChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        var asm = entry?.BindingContext as Assessment;

        if (asm != null && e.NewTextValue != null)
        {
            asm.Name = e.NewTextValue;
            _db.UpdateAssessment(asm);
        }
    }

    private void AssessmentStartDateChanged(object sender, DateChangedEventArgs e)
    {
        var dp = sender as DatePicker;
        var asm = dp?.BindingContext as Assessment;

        if (asm != null)
        {
            asm.StartDate = e.NewDate;
            _db.UpdateAssessment(asm);
        }
    }

    private void AssessmentEndDateChanged(object sender, DateChangedEventArgs e)
    {
        var dp = sender as DatePicker;
        var asm = dp?.BindingContext as Assessment;

        if (asm != null)
        {
            asm.EndDate = e.NewDate;
            _db.UpdateAssessment(asm);
        }
    }

    private async void StartDateNotificationToggled(object sender, ToggledEventArgs e)
    {
        var toggle = sender as Switch;
        var asm = toggle?.BindingContext as Assessment;

        if (asm != null)
        {
            asm.StartDateNotification = e.Value;
            _db.UpdateAssessment(asm);

            if (asm.StartDateNotification)
            {
                var start = new NotificationRequest
                {
                    Title = "Notification",
                    Description = $"Start Date reminder for Assessment: {asm.Name}",
                    Schedule = new NotificationRequestSchedule
                    {
                        // one day warning
                        NotifyTime = asm.StartDate.AddDays(-1)
                    }
                };
                await LocalNotificationCenter.Current.Show(start);
            }
        }
    }

    private async void EndDateNotificationToggled(object sender, ToggledEventArgs e)
    {
        var toggle = sender as Switch;
        var asm = toggle?.BindingContext as Assessment;

        if (asm != null)
        {
            asm.EndDateNotification = e.Value;
            _db.UpdateAssessment(asm);

            if (asm.EndDateNotification)
            {
                var endNotification = new NotificationRequest
                {
                    Title = "Notification",
                    Description = $"End Date reminder for Assessment: {asm.Name}",
                    Schedule = new NotificationRequestSchedule
                    {
                        // one day warning
                        NotifyTime = asm.EndDate.AddDays(-1)
                    }
                };
                await LocalNotificationCenter.Current.Show(endNotification);
            }
        }
    }

    private void TypePickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var pick = sender as Picker;
        var asm = pick?.BindingContext as Assessment;

        if (asm != null && pick != null)
        {
            asm.Type = (string)pick.SelectedItem;
            _db.UpdateAssessment(asm);
        }
    }
}