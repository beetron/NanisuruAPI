using NanisuruAPI.Collections;
using Microsoft.EntityFrameworkCore;

namespace NanisuruAPI.Data
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { set; get; }
    }
}
