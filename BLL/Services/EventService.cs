using DAL;
using DM;
using Microsoft.Extensions.Logging;

namespace BLL
{
    public class EventService : IEventService
    {
        private  IRepository<EventModel> _repository;

        public EventService(IRepository<EventModel> repository)
        {
            _repository = repository;
        }

        public EventModel GetEvent(Guid eventId)
        {
            return _repository.Get(eventId);
        }

        public IEnumerable<EventModel> GetEvents()
        {
            return _repository.GetAll().Where(e => e.IsDeleted == false).OrderBy(e => e.DateStart);
        }

        public bool RemoveEvent(Guid eventId)
        {
            var rEvent = _repository.Get(eventId);
            rEvent.IsDeleted = false;
            _repository.Update(rEvent);

            var message = $"was deleted event:"
                            + "\n"
                            + $"event id: {rEvent.Id}";
            Console.WriteLine(message);
            return true;
        }

        public void UpdateEvent(EventModel evt)
        {
            _repository.Update(evt);

            var message = $"was updated event:"
                            + "\n"
                            + $"event id: {evt.Id}"
                            + "\n"
                            + $"event header: {evt.Header}"
                            + "\n"
                            + $" event descr: {evt.Description}"
                            + "\n"
                            + $" event time: {evt.DateStart}"
                            + "\n"
                            + $" event lenght: {evt.EventLengh}"
                            + "\n"
                            + $" event staus: {evt.IsDeleted}";

            Console.WriteLine(message);
        }

        public string AddEvent(EventModel evt)
        {
            var message = $"was created event with:"
                            + "\n"
                            + $"event header: {evt.Header}"
                            + "\n"
                            + $" event descr: {evt.Description}"
                            + "\n"
                            + $" event time: {evt.DateStart}"
                            + "\n"
                            + $" event lenght: {evt.EventLengh}";

            _repository.Add(evt);

            return message;
        }


        public IEnumerable<EventModel> GetEventsByParam(DateTime dateTime, EventFlag flag)
        {
            switch (flag)
            {
                case EventFlag.Tomorow:
                    return _repository.GetAll().Where(e => e.DateStart.Date == dateTime.Date.AddDays(1));
                case EventFlag.Today:
                    return _repository.GetAll().Where(e => e.DateStart == dateTime.Date);
                case EventFlag.NextHour:
                    return _repository.GetAll().Where(e => e.DateStart.Hour >= dateTime.Hour);
                case EventFlag.Recent:
                    return _repository.GetAll().Where(e => e.DateStart.Date <= dateTime);
                default:
                    Console.WriteLine("no actual events, you're can go and drink some coffe");
                    return Enumerable.Empty<EventModel>();
            }
        }
    }
}
