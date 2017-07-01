namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Timetable info
    /// </summary>
    public class TimeTableInfo
    {
        /// <summary>
        /// Contains date for start and end date of current time table
        /// </summary>
        public TimeTablePeriod TimetablePeriod { get; set; }

        /// <summary>
        /// Contains creation date for current time table
        /// </summary>
        public TimeTableData TimeTableData { get; set; }
    }
}