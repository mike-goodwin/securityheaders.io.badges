using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mime;
using System.Net;
using System.Diagnostics;

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
            if (!Uri.IsWellFormedUriString(domain, UriKind.Absolute))
            {
                //do not log the domain in this case since it could be anything
                Trace.TraceError("Invalid domain supplied");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

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
            catch(Exception e)
            {
                Trace.TraceError("Error ({0}) when rating domain {1}", e.Message, domain);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            return Content(response, responseType);
        }

    }
}