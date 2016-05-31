using System.Collections.Generic;
using MvvmLightUwpExample.Models;

namespace MvvmLightUwpExample.Services.Interfaces
{
    public interface IItemsProvider
    {
        IEnumerable<Item> GetItems();
    }
}