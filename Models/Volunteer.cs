using System.Collections.Generic;

namespace EventManagementSystemADV.Models
{
    public class Volunteer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public ICollection<Event> Events { get; set; } = new List<Event>();
        public ICollection<EventVolunteer> EventVolunteers { get; set; }

    }
}
