﻿using System.ComponentModel.DataAnnotations;

namespace Identity.Models.NTAstory_data
{
    public class NTAstory
    {


        [Key]
        public int Id { get; set; }
       

        [Required]
        public string Header { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public int PublishedTo { get; set; }

        public DateTime AnnouncementDate { get; set; }


    }
}
