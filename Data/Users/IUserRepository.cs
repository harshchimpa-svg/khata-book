using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Data.Repositorys
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task AddAsync (User user);
        Task UpdateAsync (User user);
        Task<User> GetByEmail(string requestEmail);
    }
}
