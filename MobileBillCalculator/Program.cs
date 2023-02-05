
static decimal BillCalculator(DateTime startTime, DateTime endTime)
{
    bool isOverLap = false;
    decimal totalBill = 0;
    DateTime PeakHourStart = new DateTime(startTime.Year, startTime.Month, startTime.Day, 9, 0, 0);
    DateTime PeakHourEnd = new DateTime(startTime.Year, startTime.Month, startTime.Day, 22, 59, 59);

    DateTime timeNow = startTime;
    if (!(endTime.TimeOfDay > PeakHourStart.TimeOfDay && endTime.TimeOfDay < PeakHourEnd.TimeOfDay) )
    {
        isOverLap = (startTime.TimeOfDay > PeakHourStart.TimeOfDay && startTime.TimeOfDay < PeakHourEnd.TimeOfDay);
    }
    
    while (timeNow <= endTime)
    {
        timeNow = timeNow.AddSeconds(20);

        if (timeNow <= endTime)
        {
            decimal rate = isOverLap ? 30 : (timeNow.TimeOfDay > PeakHourStart.TimeOfDay && timeNow.TimeOfDay < PeakHourEnd.TimeOfDay) ? 30 : 20;
            totalBill = totalBill + rate;
        }

    }
    if (endTime <= timeNow)
    {
        var x = endTime - timeNow;
        timeNow = timeNow.AddSeconds(x.Seconds);
        decimal rate = isOverLap ? 30 : (timeNow.TimeOfDay >= PeakHourStart.TimeOfDay && timeNow.TimeOfDay <= PeakHourEnd.TimeOfDay) ? 30 : 20;
        totalBill = totalBill + rate;

    }

    return totalBill/100;
}
DateTime startTime = DateTime.Parse(" 2019-08-31 08:59:13 am");
DateTime endTime = DateTime.Parse("2019-08-31 09:00:39 am");
//DateTime startTime = DateTime.Parse(" 2019-09-29 10:59:55 pm");
//DateTime endTime = DateTime.Parse("2019-09-29 11:00:09 pm");
//DateTime startTime = DateTime.Parse(" 2019-09-29 11:59:47 pm");
//DateTime endTime = DateTime.Parse("2019-09-30 12:00:15 am");
var bill = BillCalculator(startTime, endTime);
Console.WriteLine(bill+" taka");
Console.ReadLine();


