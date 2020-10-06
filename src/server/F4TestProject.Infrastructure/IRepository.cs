using System.Threading.Tasks;

namespace F4TestProject.Infrastructure
{
    public interface IRepository
    {
        Task SaveChanges();
    }
}
