using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class ImagenesController : Controller
    {
        MusicStoreEntities db = new MusicStoreEntities();
        // GET: Imagenes
        public ActionResult Verimagen(int ID)
        {
            byte[] datos = db.Albums.FirstOrDefault(i => i.AlbumId == ID)?.Img;
            
            if (datos != null)
            {
                return File(datos, "image/png"); // Might need to adjust the content type based on your actual image type
            }
            return null;
        }
    }
}