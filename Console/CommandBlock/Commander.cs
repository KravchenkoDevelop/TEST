using BLL.Abstracts;
using System.Configuration;

namespace ConsoleApp.CommandBlock
{
    public class Commander
    {
        private readonly IEventService _eventService;

        public Commander(IEventService eventService)
        {
            _eventService = eventService;
        }

        public static void Greetings()
        {
            var message = FillGreetings();

            Console.WriteLine(message);
        }

        public static void Listener()
        {
            var rl = Console.ReadLine();

            var flag = new CommandsFlag();

            if (!string.IsNullOrEmpty(rl) && Enum.TryParse(rl, true, out flag))
            {

                switch (flag)
                {
                    case CommandsFlag.Help:
                        Greetings();
                        break;
                    case CommandsFlag.Add:
                        Console.WriteLine("input data for new event:"
                                          + "\n"
                                          + "header" + "\n"
                                          + "description"
                                          + "\n"
                                          + " date and time of event in format");
                        Console.ReadLine();
                        break;

                }

            }
            else
            {
                Console.WriteLine("please, input correct command");
            }
        }

        private static string FillGreetings()
        {
            string message = "";

            try
            {
                var filename = "";
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
