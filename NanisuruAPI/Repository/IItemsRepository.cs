using NanisuruAPI.Collections;

namespace NanisuruAPI.Repository
{
    public interface IItemsRepository
    {
        Task<List<Items>> GetAllAsync();
        Task<List<Items>> GetCompletedItems();
        Task<List<Items>> GetIncompleteItems();

        Task<Items> GetByIdAsync(string id);
        Task CreateNewItemsAsync(Items newItems);
        Task UpdateItemsAsync(Items itemsToUpdate);
        Task DeleteItemsAsync(string id);
    }
}
