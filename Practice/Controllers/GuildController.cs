using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practice.Models;

namespace Practice.Controllers
{
    public class GuildController : Controller
    {
        private GuildDBContext db = new GuildDBContext();

        //
        // GET: /Guild/

        public ActionResult Index()
        {
            return View(db.Guilds.ToList());
        }

        //
        // GET: /Guild/Details/5

        public ActionResult Details(string id = null)
        {
            Guild guild = db.Guilds.Find(id);
            if (guild == null)
            {
                return HttpNotFound();
            }
            return View(guild);
        }

        //
        // GET: /Guild/Create

        public ActionResult Create()
        {
            return View();
        }

        static string[] TEAM = { "Fox", "Penguin", "Bear" };
        //
        // POST: /Guild/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Guild guild)
        {
            if (ModelState.IsValid)
            {
                guild.Team = TEAM[new Random(Environment.TickCount).Next(3)];
                db.Guilds.Add(guild);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guild);
        }

        //
        // GET: /Guild/Edit/5
        public ActionResult Edit(string id = null)
        {
            Guild guild = db.Guilds.Find(id);
            if (guild == null)
            {
                return HttpNotFound();
            }
            return View(guild);
        }

        //
        // POST: /Guild/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guild guild)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guild).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guild);
        }

        //
        // GET: /Guild/Delete/5

        public ActionResult Delete(string id = null)
        {
            Guild guild = db.Guilds.Find(id);
            if (guild == null)
            {
                return HttpNotFound();
            }
            return View(guild);
        }

        //
        // POST: /Guild/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Guild guild = db.Guilds.Find(id);
            db.Guilds.Remove(guild);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}