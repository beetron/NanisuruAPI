﻿using MongoDB.Driver;
using NanisuruAPI.Collections;

namespace NanisuruAPI.Repository
{
    public class ItemsRepository : IItemsRepository
    {
        readonly IMongoCollection<Items> _itemsCollection;

        public ItemsRepository(IMongoDatabase mongoDatabase)
        {
            _itemsCollection = mongoDatabase.GetCollection<Items>("items");
        }

        // Get collection
        public async Task<List<Items>> GetAllAsync()
        {
            return await _itemsCollection.Find(_ => true).ToListAsync();
        }

        // Get completed collection
        public async Task<List<Items>> GetCompletedItems ()
        {
            return await _itemsCollection.Find(_ => _.ItemStatus == "complete").ToListAsync();
        }

        // Get Incomplete collection
        public async Task<List<Items>> GetIncompleteItems()
        {
            return await _itemsCollection.Find(_ => _.ItemStatus == "incomplete").ToListAsync();
        }

        // Get by Id
        public async Task<Items> GetByIdAsync(string id)
        {
            return await _itemsCollection.Find(_ => _.Id == id).FirstOrDefaultAsync();

        }

        // Insert one
        public async Task CreateNewItemsAsync(Items newItems)
        {
            await _itemsCollection.InsertOneAsync(newItems);
        }

        // Update item
        public async Task UpdateItemsAsync(Items itemsToUpdate)
        {
            await _itemsCollection.ReplaceOneAsync(x => x.Id == itemsToUpdate.Id, itemsToUpdate);
        }

        //Delete item
        public async Task DeleteItemsAsync(string id)
        {
            await _itemsCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
