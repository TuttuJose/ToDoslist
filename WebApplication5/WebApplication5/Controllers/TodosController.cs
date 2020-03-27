using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class TodosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Todos
        public ActionResult Index()
        {
            //string currentUserID = User.Identity.GetUserId();
            //ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserID);
            //return View(db.ToDo.ToList().Where(x=> x.User == currentUser));
            return View();
        }


        // GET: Todos PartialView after add new Item
        public ActionResult BuildToDotable()
        {
            string currentUserID = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserID);
            return PartialView("_ToDoTable",db.ToDo.ToList().Where(x => x.User == currentUser));
        }
            
        // GET: Todos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todos todos = db.ToDo.Find(id);
            if (todos == null)
            {
                return HttpNotFound();
            }
            return View(todos);
        }

        // GET: Todos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Todos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,isDone")] Todos todos)
        {
            if (ModelState.IsValid)
            {
                string currentUserID = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserID);
                todos.User = currentUser;
                db.ToDo.Add(todos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxCreate([Bind(Include = "Id,Title")] Todos todos)
        {
            if (ModelState.IsValid)
            {
                string currentUserID = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserID);
                todos.User = currentUser;
                todos.isDone = false;
                db.ToDo.Add(todos);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            //string currentUserID1 = User.Identity.GetUserId();
            //ApplicationUser currentUser1 = db.Users.FirstOrDefault(x => x.Id == currentUserID1);
            //return PartialView("_ToDoTable", db.ToDo.ToList().Where(x => x.User == currentUser1));
            return View(todos);
        }


        public ActionResult CreatePopUp()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePopUp([Bind(Include = "Id,Title")] Todos todos)
        {
            if (ModelState.IsValid)
            {
                string currentUserID = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserID);
                todos.User = currentUser;
                todos.isDone = false;
                db.ToDo.Add(todos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //string currentUserID1 = User.Identity.GetUserId();
            //ApplicationUser currentUser1 = db.Users.FirstOrDefault(x => x.Id == currentUserID1);
            //return PartialView("_ToDoTable", db.ToDo.ToList().Where(x => x.User == currentUser1));
            return View(todos);
        }

        // GET: Todos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todos todos = db.ToDo.Find(id);
            if (todos == null)
            {
                return HttpNotFound();
            }
            return View(todos);
        }

        // POST: Todos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,isDone")] Todos todos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todos);
        }

        // GET: Todos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todos todos = db.ToDo.Find(id);
            if (todos == null)
            {
                return HttpNotFound();
            }
            return View(todos);
        }

        // POST: Todos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Todos todos = db.ToDo.Find(id);
            db.ToDo.Remove(todos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
