using Chat.Core.Abstract;
using Chat.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Core.Repository
{
    public class ChatLogRepository : CRUD, IChatLog
    {
        public Task<List<ChatLog>> Get()
        {
            try
            {
                return db.ChatLog.ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Task<List<ChatLog>> Get(string room)
        {
            try
            {
                return db.ChatLog.Where(c => c.Room == room).ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool Insert(ChatLog model)
        {
            try
            {
                return Insert<ChatLog>(model);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
