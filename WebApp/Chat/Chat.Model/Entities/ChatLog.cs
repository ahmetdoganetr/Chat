using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.Model.Entities
{
    public class ChatLog
    {
        public ChatLog()
        {
            this.Date = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChatLogId { get; set; }

        public string Room { get; set; }

        public string Nickname { get; set; }

        public string Message { get; set; }

        public DateTime Date { get; set; }
    }
}
