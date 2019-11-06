using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BusinessLayer;

namespace CharacterRepo.Models
{
    public class SeriesAuthor
    {
        public int SeriesID { get; set; }

        [Display(Name = "Series or Book Title")]
        public string SeriesTitle { get; set; }

        [Display(Name = "Authors Name")]
        public string AuthorName { get; set; }

    }
}