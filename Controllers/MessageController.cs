using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        // private MessageContext _db;
        //
        // public MessageController(MessageContext db)
        // {
        //     _db = db;
        // }

        // GET
        public Message GetMessage()
        {
            Message m = new Message();
            m.Id = 1;
            m.Text = "Some Text";
            return m;
        }
    }
}