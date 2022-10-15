using System.Diagnostics;
using System.Security.Claims;
using Chat_App.Helper;
using Chat_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Json;
using Newtonsoft.Json;


namespace Chat_App.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public readonly ChatAppContext db = new ChatAppContext();
        public IActionResult Index()
        {
             var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var target_user = db.AspNetUsers.Where(x => x.Id == userId).FirstOrDefault();
            string s = "";
            foreach(var item in target_user.UserName)
            {
                if (item == '@')
                    break;
                s += item;
            }
            target_user.UserName = s;
            db.AspNetUsers.Update(target_user);
            db.SaveChanges();
            var all_messages = db.Messages.ToList();
            return View(all_messages);
        }

        public IActionResult History()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var target_user = db.AspNetUsers.Where(x => x.Id == userId).FirstOrDefault();
            var list_messages = db.Messages.Where(x => x.Name == target_user.UserName).ToList();
            return View(list_messages);
        }
        

       
    }
}