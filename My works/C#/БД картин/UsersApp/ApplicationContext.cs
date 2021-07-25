using System.Data.Entity;

namespace UsersApp
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        public ApplicationContext() : base("DefaultConnection") { }
    }
}
