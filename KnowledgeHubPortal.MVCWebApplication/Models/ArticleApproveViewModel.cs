using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeHubPortal.MVCWebApplication.Models
{
    public class ArticleApproveViewModel
    {
        public int ArticleID { get; set; }
        public string Title { get; set; }
        public string ArticleUrl { get; set; }

        public string Catagory { get; set; }
        public string Contributer { get; set; }
        public string DateSubmitted { get; set; }
    }
}