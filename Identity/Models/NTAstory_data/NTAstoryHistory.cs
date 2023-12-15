namespace Identity.Models.NTAstory_data
{
    public class NTAstoryHistory
    {


        public int Id { get; set; }
        public int StoryId { get; set; }

        public string Header { get; set; }

        public string CreatedBy { get; set; }  
        public DateTime CreationDate { get; set; }  

        public DateTime LastUpdatedDate { get; set; } 

        public string LastUpdatedBy { get; set; }



    }
}
