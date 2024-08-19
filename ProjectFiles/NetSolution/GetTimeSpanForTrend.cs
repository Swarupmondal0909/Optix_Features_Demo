#region Using directives 
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.CoreBase;
using FTOptix.Core;
using FTOptix.NetLogic;
using FTOptix.DataLogger;
using FTOptix.Store;
using FTOptix.SQLiteStore;
using FTOptix.AuditSigning;
#endregion

public class GetTimeSpanForTrend : BaseNetLogic
{
[ExportMethod]

public void GetTimeSpanForTrend1()
{
//The Variables are created under \Model folder in this sample
var vStartTime = Project.Current.GetVariable("Model/StartTime");
var vStopTime = Project.Current.GetVariable("Model/StopTime");
TimeSpan vTimeSpan = DateTime.Parse(vStopTime.RemoteRead()).Subtract(DateTime.Parse(vStartTime.RemoteRead()));

var vTimeWindow = Project.Current.GetVariable("Model/TimeWindow");
var vIntervalInMs = vTimeSpan.TotalMilliseconds;
vTimeWindow.RemoteWrite(vIntervalInMs);
}
}
