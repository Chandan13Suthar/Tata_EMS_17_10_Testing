#region Using directives
using System;
using CoreBase = FTOptix.CoreBase;
using FTOptix.HMIProject;
using UAManagedCore;
using FTOptix.UI;
using FTOptix.NetLogic;
using FTOptix.WebUI;
using FTOptix.ODBCStore;
using FTOptix.System;
using FTOptix.OPCUAServer;
using FTOptix.OPCUAClient;
using FTOptix.MicroController;
using FTOptix.CommunicationDriver;
using FTOptix.AuditSigning;
using FTOptix.Alarm;
using FTOptix.RAEtherNetIP;
#endregion

public class CurrentDateTimeFormatted : BaseNetLogic
{
	public override void Start()
	{
		periodicTask = new PeriodicTask(UpdateTime, 1000, LogicObject);
		periodicTask.Start();


    }

    public override void Stop()
	{
		periodicTask.Dispose();
		periodicTask = null;
	}



	private void UpdateTime()
	{
		LogicObject.GetVariable("Time").Value = DateTime.Now;
		LogicObject.GetVariable("UTCTime").Value = DateTime.UtcNow;
		//Project.Current.GetVariable("Model/intDay").Value = DateTime.Now.Day;
		int YearVar = DateTime.Now.Year;
		int MonthVar = DateTime.Now.Month;
		int DayVar = DateTime.Now.Day;
		int HourVar = DateTime.Now.Hour;
		int MinVar = DateTime.Now.Minute;
		int SecVar = DateTime.Now.Second;
		String stMonth = "01";
		String stDay = "01";
		String stHour = "01";
		String stMin = "01";
		String stSec = "01";
		String dateFor = "DDMMYYYY";
		String DateFormatted = "01/02/2023";
		String TimeFormatted = "00:00:00";
        DateTime currentTime = DateTime.Now;
        DateTime todaydate = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0);

 
        //Month formatting
        if (MonthVar < 10)
        {
            stMonth = "0" + MonthVar;
        }
        else
        {
            stMonth = MonthVar.ToString();
        }
		//Day formatting
		if (DayVar < 10)
        {
            stDay = "0" + DayVar;
        }
        else
        {
            stDay = DayVar.ToString();
        }
		//Hour formatting
		if (HourVar < 10)
        {
            stHour = "0" + HourVar;
        }
        else
        {
            stHour = HourVar.ToString();
        }
		//Minute formatting
		if (MinVar < 10)
        {
            stMin = "0" + MinVar;
        }
        else
        {
            stMin = MinVar.ToString();
        }
		//Second formatting
		if (SecVar < 10)
        {
            stSec= "0" + SecVar;
        }
        else
        {
            stSec = SecVar.ToString();
        }


        if (HourVar == 00 && MinVar == 10 && SecVar == 00)
        {
            Project.Current.GetVariable("Model/Histo Dashboard/Datefrom").Value = todaydate;
            Project.Current.GetVariable("Model/Histo Dashboard/Dateto").Value = todaydate;
            Project.Current.GetVariable("Model/Comparision_Dashboard/Datefrom").Value = todaydate;
            Project.Current.GetVariable("Model/Comparision_Dashboard/Dateto").Value = todaydate;
            Project.Current.GetVariable("Model/Reports/Third Report/Date").Value = todaydate;
            Project.Current.GetVariable("Model/Reports/DailyDateFrom").Value = todaydate;
            Project.Current.GetVariable("Model/Reports/Daily Date To").Value = todaydate;
            Project.Current.GetVariable("Model/Reports/Third Report/Date1").Value = todaydate;
            Project.Current.GetVariable("Model/Reports/Forth Report/Datefrom").Value = todaydate;
            Project.Current.GetVariable("Model/Reports/Forth Report/Dateto").Value = todaydate;
			Project.Current.GetVariable("Model/Reports/HarmonicsReport/DateTo").Value = todaydate;
            Project.Current.GetVariable("Model/Reports/HarmonicsReport/DateTest").Value = todaydate;
			Project.Current.GetVariable("Model/Comparision_Dashboard/Dateto").Value = todaydate;
            ///// Logic for Reset Production and Target value///////////////////
            var production = Project.Current.GetVariable("Model/HomePageHistogram/HomePage2/PRoduction_And_Target/ProductionCount");
            var T33KV = Project.Current.GetVariable("Model/HomePageHistogram/HomePage2/PRoduction_And_Target/Target33KV");
            var TUtility = Project.Current.GetVariable("Model/HomePageHistogram/HomePage2/PRoduction_And_Target/TargetUtility");
            var TPump = Project.Current.GetVariable("Model/HomePageHistogram/HomePage2/PRoduction_And_Target/TargetPumpRoom");
            var TPaint = Project.Current.GetVariable("Model/HomePageHistogram/HomePage2/PRoduction_And_Target/TargetPaintShop");
            var TBody = Project.Current.GetVariable("Model/HomePageHistogram/HomePage2/PRoduction_And_Target/TargetBodyshop");
            var TTcf = Project.Current.GetVariable("Model/HomePageHistogram/HomePage2/PRoduction_And_Target/TargetTCF");
            var TStamping = Project.Current.GetVariable("Model/HomePageHistogram/HomePage2/PRoduction_And_Target/TargetStamping");
            var TAdmin = Project.Current.GetVariable("Model/HomePageHistogram/HomePage2/PRoduction_And_Target/TargetAdmin");
            var TSpp = Project.Current.GetVariable("Model/HomePageHistogram/HomePage2/PRoduction_And_Target/TargetSPP");

            if (production != null)
            {
                var value = production.RemoteRead();
                Log.Info(value.ToString());
                production.RemoteWrite(0);
            }

            if (T33KV != null)
            {
                var value = T33KV.RemoteRead();
                Log.Info(value.ToString());
                T33KV.RemoteWrite(0);
            }

            if (TUtility != null)
            {
                var value = TUtility.RemoteRead();
                Log.Info(value.ToString());
                TUtility.RemoteWrite(0);
            }

            if (TPump != null)
            {
                var value = TPump.RemoteRead();
                Log.Info(value.ToString());
                TPump.RemoteWrite(0);
            }

            if (TPaint != null)
            {
                var value = TPaint.RemoteRead();
                Log.Info(value.ToString());
                TPaint.RemoteWrite(0);
            }

            if (TBody != null)
            {
                var value = TBody.RemoteRead();
                Log.Info(value.ToString());
                TBody.RemoteWrite(0);
            }

            if (TTcf != null)
            {
                var value = TTcf.RemoteRead();
                Log.Info(value.ToString());
                TTcf.RemoteWrite(0);
            }

            if (TStamping != null)
            {
                var value = TStamping.RemoteRead();
                Log.Info(value.ToString());
                TStamping.RemoteWrite(0);
            }

            if (TAdmin != null)
            {
                var value = TAdmin.RemoteRead();
                Log.Info(value.ToString());
                TAdmin.RemoteWrite(0);
            }

            if (TSpp != null)
            {
                var value = TSpp.RemoteRead();
                Log.Info(value.ToString());
                TSpp.RemoteWrite(0);
            }
            //////////////////////Logic for reset production and target ends//////////////////////
  
        }
        String DateOpt = Project.Current.GetVariable("Model/DateTime/DateOperator").Value;
		String TimeOpt = Project.Current.GetVariable("Model/DateTime/TimeOperator").Value;

		// Date Formatting
		dateFor = Project.Current.GetVariable("Model/DateTime/DateFormat").Value;
		if (dateFor == "DDMMYYYY")
		{
			DateFormatted = stDay + DateOpt + stMonth + DateOpt + YearVar;
		}
		else if (dateFor == "MMDDYYYY")
		{
			DateFormatted = stMonth + DateOpt + stDay + DateOpt + YearVar;
		}
		else if (dateFor == "YYYYMMDD")
		{
			DateFormatted = YearVar + DateOpt + stMonth + DateOpt + stDay;
		}
		else
		{
			DateFormatted = stDay + DateOpt + stMonth + DateOpt + YearVar;
		}

		// Time Formatting
		TimeFormatted = stHour + TimeOpt + stMin + TimeOpt + stSec;

		Project.Current.GetVariable("Model/DateTime/DateFormatted").Value = DateFormatted;
		Project.Current.GetVariable("Model/DateTime/TimeFormatted").Value = TimeFormatted;
		Project.Current.GetVariable("Model/DateTime/DateTimeFormatted").Value = DateFormatted + " " + TimeFormatted;

		Project.Current.GetVariable("Model/DateTime/CurrDateTime/Year").Value = YearVar.ToString();
		Project.Current.GetVariable("Model/DateTime/CurrDateTime/Month").Value = stMonth;
		Project.Current.GetVariable("Model/DateTime/CurrDateTime/Day").Value = stDay;
		Project.Current.GetVariable("Model/DateTime/CurrDateTime/Hour").Value = stHour;
		Project.Current.GetVariable("Model/DateTime/CurrDateTime/Minute").Value = stMin;
		Project.Current.GetVariable("Model/DateTime/CurrDateTime/Second").Value = stSec;
	}

	private PeriodicTask periodicTask;
}
