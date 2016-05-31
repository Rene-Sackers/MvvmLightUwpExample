using System.Collections.Generic;
using MvvmLightUwpExample.Helpers.Attributes;
using MvvmLightUwpExample.Models;

namespace MvvmLightUwpExample.Services.Interfaces
{
    [DependencyInformation(typeof(IItemsProvider), typeof(ItemsProvider), typeof(Design.ItemsProvider))]
    public interface IItemsProvider
    {
        IEnumerable<Item> GetItems();
    }
}