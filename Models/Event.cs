using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagementSystemADV.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public bool IsDeleted { get; set; }
        public ICollection<Volunteer> Volunteers { get; set; } = new List<Volunteer>();
        public ICollection<EventVolunteer> EventVolunteers { get; set; }


    }
}
