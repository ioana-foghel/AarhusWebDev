using AarhusWebDevCoop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;

namespace AarhusWebDevCoop.Controllers
{
    public class ContactController : SurfaceController
    {
        // GET: Contact
        public ActionResult Index()
        {
            return PartialView("ContactForm", new ContactForm());
        }
 
        [HttpPost]
        public ActionResult HandleFormSubmit(ContactForm model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            MailMessage message = new MailMessage();
            message.To.Add("testingumbraco@gmail.com");
            message.Subject = "New Contact request";
            message.From = new MailAddress(model.Email, model.Name);
            message.Body = model.Message;

            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("testingumbraco@gmail.com", "umbracoumbraco");

                smtp.Send(message);

                TempData["success"] = true;
            }

            IContent comment = Services.ContentService.CreateContent(model.Subject, CurrentPage.Id, "Comment");
            comment.SetValue("commentName", model.Name);
            comment.SetValue("email", model.Email);
            comment.SetValue("subject", model.Subject);
            comment.SetValue("message", model.Message);

            Services.ContentService.Save(comment);

            return RedirectToCurrentUmbracoPage();
        }
    }
}