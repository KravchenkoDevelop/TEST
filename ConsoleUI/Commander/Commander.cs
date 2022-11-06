using BLL;
using DM;

namespace ConsoleUI
{
    public class Commander
    {
        private readonly IEventService _eventService;

        public Commander(IEventService eventService)
        {
            _eventService = eventService;
        }

        public void Greetings()
        {
            var message = FillGreetings();

            Console.WriteLine(message);
        }

        public void Listener()
        {
            var read = Console.ReadLine().Replace(" ", String.Empty);

            var cut = read.Substring(read.IndexOf('-') + 1);

            EventFlag eFlag;

            Enum.TryParse(cut, true, out eFlag);

            CommandsFlag cFlag;

            if (!string.IsNullOrEmpty(read) && Enum.TryParse(read, true, out cFlag))
            {
                switch (cFlag)
                {
                    case CommandsFlag.Help:
                        Greetings();
                        break;

                    case CommandsFlag.Add:
                        {
                            var newEvent = new EventModel();

                            Console.WriteLine("input data for new event:");
                            Console.WriteLine("header");
                            newEvent.Header = Console.ReadLine();
                            Console.WriteLine("description");
                            newEvent.Description = Console.ReadLine();
                            Console.WriteLine(" date and time of event in format :dd.mm.yyyy hh:mm");
                            newEvent.DateStart = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("input event lenth in hours");
                            newEvent.EventLengh = int.Parse(Console.ReadLine());

                            _eventService.AddEvent(newEvent);

                            break;
                        }

                    case CommandsFlag.GetAll:
                        {
                            var eventList = _eventService.GetEvents();
                            if (eventList.Any())
                            {
                                foreach (var e in eventList)
                                {
                                    Console.WriteLine($"event:"
                                                        + "\n"
                                                        + $"event ID: {e.Id}"
                                                        + "\n"
                                                        + $"event header: {e.Header}"
                                                        + "\n"
                                                        + $" event descr: {e.Description}"
                                                        + "\n"
                                                        + $" event time begining: {e.DateStart}"
                                                        + "\n"
                                                        + $" event lenght: {e.EventLengh} h"
                                                        + "\n"
                                                        + "-----------------------------------");
                                }
                            }
                            else
                            {
                                Console.WriteLine("no actual events, you're can go and drink some coffe");
                            }

                            break;
                        }

                    case CommandsFlag.Update:
                        {
                            var updEvent = new EventModel();

                            Console.WriteLine("please input event guid");
                            var id = Guid.Parse(Console.ReadLine());
                            Console.WriteLine("header");
                            updEvent.Header = Console.ReadLine();
                            Console.WriteLine("description");
                            updEvent.Description = Console.ReadLine();
                            Console.WriteLine(" date and time of event in format :dd.mm.yyyy hh:mm");
                            updEvent.DateStart = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("\n");

                            _eventService.UpdateEvent(updEvent);

                            break;
                        }


                    case CommandsFlag.MyEvents:
                        {
                            var eventList = _eventService.GetEventsByParam(DateTime.Now, eFlag);
                            foreach (var e in eventList)
                            {
                                Console.WriteLine($"event:"
                                                    + "\n"
                                                    + $"event ID: {e.Id}"
                                                    + "\n"
                                                    + $"event header: {e.Header}"
                                                    + "\n"
                                                    + $" event descr: {e.Description}"
                                                    + "\n"
                                                    + $" event time begining: {e.DateStart}"
                                                    + "\n"
                                                    + $" event lenght: {e.EventLengh} h"
                                                    + "\n"
                                                    + "-----------------------------------");
                            }

                            break;
                        }


                    case CommandsFlag.Remove:
                        {
                            Console.WriteLine("please input event guid");
                            var id = Guid.Parse(Console.ReadLine());

                            _eventService.RemoveEvent(id);

                            break;
                        }

                    case CommandsFlag.GetEvent:
                        {
                            Console.WriteLine("please input event guid");
                            var id = Guid.Parse(Console.ReadLine());

                            _eventService.GetEvent(id);

                            break;
                        }

                    default:
                        Console.WriteLine("please input correct command");
                        break;
                }
                read = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("please, input correct command");
            }
        }

        private string FillGreetings()
        {
            string message = "";

            try
            {
                var filename = "GreetingMessage.txt";
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

                StreamReader sr = new StreamReader(path);
                message = sr.ReadToEnd();
                sr.Close();

                return message;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return message;
            }
        }
    }
}
