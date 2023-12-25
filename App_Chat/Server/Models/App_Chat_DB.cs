using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Server.Models
{
    public partial class App_Chat_DB : DbContext
    {
        public App_Chat_DB()
            : base("name=App_Chat_DB")
        {
        }

        public virtual DbSet<Chat_Infor> Chat_Infor { get; set; }
        public virtual DbSet<FriendList> FriendLists { get; set; }
        public virtual DbSet<FriendRequest> FriendRequests { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<User_Avatar> User_Avatar { get; set; }
        public virtual DbSet<User_Details> User_Details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat_Infor>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FriendLists)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserID1);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FriendLists1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.UserID2);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FriendRequests)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ReceiverID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FriendRequests1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.SenderID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ReceiverID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.SenderID);
        }
    }
}
