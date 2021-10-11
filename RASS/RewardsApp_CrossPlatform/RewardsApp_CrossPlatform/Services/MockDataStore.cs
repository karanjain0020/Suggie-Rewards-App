using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RewardsApp_CrossPlatform.Models;

namespace RewardsApp_CrossPlatform.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        readonly User user;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "BOGO Ice Cream! Any Size!", Value = "75" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "50% Off Candy Purchase", Value = "50" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "25% Off Milshake or Float", Value = "40" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "2 Scoops Free!", Value = "100" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "1 Scoop Free!", Value = "50" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Free Handfull of Candy", Value = "25" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "2 Scoops Free!", Value = "100" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "2 Scoops Free!", Value = "100" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "2 Scoops Free!", Value = "100" }
            };
            user = new User { Id = Guid.NewGuid().ToString(), Cur_Points = 200, All_Time_Points = 350 };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }


        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

    }
}