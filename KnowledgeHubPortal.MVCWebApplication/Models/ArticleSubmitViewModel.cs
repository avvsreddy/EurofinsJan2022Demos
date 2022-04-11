using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnowledgeHubPortal.MVCWebApplication.Models
{
    public class ArticleSubmitViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [RegularExpression("((http|https)://)(www.)?[a-zA-Z0-9@:%._\\+~#?&//=]{2,256}\\.[a-z]{2,6}\\b([-a-zA-Z0-9@:%._\\+~#?&//=]*)")]
        public string ArticleUrl { get; set; }
        public string Description { get; set; }
        public int CatagoryID { get; set; }
    }
}