using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Identity.Models.Meeting_data
{
    public class Meeting
    {

        [Key]

        public int Id { get; set; }

        [Required]
        public string MeetingName { get; set; }

        [Required]
        public string MeetingType { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string MeetingLocation { get; set; }

        [Required]
        public string MeetingLink { get; set; }
        [NotMapped]
        public ICollection<string> AttendeeUsernames { get; set; }
        [Required]
        public string CreatedBy { get; set; }


        [Required]
        public DateTime AnnouncementDate { get; set; }
        [Required]

        public DateTime MeetingDate { get; set; }


    }
}
