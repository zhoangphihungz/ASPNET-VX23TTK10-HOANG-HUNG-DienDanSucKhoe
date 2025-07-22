using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HealthWebApp_Authenticated.Models; // Thay thế bằng tên dự án của bạn

namespace HealthWebApp_Authenticated.Controllers // Thay thế bằng tên dự án của bạn
{
    [Authorize] // <-- THÊM DÒNG NÀY ĐỂ BẢO VỆ TOÀN BỘ CONTROLLER
    public class ArticlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Articles
        [AllowAnonymous] // <-- Cho phép khách xem danh sách
        public ActionResult Index(string searchString)
        {
            var articles = from a in db.Articles
                           select a;

            if (!string.IsNullOrEmpty(searchString))
            {
                articles = articles.Where(s => s.Title.Contains(searchString));
            }

            return View(articles.OrderByDescending(s => s.PublishedDate).ToList());
        }

        // GET: Articles/Details/5
        [AllowAnonymous] // <-- Cho phép khách xem chi tiết
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
        // Action này sẽ tự động được bảo vệ bởi [Authorize] ở trên

        [Authorize(Roles = "Admin,Editor")] // Chỉ Admin hoặc Editor được vào trang Tạo
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        [Authorize(Roles = "Admin,Editor")] // Chỉ Admin hoặc Editor được vào trang Tạo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content,Author,PublishedDate,ImageUrl")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        // GET: Articles/Edit/5
        [Authorize(Roles = "Admin,Editor")] // Chỉ Admin hoặc Editor được vào trang Tạo
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        [Authorize(Roles = "Admin,Editor")] // Chỉ Admin hoặc Editor được vào trang Tạo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,Author,PublishedDate,ImageUrl")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: Articles/Delete/5
        [Authorize(Roles = "Admin,Editor")] // Chỉ Admin hoặc Editor được vào trang Tạo
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [Authorize(Roles = "Admin,Editor")] // Chỉ Admin hoặc Editor được vào trang Tạo
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
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