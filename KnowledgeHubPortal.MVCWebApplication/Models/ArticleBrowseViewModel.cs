using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeHubPortal.MVCWebApplication.Models
{
    public class ArticleBrowseViewModel
    {
        public string Title { get; set; }
        public string ArticleUrl { get; set; }
        public string Description { get; set; }
        public string Contributor { get; set; }
    }
}