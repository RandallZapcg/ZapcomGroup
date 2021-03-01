using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MessageLibrary.Models;

    public class NotificationApi : DbContext
    {
        public NotificationApi (DbContextOptions<NotificationApi> options)
            : base(options)
        {
        }

        public DbSet<MessageLibrary.Models.MessageRecipient> MessageRecipient { get; set; }
    }
