using FTOptix.HMIProject;
using FTOptix.NetLogic;
using System;
using UAManagedCore;

public class DateAddUpdateLogic : BaseNetLogic
{
    public override void Start()
    {
        // Code to execute when the user-defined logic is started
    }

    public override void Stop()
    {
        // Code to execute when the user-defined logic is stopped
    }

    [ExportMethod]
    public void DateUpdateTask()
    {
        // Safely get and update DailyReportDateTO
        var dailyReportDateVar = Project.Current.GetVariable("Model/DailyReportDateTO");
        if (dailyReportDateVar != null)
        {
            DateTime time1date = dailyReportDateVar.Value;
            Project.Current.GetVariable("Model/Reports/Daily Date To").Value = time1date.Add(new TimeSpan(23, 59, 59));
        }

        // Safely get and update AlarmReportDateTO
        var alarmReportDateVar = Project.Current.GetVariable("Model/AlarmReportDateTO");
        if (alarmReportDateVar != null)
        {
            DateTime time2date = alarmReportDateVar.Value;
            Project.Current.GetVariable("Model/Reports/Forth Report/Dateto").Value = time2date.Add(new TimeSpan(23, 59, 59));
        }
    }
}
