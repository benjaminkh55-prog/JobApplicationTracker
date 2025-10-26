
using System;
using System.Collections.Generic;
using System.Linq;
using static JobApplicationTracker.JobApplication;

namespace JobApplicationTracker
{
    public class JobManager
    {
        public List<JobApplication> Applications { get; set; } = new();

        public void AddJob()
        {
            var job = new JobApplication();

            Console.Write("Företagsnamn: ");
            job.CompanyName = Console.ReadLine();

            Console.Write("Tjänstetitel: ");
            job.PositionTitle = Console.ReadLine();

            Console.Write("Önskad lön (kr): ");
            job.SalaryExpectation = int.Parse(Console.ReadLine());

            job.Status = (int)ApplicationStatus.Applied;
            job.ApplicationDate = DateTime.Now;

            Applications.Add(job);
            Console.WriteLine("Ansökan tillagd!");
        }

        public void UpdateStatus()
        {
            ShowAll();
            Console.Write("Ange företagsnamn att uppdatera: ");
            string company = Console.ReadLine();

            var job = Applications.FirstOrDefault(a => a.CompanyName.Equals(company, StringComparison.OrdinalIgnoreCase));

            if (job == null)
            {
                Console.WriteLine("Ingen ansökan hittades.");
                return;
            }

            Console.WriteLine("Välj ny status: 0=Applied, 1=Interview, 2=Offer, 3=Rejected");
            if (Enum.TryParse<ApplicationStatus>(Console.ReadLine(), out var newStatus))
            {
                job.Status = (int)newStatus;
                if (newStatus != ApplicationStatus.Applied)
                    job.ResponseDate = DateTime.Now;

                Console.WriteLine("Status uppdaterad!");
            }
            else
            {
                Console.WriteLine("Ogiltig status.");
            }
        }

        public void ShowAll()
        {
            if (!Applications.Any())
            {
                Console.WriteLine("Inga ansökningar registrerade.");
                return;
            }

            Console.WriteLine("\n--- Alla Ansökningar ---");
            foreach (var app in Applications)
            {
                PrintWithColor(app);
            }
        }

        private void PrintWithColor(JobApplication app)
        {
            switch (app.Status)
            {
                case (int)ApplicationStatus.Offer: Console.ForegroundColor = ConsoleColor.Green; break;
                case (int)ApplicationStatus.Rejected: Console.ForegroundColor = ConsoleColor.Red; break;
                case (int)ApplicationStatus.Interview: Console.ForegroundColor = ConsoleColor.Yellow; break;
                default: Console.ResetColor(); break;
            }
            Console.WriteLine(app.GetSummary());
            Console.ResetColor();
        }

        public void ShowByStatus()
        {
            Console.WriteLine("Ange status att filtrera (Applied, Interview, Offer, Rejected): ");
            string input = Console.ReadLine();

            if (Enum.TryParse<ApplicationStatus>(input, true, out var status))
            {
                var filtered = Applications.Where (a => a.Status == (int)status).ToList();

                Console.WriteLine($"\n--- Ansökningar med status: {status} ---");
                foreach (var app in filtered)
                    PrintWithColor(app);
            }
            else
            {
                Console.WriteLine("Ogiltig status.");
            }
        }

        public void ShowStatistics()
        {
            Console.WriteLine("\n--- Statistik ---");
            Console.WriteLine($"Totalt antal ansökningar: {Applications.Count}");

            var byStatus = Applications
                .GroupBy(a => a.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() });

            foreach (var s in byStatus)
                Console.WriteLine($"{s.Status,-10}: {s.Count}");

            var averageResponse = Applications
                .Where(a => a. ResponseDate != null)
                .Average(a => (a. ResponseDate - a.ApplicationDate).TotalDays);

            Console.WriteLine($"Genomsnittlig svarstid: {averageResponse:F1} dagar");
        }

        public void SortByDate()
        {
            var ordered = Applications.OrderBy(a => a.ApplicationDate);
            Console.WriteLine("\n--- Sorterade efter datum ---");
            foreach (var app in ordered)
                PrintWithColor(app);
        }

        public void RemoveApplication()
        {
            Console.Write("Ange företagsnamn att ta bort: ");
            string company = Console.ReadLine();

            var job = Applications.FirstOrDefault(a => a.CompanyName.Equals(company, StringComparison.OrdinalIgnoreCase));

            if (job != null)
            {
                Applications.Remove(job);
                Console.WriteLine("Ansökan borttagen.");
            }
            else
            {
                Console.WriteLine("Ingen ansökan hittades.");
            }
        }
    }
}




