using Microsoft.EntityFrameworkCore;

namespace SimpleAspNetApiDemo.DataAccess
{
    public interface IConfigurable
    {
        void Configure(ModelBuilder modelBuilder);
    }
}
