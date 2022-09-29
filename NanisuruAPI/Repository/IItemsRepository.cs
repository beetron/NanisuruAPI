using NanisuruAPI.Collections;

namespace NanisuruAPI.Repository
{
    public interface IItemsRepository
    {
        Task<List<Items>> GetAllAsync();
        Task<Items> GetByIdAsync(string id);
        Task CreateNewItemsAsync(Items newItems);
        Task UpdateItemsAsync(Items itemsToUpdate);
    }
}
