using AarhusWebDevCoop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;

namespace AarhusWebDevCoop.Controllers
{
    public class MessageController : SurfaceController
    {
        // GET: Message
        public ActionResult Index()
        {
            return PartialView("MessageForm", new MessageForm());
        }
        [HttpPost]
        public ActionResult HandleFormSubmit(MessageForm model)
        {
            IContent message = Services.ContentService.CreateContent(model.NameMessage, CurrentPage.Id, "Message");
            message.SetValue("nameMessage", model.NameMessage);
            message.SetValue("messageContent", model.MessageContent);

            Services.ContentService.SaveAndPublish(message);
           
            return RedirectToCurrentUmbracoPage();
        }
    }
    }