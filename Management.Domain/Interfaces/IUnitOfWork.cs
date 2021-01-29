using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Management.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
