using Chitter.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chitter.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<ReplyEntity> Replies { get; set; }
        public DbSet<LikeEntity> Likes { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
    }
}