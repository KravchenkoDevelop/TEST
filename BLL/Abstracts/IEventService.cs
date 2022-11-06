using DM;

namespace BLL
{
    public interface IEventService
    {
        /// <summary>
        /// add neew event
        /// </summary>
        /// <param name="evt"></param>
        /// <returns></returns>
        public string AddEvent(EventModel evt);

        /// <summary>
        /// set deletetd status to event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public bool RemoveEvent(Guid eventId);

        /// <summary>
        /// get event by id
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public EventModel GetEvent(Guid eventId);

        /// <summary>
        /// get all events
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EventModel> GetEvents();

        /// <summary>
        /// update event
        /// </summary>
        /// <param name="evt"></param>
        /// 
        public void UpdateEvent(EventModel evt);

        public IEnumerable<EventModel> GetEventsByParam(DateTime dateTime, EventFlag flag);
    }
}
