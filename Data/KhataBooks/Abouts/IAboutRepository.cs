using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace Data.Aboutes;

public interface IAboutRepository
{
    Task Delete(int id);
    Task<About> GetById(int id);
    Task Update(About about);
    Task<List<About>> GetAll();
    Task<About> Create(About about);
}