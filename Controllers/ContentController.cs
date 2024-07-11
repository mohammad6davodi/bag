using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UploadAndDisplayImageInMvc.Models;
using UploadAndDisplayImageInMvc.Repositories;
using UploadAndDisplayImageInMvc.ViewModel;

namespace UploadAndDisplayImageInMvc.Controllers
{
    [RoutePrefix("Content")]
    [ValidateInput(false)]
    public class ContentController : Controller
    {
        private DBContext db = new DBContext();
        /// <summary>
        /// Retrive content from database 
        /// </summary>
        /// <returns></returns>
        [Route("Index")]
        [HttpGet]
        public ActionResult Index(string search)
        {
            var content = db.Contents.Select(s => new
            {
                s.ID,
                s.Image,
                s.Title,
                s.Description,
                s.Link1
            });

            List<ContentViewModel> contentModel = content.Select(item => new ContentViewModel()
            {
                ID = item.ID,
                Image = item.Image,
                Title = item.Title,
                Description = item.Description,
                Link1 = item.Link1
            }).ToList();
            {
                ViewBag.search = search;
                if (!string.IsNullOrEmpty(search))
                {

                    return View(contentModel.Where(c => c.Title.Contains(search)));
                }
                return View(contentModel);
            }
        }
        public ActionResult RetrieveImage(int id)
        {
            byte[] cover = GetImageFromDataBase(id);
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public byte[] GetImageFromDataBase(int Id)
        {
            var q = from temp in db.Contents where temp.ID == Id select temp.Image;
            byte[] cover = q.First();
            return cover;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Save content and images
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("Create")]
        [HttpPost]
        public ActionResult Create(ContentViewModel model)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];
            ContentRepository service = new ContentRepository();
            int i = service.UploadImageInDataBase(file, model);
            if (i == 1)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content contents = db.Contents.Find(id);
            if (contents == null)
            {
                return HttpNotFound();
            }
            return View(contents);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // POST: Problems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Content content = db.Contents.Find(id);
            db.Contents.Remove(content);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Place(string search)
        {
            var content = db.Contents.Select(s => new
            {
                s.ID,
                s.Image,
                s.Title,
                s.Description,
                s.Link1
            });

            List<ContentViewModel> contentModel = content.Select(item => new ContentViewModel()
            {
                ID = item.ID,
                Image = item.Image,
                Title = item.Title,
                Description = item.Description,
                Link1 = item.Link1
            }).ToList();
            {
                ViewBag.search = search;
                if (!string.IsNullOrEmpty(search))
                {

                    return View(contentModel.Where(c => c.Title.Contains(search)));
                }
                return View(contentModel);
            }
        }
    }
}