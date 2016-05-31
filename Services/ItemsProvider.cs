using System.Collections.Generic;
using MvvmLightUwpExample.Models;
using MvvmLightUwpExample.Services.Interfaces;

namespace MvvmLightUwpExample.Services
{
    public class ItemsProvider : IItemsProvider
    {
        public IEnumerable<Item> GetItems()
        {
            const int itemCount = 20;
            var items = new List<Item>();

            for (var i = 1; i <= itemCount; i++)
            {
                items.Add(new Item
                {
                    Title = $"Runtime item {i}",
                    Subtitle = $"Runtime item {i} subtitle"
                });
            }

            return items;
        }
    }
}