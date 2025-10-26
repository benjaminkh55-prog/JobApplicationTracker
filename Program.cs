namespace JobApplicationTracker
{
    public class Program
    {
        static void Main(string[] args)
        {
                var manager = new JobManager();
                bool running = true;

                while (running)
                {
                    Console.WriteLine("\n==== JOB APPLICATION TRACKER ====");
                    Console.WriteLine("1. Lägg till ny ansökan");
                    Console.WriteLine("2. Visa alla ansökningar");
                    Console.WriteLine("3. Filtrera efter status");
                    Console.WriteLine("4. Sortera efter datum");
                    Console.WriteLine("5. Visa statistik");
                    Console.WriteLine("6. Uppdatera status");
                    Console.WriteLine("7. Ta bort ansökan");
                    Console.WriteLine("0. Avsluta");
                    Console.Write("Välj ett alternativ: ");

                    switch (Console.ReadLine())
                    {
                        case "1": manager.AddJob(); break;
                        case "2": manager.ShowAll(); break;
                        case "3": manager.ShowByStatus(); break;
                        case "4": manager.SortByDate(); break;
                        case "5": manager.ShowStatistics(); break;
                        case "6": manager.UpdateStatus(); break;
                        case "7": manager.RemoveApplication(); break;
                        case "0": running = false; break;
                        default: Console.WriteLine(" Ogiltigt val."); break;
                    }
                }

                Console.WriteLine(" Programmet avslutas. Tack för att du använde Job Tracker!");
            
        }
    }





}
   
