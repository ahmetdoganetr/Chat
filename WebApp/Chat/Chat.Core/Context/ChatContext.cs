using Chat.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Core.Context
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        {

        }

        public ChatContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Options.Settings.Default.ConnectionStringDevelopment);

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            optionsBuilder.UseLazyLoadingProxies(false);
        }

        #region POCOS
        public DbSet<ChatLog> ChatLog { get; set; }
        #endregion
    }
}
