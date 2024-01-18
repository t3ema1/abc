using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Identity.Models.Meeting_data
{
    public class Attendee
    {
        [Key]
        public int Id { get; set; }

       
        [Required]
        public string Username { get; set; }
       

        // Navigation property to Meeting
        [Required]
        public int MeetingId { get; set; }
        [Required]
        public Meeting Meeting { get; set; }

        [Required]
        public string meeting_CreatedBy { get; set; }

        [Required]
        public DateTime MeetingDate { get; set; }
    }
}
