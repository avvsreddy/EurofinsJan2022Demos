using KnowledgeHubPortal.Data;
using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeHubPortal.MVCWebApplication.Controllers
{
    public class CatagoriesController : Controller
    {
        // GET: Catagories

        // IoC - DI
        IKnowledgeHubProtalRepository repo = new KnowledgeHubProtalRepository();

        [HttpGet]
        public ActionResult Index()
        {

            // get all catagories from model and pass it to view
            var catagories = repo.GetCatagories();

            return View(catagories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            // return a view for collecting catagory details from user
            return View();
        }
        [HttpPost]
        public ActionResult Create(Catagory catagory)
        {
            // Validate the input
            //if(string.IsNullOrEmpty(catagory.Name))
            if (!ModelState.IsValid) 
            {
                return View("Create",catagory);
            }

            // persist the data
            repo.SaveCatagory(catagory);
            // return view
            //var catagories = repo.GetCatagories();

            //return View("Index", catagories);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            // fetch the remaining info from db by id
            Catagory catagoryToDelete = repo.GetCatagory(id);

            // return that info the view for confirmation
            return View(catagoryToDelete);
        }

        public ActionResult DeleteConfirm(int id)
        {
            Catagory catagoryToDelete = repo.GetCatagory(id);
            bool isDone = repo.RemoveCatagory(id);

            TempData["Message"] = $"{catagoryToDelete.Name} has been deleted successfully!";
            
            return RedirectToAction("Index");

        }
    }
}