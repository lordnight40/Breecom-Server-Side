using Microsoft.EntityFrameworkCore;

namespace otec.egory.api.dto
{
    public sealed class DataContext : DbContext
    {
        public DataContext()
        {
            Database.EnsureCreated();
        }
    }
}