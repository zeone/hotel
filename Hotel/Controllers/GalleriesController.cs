using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel.Models;

namespace Hotel.Controllers
{
    [Authorize]
    public class GalleriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Galleries
        public async Task<ActionResult> Index()
        {
            return View(await db.Gallery.ToListAsync());
        }





        // GET: Galleries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = await db.Gallery.FindAsync(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            var originalDirectory =
                new System.IO.DirectoryInfo(
                    $"{Server.MapPath(@"\")}Content\\img\\gallery");
            System.IO.File.Delete($"{originalDirectory}\\{gallery.ImgName}");
            db.Gallery.Remove(gallery);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public ActionResult SaveUploadedFile()
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = Guid.NewGuid().ToString(); //file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        var originalDirectory =
                            new DirectoryInfo(
                                $"{Server.MapPath(@"\")}Content\\img");
                        string pathString = Path.Combine(originalDirectory.ToString(),
                            "gallery");
                        var fileName1 = Path.GetFileName(file.FileName);
                        var extArr = fileName1.Split('.');
                        var fileExt = extArr[extArr.Length - 1];
                        bool isExists = Directory.Exists(pathString);
                        if (!isExists)
                            Directory.CreateDirectory(pathString);
                        fName += $".{fileExt}";
                        var path = $"{pathString}\\{fName}";
                        file.SaveAs(path);
                        SaveThumbnailImage(file.InputStream, pathString, fName);
                        db.Gallery.Add(new Gallery() { ImgName = fName });
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
            }

            if (isSavedSuccessfully == false)
                return Json(new { Message = fName });
            else
                return Json(new { Message = "Error in saving file" });
        }


        void SaveThumbnailImage(Stream fileInputStream, string pathString, string fileName)
        {
            Image img = Image.FromStream(fileInputStream);
            Image thumb = img.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
            pathString = Path.Combine(pathString,
                "thumb");
            if (!Directory.Exists(pathString))
                Directory.CreateDirectory(pathString);
            thumb.Save($"{pathString}\\tumb_{fileName}");
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
