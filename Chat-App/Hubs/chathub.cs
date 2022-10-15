using System.Security.Claims;
using Chat_App.Models;
using Microsoft.AspNetCore.SignalR;
using Chat_App.Helper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Chat_App.Controllers;

namespace Chat_App.Hubs
{
    public class chathub : Hub
    {
        public readonly ChatAppContext db = new ChatAppContext();

     
        
        public async Task sendmessage(string fromuer, string message)
        {
            
            var temp = new Message();
            temp.Name = fromuer;
            temp.Message1 = message;
            db.Messages.Add(temp);
            db.SaveChanges();
          
            await Clients.All.SendAsync("reseivemessage", fromuer, message);
        }
    }
}
