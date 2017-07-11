using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using PagedList;

namespace WebApplication.Controllers
{
    public class MyTasksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MyTasks
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            IEnumerable<MyTask> tasks = db.MyTasks.OrderByDescending(x=>x.DueDate).ToPagedList(page, pageSize);
            return View(tasks);
        }

        // GET: MyTasks/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTask myTask = db.MyTasks.Find(id);
            if (myTask == null)
            {
                return HttpNotFound();
            }
            return View(myTask);
        }

        // GET: MyTasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TaskName,PlanedStartDate,PlanedEndDate,ActualStartDate,ActualEndDate,AssigneeID,ReporterID,PercentDone,Status,Attachment,CommentID,CreateDate,DueDate,ModifyDate")] MyTask myTask)
        {
            if (ModelState.IsValid)
            {
                db.MyTasks.Add(myTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myTask);
        }

        // GET: MyTasks/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTask myTask = db.MyTasks.Find(id);
            if (myTask == null)
            {
                return HttpNotFound();
            }
            return View(myTask);
        }

        // POST: MyTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TaskName,PlanedStartDate,PlanedEndDate,ActualStartDate,ActualEndDate,AssigneeID,ReporterID,PercentDone,Status,Attachment,CommentID,CreateDate,DueDate,ModifyDate")] MyTask myTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myTask);
        }

        // GET: MyTasks/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTask myTask = db.MyTasks.Find(id);
            if (myTask == null)
            {
                return HttpNotFound();
            }
            return View(myTask);
        }

        // POST: MyTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            MyTask myTask = db.MyTasks.Find(id);
            db.MyTasks.Remove(myTask);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
