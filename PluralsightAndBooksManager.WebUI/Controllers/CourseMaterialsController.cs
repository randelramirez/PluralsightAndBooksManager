using PluralsightAndBooksManager.Core;
using PluralsightAndBooksManager.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PluralsightAndBooksManager.WebUI.Controllers
{
    public class CourseMaterialsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: CourseMaterials
        public ActionResult Index(string search)
        {
            var courseMaterials = db.Courses.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                courseMaterials = courseMaterials.Where(c => c.Title.Contains(search)).AsQueryable();
            }
            ViewBag.TotalCourseMaterials = courseMaterials.Count();
            ViewBag.InCollectionTotal = courseMaterials.Where(c => c.IsInCollection == true).Count();
            ViewBag.Search = search;
            return View(courseMaterials.OrderBy(c => c.Title));
        }


        // GET: CourseMaterials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseMaterial courseMaterial = db.Courses.Find(id);
            if (courseMaterial == null)
            {
                return HttpNotFound();
            }
            return View(courseMaterial);
        }

        // GET: CourseMaterials/Create
        public ActionResult Create()
        { 
            return View();
        }

        // POST: CourseMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,IsInCollection")] CourseMaterial courseMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(courseMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseMaterial);
        }

        // GET: CourseMaterials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseMaterial courseMaterial = db.Courses.Find(id);
            if (courseMaterial == null)
            {
                return HttpNotFound();
            }
            return View(courseMaterial);
        }

        // POST: CourseMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,IsInCollection")] CourseMaterial courseMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseMaterial);
        }

        // GET: CourseMaterials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseMaterial courseMaterial = db.Courses.Find(id);
            if (courseMaterial == null)
            {
                return HttpNotFound();
            }
            return View(courseMaterial);
        }

        // POST: CourseMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseMaterial courseMaterial = db.Courses.Find(id);
            db.Courses.Remove(courseMaterial);
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
