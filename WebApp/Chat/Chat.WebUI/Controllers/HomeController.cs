using Chat.Core.Abstract;
using Chat.Model.Entities;
using Chat.WebUI.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IChatLog chatLogRepository;

        private IHubContext<ChatHub> chatHub;

        public HomeController(IChatLog chatLogRepository, IHubContext<ChatHub> chatHub)
        {
            this.chatHub = chatHub;
            this.chatLogRepository = chatLogRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage([FromBody] Models.Chat model)
        {
            var chatLog = new ChatLog()
            {
                Room = model.Room,
                Nickname = model.Nickname,
                Message = model.Message
            };

            chatLogRepository.Insert(chatLog);

            chatHub.Clients.All.SendAsync(model.Room, model);

            return Accepted();
        }

        public async Task<IEnumerable<ChatLog>> GetChatMessageByRoom(string room)
        {
            return await chatLogRepository.Get(room);
        }
    }
}
