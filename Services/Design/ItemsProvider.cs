using System.Collections.Generic;
using MvvmLightUwpExample.Models;
using MvvmLightUwpExample.Services.Interfaces;

namespace MvvmLightUwpExample.Services.Design
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
                    Title = $"Design time item {i}",
                    Subtitle = $"Design timer item {i} subtitle"
                });
            }

            return items;
        }
    }
}