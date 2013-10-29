using Practice.Models;
using Practice.Models.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice.Controllers
{
    public class GuildViewController : Controller
    {
        private IGuildViewer Repository { get; set; }

        public GuildViewController() : this(new GuildViewRepository()) { }
        public GuildViewController(IGuildViewer repo)
        {
            Repository = repo;
        }

        //
        // GET: /GuildView/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /GuildView/Result/[query]
        [HttpGet]
        public ActionResult Result(string query)
        {
            try
            {
                return View(Repository.GetSqlResult(query));
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

    }
}
