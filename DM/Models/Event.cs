namespace DM
{
    public class EventModel
    {
        /// <summary>
        /// event id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// event header/name
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// event desciption
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// event date start
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// event lenth in hours
        /// </summary>
        public int EventLengh { get; set; }

        /// <summary>
        /// event status
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
