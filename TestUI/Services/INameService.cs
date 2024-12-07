using Test2UI.Models;

namespace Test2UI.Services
{
    public interface INameService
    {
        Task<List<NameModel>> GetAllNamesAsync();
        Task<NameModel> GetNameByIdAsync(int id);
        Task AddNameAsync(NameModel name);
        Task UpdateNameAsync(int id, NameModel name);
        Task DeleteNameAsync(int id);
    }
}
