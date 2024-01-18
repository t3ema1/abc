using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string LabelName { get; set; }

        [Required]
        public string MessageBody { get; set; }

        [Required]
        public int PublishedTo { get; set; }

        [Required]
        public string Createdby { get; set; }


        public DateTime AnnouncementDate { get; set; }
    }
}
