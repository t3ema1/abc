namespace Identity.Models.Announcement_data
{
    public class AnnouncementHistory
    {


        public int Id { get; set; }
        public int AnnouncementId { get; set; }

        public string LabelName { get; set; }

        public string CreatedBy { get; set; }  
        public DateTime CreationDate { get; set; } 

        public DateTime LastUpdatedDate { get; set; }  

        public string LastUpdatedBy { get; set; }


    }
}
