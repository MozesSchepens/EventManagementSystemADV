using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventManagementSystemADV.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Volunteer> Volunteers { get; set; } = new List<Volunteer>();
    }
}
