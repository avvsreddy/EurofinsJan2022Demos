using KnowledgeHubPortal.Data;
using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;
using KnowledgeHubPortal.MVCWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Humanizer;

namespace KnowledgeHubPortal.MVCWebApplication.Controllers
{
    public class ArticlesController : Controller
    {
        // GET: Articles

        // DI
        IKnowledgeHubProtalRepository repo = new KnowledgeHubProtalRepository();

        public ActionResult Index()
        {
            var articlesToBrowse = (from a in repo.BrowseArticles()
                                   select new ArticleBrowseViewModel
                                   {
                                       Title = a.Title,
                                       ArticleUrl = a.ArticleUrl,
                                       Description = a.Description,
                                       Contributor = a.Contributor
                                   }).ToList();

            return View(articlesToBrowse);
        }

        [HttpGet]
        public ActionResult Submit()
        {

            var dropDownData = (from c in repo.GetCatagories()
                               select new SelectListItem { Value = c.CatagoryId.ToString(), Text = c.Name }).ToList();
            //dropDownData.Prepend(new SelectListItem { Text = "Select Catagory", Value="0"});
            ViewBag.CatagoryID = dropDownData;

            return View();
        }

        [HttpPost]
        public ActionResult Submit(ArticleSubmitViewModel articleSubmitViewModel)
        {

            if(!ModelState.IsValid)
                return View(articleSubmitViewModel);

            // convert view model to domain model - manually or auto (Automapper)
            Article articleToSubmit = new Article 
            {
                Title = articleSubmitViewModel.Title,
                ArticleUrl = articleSubmitViewModel.ArticleUrl,
                Description = articleSubmitViewModel.Description,
                CatagoryID = articleSubmitViewModel.CatagoryID,

                IsApproved = false,
                DateSubmitted = DateTime.Now,
                Contributor = User.Identity.Name
            };


            repo.SubmitArticle(articleToSubmit);
            TempData["Message"] = $"The article {articleSubmitViewModel.Title} is submitted successfully";
            // send email to admin
            return RedirectToAction("Submit");

        }

        [HttpGet]
        public ActionResult Approve()
        {
            var articlesApproveVM = (from a in repo.GetArticlesForApprove()
                                     select new ArticleApproveViewModel
                                     {
                                         ArticleID = a.ArticleID,
                                         Title = a.Title,
                                         ArticleUrl = a.ArticleUrl,
                                         Contributer = a.Contributor,
                                         Catagory = a.Catagory.Name,
                                         DateSubmitted = a.DateSubmitted.Humanize(false)
                                     }).ToList();
            
            return View(articlesApproveVM);
        }

        [HttpPost]
        public ActionResult Approve(List<int> articleid)
        {
            if (articleid == null || articleid.Count == 0)
            {
                TempData["Message"] = "You have not selected any articles";
                return RedirectToAction("Approve");
            }
            repo.ApproveArticles(articleid);
            TempData["Message"] = $"You have approved {articleid.Count}  articles";
            return RedirectToAction("Approve");

        }

        [HttpPost]
        public ActionResult Reject(List<int> articleid)
        {
            if (articleid == null || articleid.Count == 0)
            {
                TempData["Message"] = "You have not selected any articles";
                return RedirectToAction("Approve");
            }
            repo.RejectArticles(articleid);
            TempData["Message"] = $"You have rejected {articleid.Count}  articles";
            return RedirectToAction("Approve");

        }
    }
}