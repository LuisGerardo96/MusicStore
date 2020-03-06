using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicStore.Models;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using MusicStore.Filtros;

namespace MusicStore.Controllers
{
    [CustomAuthenticationFilter]
    public class StoreManagerController : Controller
    {
        private MusicStoreEntities db = new MusicStoreEntities();

        // GET: StoreManager
        [CustomAuthorize("Admin")]
        public ActionResult Index()
        {
            var albums = db.Albums.Include(a => a.Artist).Include(a => a.Genre);
            return View(albums.ToList());
        }
        [HttpPost]
        public PartialViewResult Index(string Name)
        {

            List<Album> albunes = db.Albums.Where(e => e.Artist.Name.Contains(Name)).ToList();
            return PartialView("_Tableview",albunes);
        }

        //[CustomAuthorize("Admin")]
        //// GET: StoreManager/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Album album = db.Albums.Find(id);
        //    if (album == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(album);
        //}
        [CustomAuthorize("Admin")]
        // GET: StoreManager/Create
        public PartialViewResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name");
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            return PartialView("_Create");
        }

        // POST: StoreManager/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize("Admin")]
        public ActionResult Create([Bind(Include = "AlbumId,GenreId,ArtistId,Title,Price")] Album album, HttpPostedFileBase File1)
        {
            if (ModelState.IsValid)
            {
                var img = new byte[File1.ContentLength];   
                File1.InputStream.Read(img, 0, File1.ContentLength);
                album.Img = img;
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            return PartialView("_Create",album);
        }


        // GET: StoreManager/Edit/5
        [CustomAuthorize("Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            string[] fieldsToBind = new string[] { "GenreId", "ArtistId", "Title", "Price"};
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var albumupdate = await db.Albums.FindAsync(id);
            if (albumupdate == null)
            {
                Album albundeleted = new Album();
                TryUpdateModel(albundeleted, fieldsToBind);
                ModelState.AddModelError(string.Empty, "Unable to save changes. The department was deleted by another user.");
                ViewBag.GenreID = new SelectList(db.Genres, "GenreId", "Name", albundeleted.GenreId);
                ViewBag.ArtistID = new SelectList(db.Artists, "ArtistId", "Name", albundeleted.ArtistId);
                return PartialView("_Edit",albundeleted);
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", albumupdate.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", albumupdate.GenreId);
            return PartialView("_Edit",albumupdate);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize("Admin")]
        public ActionResult Edit([Bind(Include = "AlbumId,GenreId,ArtistId,Title,Price")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }


        //public async Task<ActionResult> EditAsync([Bind(Include = "AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl,RowVersion")] Album album, byte[] rowVersion)
        //{


        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            db.Entry(album).OriginalValues["RowVersion"] = rowVersion;
        //            db.Entry(album).State = EntityState.Modified;
        //            await db.SaveChangesAsync();
        //            return RedirectToAction("Index");
        //        }
        //        catch (DbUpdateConcurrencyException ex)
        //        {
        //            var entry = ex.Entries.Single();
        //            var databaseEntry = entry.GetDatabaseValues();
        //            if (databaseEntry == null)
        //            {
        //                ModelState.AddModelError(string.Empty,
        //                    "Unable to save changes. The department was deleted by another user.");
        //            }
        //            else
        //            {
        //                var databaseValues = (Album)databaseEntry.ToObject();
        //                ModelState.AddModelError(string.Empty, "The record you attempted to edit "
        //                    + "was modified by another user after you got the original value. The "
        //                    + "edit operation was canceled and the current values in the database "
        //                    + "have been displayed. If you still want to edit this record, click "
        //                    + "the Save button again. Otherwise click the Back to List hyperlink.");
        //                album.RowVersion = databaseValues.RowVersion;
        //            }
        //        }
        //    }
        //    ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
        //    ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
        //    return View(album);
        //}



        // GET: StoreManager/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Album album = db.Albums.Find(id);
        //    if (album == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(album);
        //}
        //[CustomAuthorize("Admin")]
        //public async Task<ActionResult> Delete(int? id, bool? concurrencyError)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Album album = await db.Albums.FindAsync(id);
        //    if (album == null)
        //    {
        //        if (concurrencyError.GetValueOrDefault())
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        return HttpNotFound();
        //    }

        //    if (concurrencyError.GetValueOrDefault())
        //    {
        //        ViewBag.ConcurrencyErrorMessage = "The record you attempted to delete "
        //            + "was modified by another user after you got the original values. "
        //            + "The delete operation was canceled and the current values in the "
        //            + "database have been displayed. If you still want to delete this "
        //            + "record, click the Delete button again. Otherwise "
        //            + "click the Back to List hyperlink.";
        //    }

        //    return View(album);
        //}

     
        
        [HttpGet]
        [CustomAuthorize("Admin")]
        public ActionResult Delete(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
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
