using Chat.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.Core.Abstract
{
    public interface IChatLog : ICRUD
    {
        Task<List<ChatLog>> Get();
        Task<List<ChatLog>> Get(string room);
        bool Insert(ChatLog model);
    }
}
