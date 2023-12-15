using System.ComponentModel.DataAnnotations;

namespace Identity.Models.published_data
{
    public class AdminAnnouncement
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public int AnnouncementId { get; set; }


        [Required]
        public string LabelName { get; set; }

        [Required]
        public string MessageBody { get; set; }

        [Required]
        public int PublishedTo { get; set; }

        public DateTime AnnouncementDate { get; set; }
    }
}
