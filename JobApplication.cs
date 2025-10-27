

namespace JobApplicationTracker
{
    public class JobApplication

    {
        public int Status { get; internal set; }
        public string? CompanyName { get; internal set; }
        public string? PositionTitle { get; internal set; }
        public int SalaryExpectation { get; internal set; }
        public DateTime ApplicationDate { get; internal set; }
        public DateTime ResponseDate { get; internal set; }

        internal bool GetSummary()
        {
            Console.WriteLine($"{CompanyName} - {PositionTitle} - {Status} - {ApplicationDate.ToShortDateString()} - {SalaryExpectation} kr");
        }

        public enum ApplicationStatus
        {
            Applied,
            Interviewing,
            Offered,
            Rejected,
            Accepted,
            Offer,
            Interview
        }

        public class jobapplication
        {
            public string CompanyName { get; set; }
            public string Position { get; set; }
            public DateTime ApplicationDate { get; set; }
            public ApplicationStatus Status { get; set; }
            public int salaryExpectation { get; set; }
            public object PositionTitle { get; private set; }
            public object SalaryExpectation { get; private set; }

            
            public int getdaysSinceApplication()
            {
                return (DateTime.Now - ApplicationDate).Days;
            }

            public string getsummary()
            {
                return $"{CompanyName,-20} | {PositionTitle,-15} | {Status,-10} | {ApplicationDate:yyyy-MM-dd} | {SalaryExpectation} kr";
            }
        }

    }
}

