using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mime;
using System.Net;

namespace SecurityHeaders.io.badges.Controllers
{
    public class CreateController : Controller
    {
        private const string SVG = "image/svg+xml";
        private const string TEXT = "text/plain";

        public ActionResult Markup()
        {
            return View();
        }

        public ActionResult Badge(string domain)
        {
            string response;
            string responseType;
            Rater rater = new Rater();

            try
            {
                string rating = rater.Rate(domain);
                Badger badger = new Badger();
                response = badger.Badge(rating);
                responseType = SVG;
            }
            catch(BlackListException e)
            {
                responseType = TEXT;
                response = e.Message;
            }
            catch(Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return Content(response, responseType);
        }

    }
}