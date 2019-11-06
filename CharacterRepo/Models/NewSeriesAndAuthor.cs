using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace CharacterRepo.Models
{
    public class NewSeriesAndAuthor
    {
        
        public List<SelectListItem> AllAuthors { get; set; }

        [Display(Name = "New Series or Book Title")]
        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(50, ErrorMessage = "The {0} must be no more than {1} characters")]
        public string NewSeriesName { get; set; }

        [Display(Name = "Select an Author")]
        public int SelectAuthorID { get; set; }

        [Display(Name = "Or add a new Author")]
        public string NewAuthorName { get; set; }
        
        public void SetAuthorList(List<AuthorBO> authors)
        {
            if (AllAuthors == null)
            {
                AllAuthors = new List<SelectListItem>();
            }
            else
            {
                AllAuthors.Clear();
            }
            foreach (AuthorBO author in authors)
            {
                SelectListItem item = new SelectListItem();
                item.Value = author.AuthorID.ToString();
                item.Text = author.Name;
                AllAuthors.Add(item);
            }
            
        }
    }
}